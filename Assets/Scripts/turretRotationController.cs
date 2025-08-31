using UnityEngine;

public class turretRotationController : MonoBehaviour
{
    [SerializeField] private Transform player; // Assign this in the inspector
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
        float angleRad = Mathf.Atan2(direction.y, direction.x);
        float angleDeg = angleRad * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angleDeg);
        Debug.DrawLine(transform.position, player.position, Color.red, Time.deltaTime);

        // Optional flipping logic, if needed (like flipping the cannon sprite)
        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1, -1, 1); // Flip vertically
        }
    }
}
