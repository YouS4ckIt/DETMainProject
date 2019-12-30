using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingSlider;
    public TMP_Text progressText;


    public void LoadLevel(int sceneIndex)
    {


        StartCoroutine(LoadAsynchrously(sceneIndex));



    }


    IEnumerator LoadAsynchrously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingSlider.value = progress;
            Debug.Log(progress);
            progressText.text = progress * 100F + "%";
            yield return null;
        }

    }

}
