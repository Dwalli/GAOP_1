using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Wonder : BaseAction
{
    List<System.Type> supportedGoals = new List<System.Type>(new System.Type[] {typeof(Goal_Wonder) });
    public override List<System.Type> GetSupportedGoals(){

        return supportedGoals;
    }

    public override void OnTickAction(){
        if (hunt.AtDestination){
            OnActionActive(LinkedGoal);
        }
    }

    public override float GetCost(){

        return 0;
    }

    public override void OnActionActive(BaseGoal linkedGoal){
        base.OnActionActive(linkedGoal);
        Vector3 Location = hunt.PickLocationInRange(hunt.range);
        hunt.MoveTo(Location);
    }

    public override void OnActionDeactive(){
        hunt.MoveTo(transform.position); //to reset the position
        base.OnActionDeactive();
    }
}
