using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject loaderUI;
    public Slider prosesSlider;

    public void LoadScene (int index)
    {
        StartCoroutine(LoadScene_Coroutine(index));
    }

    public IEnumerator LoadScene_Coroutine(int index)
    {
        prosesSlider.value = 0;
        loaderUI.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        asyncOperation.allowSceneActivation = false;
        float proses = 0;

        while (!asyncOperation.isDone)
        {
            proses = Mathf.MoveTowards(proses, asyncOperation.progress, Time.deltaTime);
            prosesSlider.value = proses;
            if(proses >= 0.9f)
            {
                prosesSlider.value = 1;
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }        
    }
}
