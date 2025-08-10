using UnityEngine;

public class ArmRotationController : MonoBehaviour
{
    private Camera cam;
    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad - 0;

        transform.rotation = Quaternion.Euler(0f, 0f, angleDeg);
        Debug.DrawLine(transform.position, mousePos, Color.white, Time.deltaTime);

        if (mousePos.x > transform.position.x)
        {
            //sr.flipY = false;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (mousePos.x < transform.position.x)
        {
            //sr.flipY = true;
            transform.localScale = new Vector3(1, -1, 1);
        }

    }

    void HandFlip ()
    {

    }
}
