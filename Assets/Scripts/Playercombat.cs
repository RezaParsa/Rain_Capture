using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Playercombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        // play an attack animation 
        animator.SetTrigger("Attack");


        // detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position , attackRange, enemyLayers);

        // damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("we hit " + enemy.name);
        }

    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }






}

