using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGoal{
    public bool CanRun();
    public void OnTickGoal();
    public float OnCalculatePriority();
    public void OnGoalActive(BaseAction linkedAction);
    public void OnGoalDeactive();
}

public class BaseGoal : MonoBehaviour, IGoal
{
    protected PlayerHunt hunt;
    protected BaseAction LinkedAction;
    protected SensorReport sensor;

    protected EvilHealth _health;
    protected EvilAttack _attack;
    protected Proxmity _proxmity;

    // Start is called before the first frame update
    private void Awake(){
        hunt = GetComponent<PlayerHunt>();
        sensor = GetComponent<SensorReport>();
        _health = GetComponent<EvilHealth>();
        _attack = GetComponent<EvilAttack>();
        _proxmity = GetComponent<Proxmity>();
    }

    public virtual bool CanRun(){
        return false;
    }

    public virtual void OnTickGoal(){
        
    }

    public virtual float OnCalculatePriority(){
        return -1;
    }

    public virtual void OnGoalActive(BaseAction linkedAction){
         LinkedAction = linkedAction;
    }

    public virtual void OnGoalDeactive(){
        LinkedAction = null;       
    }

    // Update is called once per frame
    void Update()
    {
        OnTickGoal();

    }
}
