using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Damage : MonoBehaviour
{
    public PlayerHealth pHealth;
    public float damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            pHealth.health -= damage;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            pHealth.health += damage;
        }
    }

}
