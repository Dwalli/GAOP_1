using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Heavy_Attack : BaseAction
{
    List<System.Type> supportedGoals = new List<System.Type>(new System.Type[] {typeof(Goal_Attack) });

    private int costIncrease = 5;
    private int currentCost = 5;
    private bool heavy = true;

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
        _attack.Attack(heavy);
   //     Debug.Log("Heavy used");
        currentCost += costIncrease;
      
    }

    public override void OnActionDeactive(){
        base.OnActionDeactive();
    }
}

