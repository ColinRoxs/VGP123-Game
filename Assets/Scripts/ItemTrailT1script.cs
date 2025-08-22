using UnityEngine;

public class ItemTrailT1script : MonoBehaviour
{
    private LayerMask groundLayer;
    public int RNG;
    public GameObject Item1;

    private bool hasLanded = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
        groundLayer = LayerMask.GetMask("GroundColliderLayer");

        if (groundLayer == 0)
        {
            Debug.LogWarning("Ground layer not set. Please set the Ground layer in LayerMask.");
        }

        int myRandomInt = Random.Range(1, 2);
        RNG = myRandomInt;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasLanded && ((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            hasLanded = true;

            if (Item1 != null)
            {
                Instantiate(Item1, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
