
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void SahneyiDegistir(string sahneAdi)
    {
        SceneManager.LoadScene(sahneAdi); // Belirtilen sahneyi yükler
    }
}
