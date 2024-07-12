using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_chase : BaseAction
{
    List<System.Type> supportedGoals = new List<System.Type>(new System.Type[] {typeof(Gaol_Chase) });

    Gaol_Chase chaseGoal;
    public override List<System.Type> GetSupportedGoals(){

        return supportedGoals;
    }

    public override void OnTickAction(){
        if (hunt.AtDestination)
        {
            OnActionActive(LinkedGoal);
        }
    }

    public override float GetCost(){

        return 0;//so that it will be compaird soon
    }

    public override void OnActionActive(BaseGoal linkedGoal){
        Vector3 Location = transform.position;
        base.OnActionActive(linkedGoal);
        chaseGoal = (Gaol_Chase)linkedGoal; // get the target and more it to possition
        if (chaseGoal != null)//it randomly go null this is to check
        {
            Location = chaseGoal.playerPos.position;
        }
        
        hunt.MoveTo(Location);
        Debug.Log(Location);
    }

    public override void OnActionDeactive(){
        base.OnActionDeactive();
    }
}
