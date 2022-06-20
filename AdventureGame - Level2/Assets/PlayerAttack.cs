using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public static PlayerAttack instance;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {

        if(timeBtwAttack <= 0){

            if (Input.GetKey(KeyCode.Space))
            {
                
                timeBtwAttack = startTimeBtwAttack;
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    CinemachineShake.Instance.ShakeCamera(5f, .1f);
                    enemiesToDamage[i].GetComponent<PatrolNew>().TakeDamage(damage);
                }
            }

            
        } else {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public void IncreaseDmg(int dmg)
    {
        damage = dmg;
    }
}
