using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Wonder : BaseGoal
{
    [SerializeField] private int HighPriority = 20;
    [SerializeField] private float PriorityBuildUp = 0.5f;

    private float currentPriority;


    public override bool CanRun(){
        if (currentPriority <= 0){
            return false;
        }
        else{

            return true;   
        }

    }

    public override void OnTickGoal(){
         if (currentPriority <= 0){
            currentPriority += PriorityBuildUp * Time.deltaTime;
            hunt.shouldMove = false;
        }
        else if(hunt.shouldMove == true){
            currentPriority -= PriorityBuildUp * Time.deltaTime;    
        }
    }

    public override void OnGoalActive(BaseAction linkedAction){
        base.OnGoalActive(linkedAction);
   //     currentPriority = HighPriority;
    }

    public override float OnCalculatePriority(){
        Debug.Log(currentPriority + ": wonder");
        return currentPriority;
    }
}
