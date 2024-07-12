using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAction : MonoBehaviour
{
    protected PlayerHunt hunt;
    protected BaseGoal LinkedGoal;
    protected SensorReport sensor;
    
    protected EvilHealth _health;
    protected EvilAttack _attack;
    public virtual List<System.Type> GetSupportedGoals(){

        return null;
    }

    public virtual void OnTickAction(){
        
    }

    public virtual float GetCost(){

        return 0;
    }

    public virtual void OnActionActive(BaseGoal linkedGoal){
        LinkedGoal = linkedGoal;
    }

    public virtual void OnActionDeactive(){
        LinkedGoal = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        hunt = GetComponent<PlayerHunt>();
        sensor = GetComponent<SensorReport>();
        _health = GetComponent<EvilHealth>();
        _attack = GetComponent<EvilAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        OnTickAction();

    }
}
