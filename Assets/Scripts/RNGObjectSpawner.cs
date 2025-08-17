using UnityEngine;

public class RNGObjectSpawner : MonoBehaviour
{
    public int RNG; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int myRandomInt = Random.Range(1, 11);
        RNG = myRandomInt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
