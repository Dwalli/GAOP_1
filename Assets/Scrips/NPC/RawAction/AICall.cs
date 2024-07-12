using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICall : MonoBehaviour
{
    SensorReport Report;
    [SerializeField] float _VisionConeAngle = 60f;
    [SerializeField] float _VisionConeRange = 30f;
    [SerializeField] Color _VisionConeColour = new Color(1f, 0f, 0f, 0.25f);

    [SerializeField] float _ItemVisionConeRange = 15f;

    [SerializeField] float _ProximityDetectionRange = 5f;
    [SerializeField] Color _ProximityRangeColour = new Color(1f, 1f, 1f, 0.25f);

    public Vector3 EyeLocation => transform.position;
    public Vector3 EyeDirection => transform.forward;

    public float VisionConeAngle => _VisionConeAngle;
    public float VisionConeRange => _VisionConeRange;
    public Color VisionConeColour => _VisionConeColour;

    public float ItemVisionConeRange => _ItemVisionConeRange;

    public float ProximityDetectionRange => _ProximityDetectionRange;
    public Color ProximityDetectionColour => _ProximityRangeColour;

    public float CosVisionConeAngle { get; private set; } = 0f;


    void Awake()
    {
        Report = GetComponent<SensorReport>();
        CosVisionConeAngle = Mathf.Cos(VisionConeAngle * Mathf.Deg2Rad); //save resouses
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReportCanSee(Detectable seen)
    {
        Report.ReportCanSee(seen);
        Debug.Log(" In vision Proximity");
    }

    public void ReportInProximity(Detectable seen)
    {
        Report.ReportCanFeeL(seen);
         Debug.Log(" In Proximity");
    }
    
    public void ReportItemInProximity(Detectable seen)
    {
        Report.ReportItemInProximity(seen);
        Debug.Log(" Item in Proximity");
    }

    public void OnSuspicious()
    {
        Debug.Log(" I know you are close ");
    }

    public void OnDetected(GameObject target)
    {
        Debug.Log(" Get over here ", target);
    }

    public void OnFullyDetected(GameObject target)
    {
        Debug.Log(" Die ", target);
    }

    public void OnLostDetect(GameObject target)
    {
        Debug.Log(" I know you are close ");
    }

    public void OnLostSuspicion()
    {
        Debug.Log(" Must be imagining things ");
    }

    public void OnFullyLost()
    {
        Debug.Log(" Strong wind today ");
    }
}
