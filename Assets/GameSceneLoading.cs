using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneLoading : MonoBehaviour
{
    // �lerleme �ubu�u
    public GameObject loadingBar;

    void Start()
    {
        // Y�kleme i�lemini ba�lat
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        // Y�kleme i�lemini ba�lat
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GamePlay");

        // Y�kleme i�lemi tamamlanana kadar devam et
        while (!asyncLoad.isDone)
        {
            // �lerleme �ubu�unu g�ncelle
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f); // 0 ile 1 aras�nda de�er al�r
            loadingBar.transform.localScale = new Vector3(progress, loadingBar.transform.localScale.y, loadingBar.transform.localScale.z);

            yield return null;
        }
    }
}
