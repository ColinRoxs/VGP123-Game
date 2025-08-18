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

    private void FixedUpdate()
    {
        if (target == null) return;

        Vector3 targetPosition = target.position + offset;

        // Z position lock to retain sidescrolling camera despite needing vec3 movement
        targetPosition.z = transform.position.z;

        if (Input.GetMouseButton(1))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = transform.position.z;

            Vector3 aimDirection = (mouseWorldPos - target.position).normalized;
            Vector3 aimShift = aimDirection * aimShiftStrength;
            targetPosition += aimShift;
        }

        float distance = Vector3.Distance(transform.position, targetPosition);
        float dynamicDamping = Mathf.Clamp(baseSpeed + distance * damping, baseSpeed, maxSpeed);

        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, damping);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, 1f / dynamicDamping);
    }
}
