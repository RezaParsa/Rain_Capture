using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float groundFriction = 10f; // Friction value to stop sliding
    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        if (!rb) rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get horizontal input (left/right movement)
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Only apply movement if there's input
        if (horizontalInput != 0)
        {
            rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            // Stop sliding when no input is given by applying ground friction
            rb.linearVelocity = new Vector2(Mathf.MoveTowards(rb.linearVelocity.x, 0, groundFriction * Time.deltaTime), rb.linearVelocity.y);
        }
    }
}
