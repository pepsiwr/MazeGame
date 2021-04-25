using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CRT_Scene : MonoBehaviour
{
    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
        CoinData.Coin = 0;
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
