using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilHealth : MonoBehaviour
{
    public int currentHealth;
    [SerializeField] private int BaseHealth = 100;
    AttackPlayer damage;
    public Transform spawn;

    int damageAmount = 15;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = BaseHealth;
        damage = GetComponent<AttackPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
          TakeDamage(damageAmount);
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
