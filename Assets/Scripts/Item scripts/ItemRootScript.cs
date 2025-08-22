using UnityEngine;

public abstract class ItemRootScript : MonoBehaviour
{
    abstract public void OnPickup(GameObject player);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPickup(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnPickup(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
