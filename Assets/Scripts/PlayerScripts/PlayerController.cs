using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float hValue = Input.GetAxisRaw("Horizontal");
        SpriteFlip(hValue);

        rb.linearVelocityX = hValue * 5f; //adjust mult as nessesary

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse); //Adjust force as necessary
        }
    }

    void SpriteFlip(float hValue) //Sprite flipper, might make redundant or modify to make sprite flip to mouse cursor.
    {
        if ((hValue > 0 && sr.flipX) || (hValue < 0 && !sr.flipX))
            sr.flipX = !sr.flipX; // Flip sprite only when direction changes
    }
}
