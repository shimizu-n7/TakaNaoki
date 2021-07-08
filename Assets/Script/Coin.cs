using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class  Coin  : MonoBehaviour
{
    CoinManager CM;
    Text textCoin;




    // Start is called before the first frame update
    void Start()
    {
        CM = GameObject.Find("CoinManager").GetComponent<CoinManager>();
        textCoin = CM.coinText;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Zombie")
        {
            CM.coinCount += 1;
            textCoin.text = CM.coinCount.ToString();
            Destroy(this.gameObject, 0.2f);
        }
    }
}
