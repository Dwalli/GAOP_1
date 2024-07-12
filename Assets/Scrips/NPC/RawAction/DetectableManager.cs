using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectableManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static DetectableManager Instance { get; private set; } = null;
    public List<Detectable> TheTargets { get; private set; } = new List<Detectable>();
    // Start is called before the first frame update

    private void Awake() {
        if (Instance != null)
        {
            Debug.LogError("Multiple"); // this shoudn'r happen but it could
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void Register(Detectable target){
        TheTargets.Add(target);
    }

    public void Deregister(Detectable target){
         TheTargets.Remove(target);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
