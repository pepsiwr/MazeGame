using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxAmmo : MonoBehaviour
{
    public  int increaseMaxAmmo;
    public  Text maxAmmoText;
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Gun.maxAmmo += increaseMaxAmmo;
            maxAmmoText.text = Gun.maxAmmo.ToString();
            Destroy(gameObject);


        }
    }*/
}
