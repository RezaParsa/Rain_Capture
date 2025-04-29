using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float deceleration = 15f;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private float horizontalInput;
    private bool isFacingRight = true;

    private void Awake()
    {
        // Auto-get references if not set in Inspector
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        GetInput();
        HandleSpriteFlip();
    }

    private void FixedUpdate()
    {
        Move();
        
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void Move()
    {
        float targetVelocityX = horizontalInput * moveSpeed;
        float velocityX = Mathf.Lerp(rb.linearVelocity.x, targetVelocityX,
                                   (Mathf.Abs(targetVelocityX) > 0.01f ? acceleration : deceleration) * Time.fixedDeltaTime);

        rb.linearVelocity = new Vector2(velocityX, rb.linearVelocity.y);
    }

    private void HandleSpriteFlip()
    {
        if (horizontalInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        spriteRenderer.flipX = !isFacingRight;

        // Alternative if not using SpriteRenderer:
        // Vector3 scale = transform.localScale;
        // scale.x *= -1;
        // transform.localScale = scale;
    }
}