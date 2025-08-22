using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Collider2D))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float groundCheckRadius = 0.02f; 

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Collider2D col;
    private Animator anim;

    private LayerMask groundLayer;
    [SerializeField] private bool isGrounded = false;

    private Vector2 groundCheckPos;

    [SerializeField] private int maxJumpCount = 1;
    private int jumpCount = 0;
    private float baseMoveSpeed = 10f;
    private float currentMoveSpeed;

    //Item Integers
    private int T3MovementWings = 0;

    Vector2 GetGroundCheckPos()
    {
        return new Vector2(col.bounds.min.x + col.bounds.extents.x, col.bounds.min.y);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();

        groundLayer = LayerMask.GetMask("GroundColliderLayer");

        if (groundLayer == 0)
        {
            Debug.LogWarning("Ground layer not set. Please set the Ground layer in LayerMask.");
        }

        currentMoveSpeed = baseMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float hValue = Input.GetAxisRaw("Horizontal");
        SpriteFlip(hValue);

        groundCheckPos = GetGroundCheckPos();

        rb.linearVelocityX = hValue * currentMoveSpeed; //adjust mult as nessesary

        if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
        {
            rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse); //Adjust force as necessary
            jumpCount++;
        }
        isGrounded = Physics2D.OverlapCircle(groundCheckPos, groundCheckRadius, groundLayer);
        if (isGrounded) 
        {
            jumpCount = 0;
        }

        //Update animations
        anim.SetFloat("hValue", Mathf.Abs(hValue));
        anim.SetBool("Grounded", isGrounded = true);


    }

    void SpriteFlip(float hValue) //Sprite flipper, might make redundant or modify to make sprite flip to mouse cursor.
    {
        if ((hValue > 0 && sr.flipX) || (hValue < 0 && !sr.flipX))
            sr.flipX = !sr.flipX; // Flip sprite only when direction changes
    }

    public void T3wings()
    {
        T3MovementWings++;
        currentMoveSpeed = baseMoveSpeed * (1f + 0.1f * T3MovementWings);
        Debug.Log($"Item picked up! total: {T3MovementWings}. New Speed: {currentMoveSpeed}");
    }
}
