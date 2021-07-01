using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawnerScript : MonoBehaviour
{

    public GameObject zombiePrefab;
    public  int zombieCount = 0;
    public Text zombieText;

    // Start is called before the first frame update
    void Start()
    {
        zombieText.text = zombieCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") == true)
        {
            Instantiate(zombiePrefab, this.transform.position + this.transform.right * Random.Range( -20f, 20.0f), this.transform.rotation);
            PlusZombie();
        }
    }

    public void PlusZombie()
    {
        zombieCount += 1;
        zombieText.text = zombieCount.ToString(); 
    }

}
