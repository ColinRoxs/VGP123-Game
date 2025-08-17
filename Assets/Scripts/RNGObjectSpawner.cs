using UnityEngine;

public class RNGObjectSpawner : MonoBehaviour
{
    public int RNG; 
    public GameObject ChestLow;
    public GameObject ChestHigh;
    public GameObject ChestMid;
    public GameObject ChestVeryHigh;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int myRandomInt = Random.Range(1, 3);
        RNG = myRandomInt;

        if (RNG == 1)
        {
            Instantiate(ChestLow, transform.position,transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChestGen()
    {

    }
}
