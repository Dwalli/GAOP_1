using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proxmity : MonoBehaviour
{
    public LayerMask Dectection = ~0;
    public Vector3 whereToAttack;
    public bool playerDetected = false;
    AICall LinkedAI;
    // Start is called before the first frame update
    void Start()
    {
        LinkedAI = GetComponent<AICall>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i <  DetectableManager.Instance.TheTargets.Count; ++i)
        {
            // located instances
            var candidateTarget = DetectableManager.Instance.TheTargets[i];

            // skip self
            if (candidateTarget.gameObject == gameObject){
                if (Vector3.Distance(LinkedAI.EyeLocation, candidateTarget.transform.position) <= LinkedAI.ProximityDetectionRange){
                    LinkedAI.ReportInProximity(candidateTarget);
                    whereToAttack = candidateTarget.transform.position;
                    playerDetected = true;
                }
            }else
            {
               playerDetected = false; 
            }

            
        }
    }
}
