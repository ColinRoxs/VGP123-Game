using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Collider2D))]
//[RequireComponent(typeof(Animator))]
public class enemyAIBaseScript : MonoBehaviour
{
    [SerializeField] private float groundCheckRadius = 0.02f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Collider2D col;

    public Transform player; //the player the enemy is targeting
    public float stopDistance = 2f; //didstance enemy will stop moving toward the player at
    [SerializeField] private float bufferZone = 0.5f; //buffer to stop enemy "vibrating" at the stop distance
    public float moveSpeed = 3f; //how fast the enemy moves at base

    [SerializeField] private bool isMelee =false; //Sets whether the enemy is a melee or not

    private LayerMask groundLayer;
    [SerializeField] private bool isGrounded = false;

    private Vector2 groundCheckPos;

    [SerializeField] private int maxJumpCount = 1;
    private int jumpCount = 0;

    [SerializeField] private float attackInterval = 2f; //the rate of attack the enemy will have
    private float attackTimer = 0f;

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

        float moveThresholdMin = stopDistance - bufferZone;
        float moveThresholdMax = stopDistance + bufferZone;

        if(absX < moveThresholdMin)
        {
            rb.linearVelocityX = -Mathf.Sign(deltaX) * moveSpeed;
        }
        else if(absX > moveThresholdMax) 
        {
            rb.linearVelocityX = Mathf.Sign(deltaX) * moveSpeed;
        }
        else
        {
            rb.linearVelocityX = 0f;
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
