using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOAPPlanner : MonoBehaviour
{
    BaseAction[] Actions;
    BaseGoal[] Goals;

    BaseAction ActiveActions;
    BaseGoal ActiveGoals;

    // Start is called before the first frame update
    private void Awake() {
        Goals = GetComponents<BaseGoal>();
        Actions = GetComponents<BaseAction>();
    }

    // Update is called once per frame
    void Update()
    {
        BaseGoal bestGoal = null;
        BaseAction bestAction = null;

        // find the highest priority goal that can be activated
        foreach(var goal in Goals)
        {
            // first tick the goal
            goal.OnTickGoal();

            // can it run?
            if (!goal.CanRun())
                continue;

            // is it a worse priority?
            if (!(bestGoal == null || goal.OnCalculatePriority() > bestGoal.OnCalculatePriority()))
                continue;

            // find the best cost action
            BaseAction candidateAction = null;
            foreach(var action in Actions)
            {
                if (!action.GetSupportedGoals().Contains(goal.GetType()))
                    continue;

                // found a suitable action
                if (candidateAction == null || action.GetCost() < candidateAction.GetCost())
                    candidateAction = action;
            }

            // did we find an action?
            if (candidateAction != null)
            {
                bestGoal = goal;
                bestAction = candidateAction;
            }
        }

        // if no current goal
        if (ActiveGoals == null)
        {
            ActiveGoals = bestGoal;
            ActiveActions = bestAction;

            if (ActiveGoals != null)
                ActiveGoals.OnGoalActive(ActiveActions);
            if (ActiveActions != null)
                ActiveActions.OnActionActive(ActiveGoals);            
        } // no change in goal?
        else if (ActiveGoals == bestGoal)
        {
            // action changed?
            if (ActiveActions != bestAction)
            {
                ActiveActions.OnActionDeactive();
                
                ActiveActions = bestAction;

                ActiveActions.OnActionActive(ActiveGoals);
            }
        } // new goal or no valid goal
        else if (ActiveGoals != bestGoal)
        {
            ActiveGoals.OnGoalDeactive();
            ActiveActions.OnActionDeactive();

            ActiveGoals = bestGoal;
            ActiveActions = bestAction;

            if (ActiveGoals != null)
                ActiveGoals.OnGoalActive(ActiveActions);
            if (ActiveActions != null)
                ActiveActions.OnActionActive(ActiveGoals);
        }

        // tick the action
        if (ActiveActions != null)
            ActiveActions.OnTickAction();
    }
}
