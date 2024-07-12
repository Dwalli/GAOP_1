using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectable : MonoBehaviour
{

    void Start()//adding any object with this script to be detectable (eh layers)
    {
        DetectableManager.Instance.Register(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {
        if (DetectableManager.Instance != null)
        DetectableManager.Instance.Deregister(this);
    }
}
