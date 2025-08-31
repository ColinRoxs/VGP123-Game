using UnityEngine;

public class TurretGunController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform barrelTransform;
    public float projectileSpeed = 200f;

    public Transform player;
    public float range = 10f;

    public float fireRate = 1f;
    public float fireCooldown = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        fireCooldown -= Time.deltaTime;

        if (distanceToPlayer <= range && fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = fireRate;
        }
    }

    // Update is called once per frame
    void Shoot()
    {
        if (projectilePrefab == null || barrelTransform == null)
        {
            Debug.LogWarning("Projectile or Barrel transform not set.");
            return;
        }

        GameObject projectile = Instantiate(projectilePrefab, barrelTransform.position, barrelTransform.rotation);
    }
}