using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private bool canOpenChest = false;
    private Animator chestAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chestAnimator = GetComponent<Animator>();
        if (chestAnimator == null )
        {
            Debug.LogWarning("Error! chest animator not present.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Player"))
        {
            canOpenChest=true;
        } 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canOpenChest=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpenChest && Input.GetKeyDown(KeyCode.E))
        {
            chestAnimator.SetTrigger("IsOpen");
            Debug.Log("E Pressed and can open chest!");
        }
    }
}
