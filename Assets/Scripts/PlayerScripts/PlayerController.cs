using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hValue = Input.GetAxisRaw("Horizontal");

        rb.linearVelocityX = hValue * 5f;

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
        }
    }
}
