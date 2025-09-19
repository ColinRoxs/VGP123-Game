using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool hasBeenHit = false; // Prevent multiple hits from same attack

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyAttack") && !hasBeenHit)
        {
            hasBeenHit = true;
            TakeDamage(100); // Deal 1 damage (or whatever amount you want)
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyAttack"))
        {
            hasBeenHit = false; // Reset hit flag when attack leaves
        }
    }

    void TakeDamage(int amount)
    {
        GameManager.Instance.playerHealth -= amount;
        Debug.Log("Player Health: " + GameManager.Instance.playerHealth);

        if (GameManager.Instance.playerHealth <= 0)
        {
            GameManager.Instance.LoadGameOver();
        }
    }
}
