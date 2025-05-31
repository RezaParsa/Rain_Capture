using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class Playercombat : MonoBehaviour
{
    public Animator animator;


    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;


    public AudioSource audioSource;
    public AudioClip attackSound;
    
    
    
    private AudioSource _audiosource;
    [SerializeField] private AudioClip _attackSFX;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

     //   Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

     //  foreach (Collider2D enemy in hitEnemies)
     //   {
     //       Debug.Log("We hit " + enemy.name);
            // Add damage logic here if needed
     //   }
    }
   

    void Awake()
    {
        _audiosource = GetComponent<AudioSource>();
    }

    void _PlayAttack()
    {
        _audiosource.PlayOneShot(_attackSFX);
    }

}
