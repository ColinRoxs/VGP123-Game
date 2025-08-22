using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;
    [SerializeField] private float baseSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float aimShiftStrength;


    public Transform target;

    private Vector3 vel = Vector3.zero;

    private void Start()
    {
        SpriteRenderer sr = target.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            offset.y = sr.bounds.size.y / 2f;
        }
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        Vector3 targetPosition = target.position + offset;

        // Z position lock to retain sidescrolling camera when not aiming
        targetPosition.z = transform.position.z;

        if (Input.GetMouseButton(1))
        {
            Vector3 mouseScreenPos = Input.mousePosition;
            mouseScreenPos.z = Camera.main.transform.position.z * -1f; // Convert camera depth to positive distance

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            mouseWorldPos.z = target.position.z; // Lock Z for 2D

            //Vector3 aimDirection = (mouseWorldPos - target.position).normalized;
            //Vector3 aimShift = aimDirection * aimShiftStrength;
            //targetPosition += aimShift;

            Vector3 aimOffset = mouseWorldPos - target.position;
            float aimDistance = Mathf.Clamp(aimOffset.magnitude, 0f, 10f);

            Vector3 aimDirection = aimOffset.normalized;
            Vector3 aimShift = aimDirection * aimDistance * aimShiftStrength;
            targetPosition += aimShift;

            Debug.Log($"AimOffset: {aimOffset}, AimDistance {aimDistance}, AimShift: {aimShift}");
        }

        float distance = Vector3.Distance(transform.position, targetPosition);
        float dynamicDamping = Mathf.Clamp(baseSpeed + distance * damping, baseSpeed, maxSpeed);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, 1f / dynamicDamping);
    }
}
