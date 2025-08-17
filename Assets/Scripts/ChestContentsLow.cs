using UnityEngine;

public class ChestContentsLow : MonoBehaviour
{
    public int RNG;
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int myRandomInt = Random.Range(1, 6);
        RNG = myRandomInt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChestOpen()
    {
        if (RNG == 1)
        {
            Instantiate(Item1, transform.position, transform.rotation);
        }
        if (RNG == 2)
        {
            Instantiate(Item2, transform.position, transform.rotation);
        }
        if (RNG == 3)
        {
            Instantiate(Item3, transform.position, transform.rotation);
        }
        if (RNG == 5)
        {
            Instantiate(Item4, transform.position, transform.rotation);
        }
    }
}
