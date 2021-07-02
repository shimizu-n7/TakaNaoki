using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSpawnerScript : MonoBehaviour
{
    int interval = 0;
    public ZombieSpawnerScript zombieCount;
    int realzombieCount;
    int newInterval = 0;
    public GameObject coinPrefabs;


    // Start is called before the first frame update
    void Start()
    {
        realzombieCount = zombieCount.zombieCount;
    }

    // Update is called once per frame
    void Update()
    {
        interval +=  1;
        newInterval = interval + realzombieCount ;
        if ( newInterval  > 10000)
        {
            Instantiate(coinPrefabs, this.transform.position + this.transform.right *  Random.Range(0f,  40.0f), this.transform.rotation );
            interval = 0; 
        }
    }  
}
