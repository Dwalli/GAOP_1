using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaol_Chase : BaseGoal
{
    [SerializeField] private int HighPriority = 50;
    [SerializeField] private float PriorityBuildUp = 0.5f;
    [SerializeField] float MinAwarenessToChase = 1.5f;
    [SerializeField] float AwarenessToStopChase = 1f;
     public Vector3 MoveTarget => currentTarget != null ? currentTarget.transform.position : transform.position;
    public Transform playerPos;
    Detectable currentTarget;
    int CurrentPriority = 0;

    public override bool CanRun(){
        // no targets
        if (sensor.ActiveTargets == null || sensor.ActiveTargets.Count == 0)
            return false;

        // check if we have anything we are aware of
        foreach(var candidate in sensor.ActiveTargets.Values)
        {
            if (candidate.Awareness >= MinAwarenessToChase)
                return true;
        }


        return false;
    }

    public override void OnTickGoal(){
        CurrentPriority = 0;

        if (sensor.ActiveTargets == null || sensor.ActiveTargets.Count == 0) { return; } 
        if (currentTarget != null)
        {
            // check if we have anything we are aware of
            foreach(var candidate in sensor.ActiveTargets.Values)
            {
                if (candidate.detectable == currentTarget){
                    CurrentPriority = candidate.Awareness < AwarenessToStopChase ? 0 : HighPriority;
                    return;
                }
                
            }

            currentTarget = null;
        }
        // look for new targets
        foreach (var candidate in sensor.ActiveTargets.Values)
        {
            if (candidate.Awareness >= MinAwarenessToChase)
            {// found a target to acquire
                currentTarget = candidate.detectable;
                CurrentPriority = HighPriority;
                return;
            }
        }
    }

    public override void OnGoalActive(BaseAction linkedAction){
        base.OnGoalActive(linkedAction);
        currentTarget = null;
    }

    public override float OnCalculatePriority(){
        Debug.Log(CurrentPriority + ": chase");
        return CurrentPriority;
    }

    
    public override void OnGoalDeactive(){
        base.OnGoalDeactive();
        currentTarget = null;      
    }

}
