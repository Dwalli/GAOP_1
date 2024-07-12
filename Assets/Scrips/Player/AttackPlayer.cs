using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private Transform wepaonTransform;
    [SerializeField] private float timeToAttack = 0.5f;
    private bool isAttacking = false;
    private float timer;
    private BoxCollider weaponCollider;
    private Health PlayerHealth;
    [SerializeField] public int damageAmount = 15;


    // Start is called before the first frame update
    public void Attack(){
        if (isAttacking == false)
        {
            isAttacking = true;
            weaponCollider.enabled = true;
            Vector3 originalPosition = wepaonTransform.position;
            Vector3 targetPosition = originalPosition + transform.forward * 2f;
            StartCoroutine(AttackAction(originalPosition, targetPosition));            
        }
    }
    IEnumerator AttackAction(Vector3 originalPosition, Vector3 targetPosition){
        float elapsedTime = 0f;

        while (elapsedTime < timeToAttack)
        {
            wepaonTransform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / timeToAttack));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        weaponCollider.enabled = false;
        wepaonTransform.localPosition = Vector3.zero + new Vector3(1,1,1);
    }
    void Start()
    {
        weaponCollider = weapon.GetComponent<BoxCollider>(); 
        PlayerHealth = GetComponent<Health>();
        weaponCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            Attack();
        }

        if(isAttacking == true)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                isAttacking = false;
            }

        }
    }
}
