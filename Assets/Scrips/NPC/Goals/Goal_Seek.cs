using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Seek : BaseGoal
{
    [SerializeField] private int Priority = 10;
    [SerializeField] private float PriorityBuildDown = 0.1f;
    private float currentPriority = 0;
    public override bool CanRun(){
        return true;
    }

    public override void OnTickGoal(){
        if (currentPriority <= 0){
            hunt.shouldMove = true;
            currentPriority = Priority;
        }
        else if(hunt.shouldMove == false){
            currentPriority -= PriorityBuildDown * Time.deltaTime;
        }

    }

    public override void OnGoalActive(BaseAction linkedAction){
        base.OnGoalActive(linkedAction);
        currentPriority = Priority;
       
    }

    public override float OnCalculatePriority(){
     //   Debug.Log(currentPriority + ": seek");
        return currentPriority;
    }
}
