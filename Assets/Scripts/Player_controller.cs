using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (!rb) rb = GetComponent<Rigidbody2D>();
        if (!spriteRenderer) spriteRenderer = GetComponent<SpriteRenderer>();
        if (!animator) animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // Get horizontal input (left/right movement)
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Set player velocity
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        // Flip sprite based on input direction
        if (horizontalInput > 0 && spriteRenderer.flipX)
        {
            spriteRenderer.flipX = false; // Flip sprite to face right
        }
        else if (horizontalInput < 0 && !spriteRenderer.flipX)
        {
            spriteRenderer.flipX = true; // Flip sprite to face left
        }

        // Set the "IsRunning" parameter in the Animator based on player movement
        bool isRunning = horizontalInput != 0; // If player is moving, set IsRunning to true
        animator.SetBool("IsRunning", isRunning);  // Set the "IsRunning" parameter in the Animator
    }
}