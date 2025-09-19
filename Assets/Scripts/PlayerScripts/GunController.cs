using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform barrelTransform;
    public float projectileSpeed = 200f;

    public AudioClip shootSound;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
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

        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
        else
        {
            Debug.LogWarning("No shoot sound assigned!");
        }

        //Rigidbody rb = projectile.GetComponent<Rigidbody>();
        //if (rb != null )
        //{
        //    rb.linearVelocity = barrelTransform.right * projectileSpeed;
        //}
    }
}
