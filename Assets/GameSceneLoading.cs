using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneLoading : MonoBehaviour
{
    // Ýlerleme çubuðu
    public GameObject loadingBar;

    void Start()
    {
        // Yükleme iþlemini baþlat
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        // Yükleme iþlemini baþlat
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GamePlay");

        // Yükleme iþlemi tamamlanana kadar devam et
        while (!asyncLoad.isDone)
        {
            // Ýlerleme çubuðunu güncelle
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f); // 0 ile 1 arasýnda deðer alýr
            loadingBar.transform.localScale = new Vector3(progress, loadingBar.transform.localScale.y, loadingBar.transform.localScale.z);

            yield return null;
        }
    }
}
