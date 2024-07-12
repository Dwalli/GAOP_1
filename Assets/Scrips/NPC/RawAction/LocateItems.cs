using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocateItems : MonoBehaviour
{

    public LayerMask Dectection = ~0;

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
            if (candidateTarget.gameObject == gameObject) continue;

            // getting magitude between the 2 vectors
            var vectorToTarget = candidateTarget.transform.position - transform.position;
             // skip out of range
            if (vectorToTarget.sqrMagnitude > LinkedAI.ItemVisionConeRange * LinkedAI.ItemVisionConeRange) continue;

            // check if the ray cast hit the target and to identify the object / it a bug that works :)
            RaycastHit hitResult;
            if (Physics.Raycast(LinkedAI.EyeLocation, vectorToTarget.normalized, out hitResult, LinkedAI.ItemVisionConeRange, Dectection, QueryTriggerInteraction.Collide))
            {
                if (hitResult.collider.GetComponentInParent<Detectable>() == candidateTarget)
                {
                     LinkedAI.ReportItemInProximity(candidateTarget);//this can be any trigger
                }
            }

        }
    }

}
