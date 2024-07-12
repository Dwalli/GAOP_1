using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : EvilAttack
{
    public int currentHealth;
    [SerializeField] private int BaseHealth = 100;
    int damageAmount = 5;
    int damageAmountHavey = 50;

    public Transform spawn;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = BaseHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (heavy == true)
        {
            if (other.tag == "Evil"){
            TakeDamage(damageAmountHavey);
            Debug.Log("BOOM!");
            }
        }
        else
        {
            if (other.tag == "Evil"){
            TakeDamage(damageAmount);
            }
        }

    }

    public void TakeDamage(int damageAmount) {
    currentHealth -= damageAmount;
    Debug.Log(currentHealth);
    if (currentHealth <= 0) {
        transform.position = spawn.position;
        currentHealth = BaseHealth;
    }
    }
}
