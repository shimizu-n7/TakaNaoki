using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnerScript : MonoBehaviour
{
    int interval = 0;
    public GameObject coinPrefabs;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interval += 1;
        if (interval % 120  == 0)
        {
            Instantiate(coinPrefabs, this.transform.position + this.transform.right *  Random.Range(0f,  40.0f), this.transform.rotation ); 
        }
    }
}
