using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public int increaseCoin;
    public Text CoinText;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            CoinData.Coin += increaseCoin;
            CoinText.text = CoinData.Coin.ToString();
            Destroy(gameObject);
        }
    }
}
