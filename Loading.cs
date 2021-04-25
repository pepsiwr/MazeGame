using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public GameObject loading;
    public Slider slider;
    public Text progressText;
    public void Loader(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loading.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f); //0.0 - 0.0=9 คือการโหลด แต่ 0.9-1.0 คือ Activation(การเปิดใช้งาน)

            slider.value = progress;
            progressText.text = progress * 100 + "%";

            yield return null;
        }
    }
}
