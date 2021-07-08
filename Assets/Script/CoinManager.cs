using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    
    //public Coin coin;
    public int coinCount;

    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "0";
 
    }

    // Update is called once per frame
    void Update()
    {
        //coinText.text = coinCount.ToString("f0");
    }
}
