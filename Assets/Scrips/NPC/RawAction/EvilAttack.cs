using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilAttack : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private Transform wepaonTransform;
    [SerializeField] private float timeToAttack = 0.5f;
    private BoxCollider weaponCollider;
    private Health PlayerHealth;

    public bool heavy;

    [SerializeField] private int damageAmount = 15;


    // Start is called before the first frame update
    public bool Attack(bool heavyAttck)
    {
        weaponCollider.enabled = true;
        if (heavyAttck == true ) { heavy = true; return true; }
        else {heavy = false; return false; }
    }

    IEnumerator DoAttack(Vector3 originalPosition, Vector3 targetPosition)
    {
        float elapsedTime = 0f;

        while (elapsedTime < timeToAttack)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / timeToAttack));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        weaponCollider.enabled = false;
        transform.position = originalPosition;
    }
    public void OffCollider(){
        weaponCollider.enabled = false;
    }

    void Start()
    {
        weaponCollider = weapon.GetComponent<BoxCollider>(); 
        OffCollider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
