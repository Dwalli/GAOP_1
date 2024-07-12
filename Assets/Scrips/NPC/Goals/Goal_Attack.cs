using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Attack : BaseGoal
{
    [SerializeField] private int HighPriority = 100;
    private int noPriority = 0;
    private float currentPriority;
    [SerializeField] float MinAwarenessToChase = 1.5f;
    Detectable currentTarget;

    public override bool CanRun(){
        if (hunt.AtDestination)
        {
            currentPriority = HighPriority;
            return true;
        }
        currentPriority = noPriority;
        return false;
    }

    public override void OnTickGoal(){

    }

    public override void OnGoalActive(BaseAction linkedAction){
        base.OnGoalActive(linkedAction);
    }

    public override float OnCalculatePriority(){
        Debug.Log(currentPriority + ": Attack");
        return currentPriority;
    }
}
