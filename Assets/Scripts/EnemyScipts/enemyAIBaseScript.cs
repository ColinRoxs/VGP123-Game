using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Collider2D))]
//[RequireComponent(typeof(Animator))]
public class enemyAIBaseScript : MonoBehaviour
{
    [SerializeField] private float groundCheckRadius = 0.02f;

    public Transform player;
    public float stopDistance = 2f;
    public float moveSpeed = 3f;

    [SerializeField] private bool isMelee =false;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Collider2D col;

    private LayerMask groundLayer;
    [SerializeField] private bool isGrounded = false;

    private Vector2 groundCheckPos;

    [SerializeField] private int maxJumpCount = 1;
    private int jumpCount = 0;

    Vector2 GetGroundCheckPos()
    {
        return new Vector2(col.bounds.min.x + col.bounds.extents.x, col.bounds.min.y);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float deltaX = player.position.x - transform.position.x;
        float absX = Mathf.Abs(deltaX);

        // Flip sprite based on direction
        sr.flipX = deltaX < 0;

        if(absX < stopDistance)
        {
            rb.linearVelocityX = -Mathf.Sign(deltaX) * moveSpeed;
        }
        else
        {
            rb.linearVelocityX = Mathf.Sign(deltaX) * moveSpeed;
        }

        // Move only in X direction using linearVelocityX
        //if (absX > stopDistance)
        //{
        //    rb.linearVelocityX = Mathf.Sign(deltaX) * moveSpeed;
        //}
        //else
        //{
        //    rb.linearVelocityX = 0f;
        //}

        stopDistance = isMelee ? 2f : 10f;

        Debug.Log($"{gameObject.name} isMelee: {isMelee}, stopDistance set to: {stopDistance}");
    }
}
