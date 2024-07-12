using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Attack : BaseAction
{
    List<System.Type> supportedGoals = new List<System.Type>(new System.Type[] {typeof(Goal_Attack) });

    private int costIncrease = 1;
    private int currentCost = 1;

    private bool heavy = false;

    public override List<System.Type> GetSupportedGoals(){

        return supportedGoals;
    }

    public override void OnTickAction(){
        OnActionActive(LinkedGoal);
  
    }

    public override float GetCost(){

        return currentCost;//so that it will be compaird soon
    }

    public override void OnActionActive(BaseGoal linkedGoal){
        base.OnActionActive(linkedGoal);
        _attack.Attack(false);
  //     Debug.Log("Heavy not used");
        currentCost += costIncrease;

    }

    public override void OnActionDeactive(){
        base.OnActionDeactive();
    }
}
