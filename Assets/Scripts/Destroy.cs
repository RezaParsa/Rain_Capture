using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object we collided with has the tag "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Log to the console to verify the collision detection
            Debug.Log("Enemy hit the ground!");

            // Destroy this enemy GameObject
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            //log enemy hit player
            Debug.Log("enemy hit player!");

            //Destroy this enemy object
            Destroy(gameObject);
        }
    }
}
