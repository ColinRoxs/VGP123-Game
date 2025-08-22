using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private bool canOpenChest = false;
    private Animator chestAnimator;

    public int RNG;
    public Transform itemSpawnPoint;
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    public float spawnForce = 300f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chestAnimator = GetComponent<Animator>();
        if (chestAnimator == null )
        {
            Debug.LogWarning("Error! chest animator not present.");
        }

        int myRandomInt = Random.Range(1, 2);
        RNG = myRandomInt;
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

    public void ChestOpen()
    {
        GameObject spawnedItem = null;

        if (RNG == 1)
        {
            spawnedItem = Instantiate(Item1, itemSpawnPoint.position, Quaternion.identity);
        }
        if (RNG == 2)
        {
            spawnedItem = Instantiate(Item2, itemSpawnPoint.position, Quaternion.identity);
        }
        if (RNG == 3)
        {
            spawnedItem = Instantiate(Item3, itemSpawnPoint.position, Quaternion.identity);
        }
        if (RNG == 4)
        {
            spawnedItem = Instantiate(Item4, itemSpawnPoint.position, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (canOpenChest && Input.GetKeyDown(KeyCode.E))
        {
            chestAnimator.SetTrigger("IsOpen");
            Debug.Log("E Pressed and can open chest!");
            ChestOpen();
        }
    }

}
