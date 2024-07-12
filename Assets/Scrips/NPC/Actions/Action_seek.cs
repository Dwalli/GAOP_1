using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_seek : BaseAction
{
    
    List<System.Type> supportedGoals = new List<System.Type>(new System.Type[] {typeof(Goal_Seek)});
    public override List<System.Type> GetSupportedGoals(){

        return supportedGoals;
    }

    public override void OnTickAction(){
        OnActionActive(LinkedGoal);

    }

    public override void OnActionActive(BaseGoal linkedGoal){
        base.OnActionActive(linkedGoal);
        Vector3 LocationToRotate = hunt.ObjectToRotate.position;
        hunt.circleRotate(LocationToRotate, 5f);
    }

    public override float GetCost(){
        return 0;
    }
    public override void OnActionDeactive(){
        base.OnActionDeactive();
    }
}
