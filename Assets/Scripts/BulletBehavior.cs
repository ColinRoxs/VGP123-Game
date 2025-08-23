using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public LayerMask groundLayer;
    public float offscreenThreshold = -20f;
    public float force = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * force, ForceMode2D.Impulse);
        groundLayer = LayerMask.GetMask("GroundColliderLayer");
    }
    // Update is called once per frame
    void Update()
    {
        CheckOffScreen();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collision with: {collision.gameObject.name}, Layer: {collision.gameObject.layer}");

        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            Destroy(gameObject);
        }

    }

    void CheckOffScreen()
    {
        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);

        // Ignore if behind camera
        if (screenPos.z < 0)
            return;

        // Destroy only if well outside screen
        if (screenPos.x < -0.2f || screenPos.x > 1.2f || screenPos.y < -0.2f || screenPos.y > 1.2f)
        {
            Destroy(gameObject);
        }

        Debug.Log($"World Position: {transform.position}, Viewport Position: {screenPos}");
    }
}
