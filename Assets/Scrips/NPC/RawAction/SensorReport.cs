using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedTarget{
    public Detectable detectable;
    public Vector3 RawPosition;

    public float LastSensedTime;
    public float Awareness;

    public bool UpdateAwareness(Detectable target, Vector3 possition, float awareness, float minAwareness){
        
        var oldAwareness = Awareness;

        if (target != null)
            detectable      = target;
            RawPosition     = possition;
            LastSensedTime  = Time.time;
            Awareness       = Mathf.Clamp(Mathf.Max(Awareness, minAwareness) + awareness, 0f, 2f);

        if (oldAwareness < 2f && Awareness >= 2f)
            return true;
        if (oldAwareness < 1f && Awareness >= 1f)
            return true;
        if (oldAwareness <= 0f && Awareness >= 0f)
            return true;

        return false;
    }


    public bool DecayAwareness(float decayTime, float amount)
    {
        // detected too recently - no change
        if ((Time.time - LastSensedTime) < decayTime)
            return false;

        var oldAwareness = Awareness;

        Awareness -= amount;

        if (oldAwareness >= 2f && Awareness < 2f)
            return true;
        if (oldAwareness >= 1f && Awareness < 1f)
            return true;
        return Awareness <= 0f;
    }

}

public class SensorReport : MonoBehaviour
{
    [SerializeField]float VisionMinSence = 1f;
    [SerializeField]float VisionBuildSence = 50f;
    [SerializeField]float ProximityMinSence = 1f;
    [SerializeField]float ProximityAwarenessBuildRate = 500f;

    [SerializeField]float ItemProximityAwarenessBuildRate = 0.05f;

    [SerializeField]float AwarenessDecayDelay = 0.2f;
    [SerializeField]float AwarenessDecayRate = 0.2f;

    AICall LinkedAI;

    [SerializeField] AnimationCurve VisionSensitivity;
    Dictionary<GameObject, TrackedTarget> Targets = new Dictionary<GameObject, TrackedTarget>();

     public Dictionary<GameObject, TrackedTarget>  ActiveTargets => Targets;


    void UpdateAwareness(GameObject targetGO, Detectable target, Vector3 position, float awareness, float minAwareness)
    {
        // not in targets
        if (!Targets.ContainsKey(targetGO))
            Targets[targetGO] = new TrackedTarget();

        // update target awareness
        if (Targets[targetGO].UpdateAwareness(target, position, awareness, minAwareness))
        {
            if (Targets[targetGO].Awareness >= 2f){
                LinkedAI.OnFullyDetected(targetGO);
            }
            else if (Targets[targetGO].Awareness >= 1f){
                LinkedAI.OnDetected(targetGO);
            }
            else if (Targets[targetGO].Awareness >= 0f){
                LinkedAI.OnSuspicious();
            }
        }
    }
    public void ReportCanSee(Detectable seen)
    {
        // where is the target
        var vectorToTarget = (seen.transform.position - LinkedAI.EyeLocation).normalized;
        var datProduct = Vector3.Dot(vectorToTarget, LinkedAI.EyeDirection);

        //determin the awareness level
        var awareness = VisionSensitivity.Evaluate(datProduct) * VisionBuildSence * Time.deltaTime;

        UpdateAwareness(seen.gameObject, seen, seen.transform.position, awareness, VisionMinSence);

    }

    public void ReportCanFeeL(Detectable seen)
    {
        var awareness = ProximityAwarenessBuildRate * Time.deltaTime;

        UpdateAwareness(seen.gameObject, seen, seen.transform.position, awareness, ProximityMinSence);
    }

    public void ReportItemInProximity(Detectable seen)
    {
        var awareness = ItemProximityAwarenessBuildRate * Time.deltaTime;

        UpdateAwareness(seen.gameObject, seen, seen.transform.position, awareness, ProximityMinSence);
    }

    // Start is called before the first frame update
    void Start()
    {
        LinkedAI = GetComponent<AICall>();
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> toCleanup = new List<GameObject>();
        foreach(var targetGO in Targets.Keys)
        {
            if (Targets[targetGO].DecayAwareness(AwarenessDecayDelay, AwarenessDecayRate * Time.deltaTime))
            {
                if (Targets[targetGO].Awareness <= 0f)
                {
                    LinkedAI.OnFullyLost();
                    toCleanup.Add(targetGO);
                }
                else
                {
                    if (Targets[targetGO].Awareness >= 1f)
                        LinkedAI.OnLostDetect(targetGO);
                    else
                        LinkedAI.OnLostSuspicion();
                }
            }
        }

        // cleanup targets that are no longer detected
        foreach(var target in toCleanup)
        Targets.Remove(target);
    }

}


