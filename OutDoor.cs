using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutDoor : MonoBehaviour
{
    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(CoinData.Coin == 3)
            {
                SceneManager.LoadScene("Victory");
                Cursor.lockState = CursorLockMode.None; //ให้เม้ากลับมาปกติไม่ล็อคไว้
                
            }
        }
    }
}
