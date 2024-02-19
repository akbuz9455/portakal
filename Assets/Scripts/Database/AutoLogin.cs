using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;
using System.Text.RegularExpressions;

public class AutoLogin : MonoBehaviour
{
    public bool loginCheck;
    public static AutoLogin Instance;
    public bool loginLoading;
    public string k_adi_giris_public;
    public string sifre_giris_public;
    private void Awake()
    {
        loginLoading = false;
        UniRESTClient.debugMode = true;
        _ = UniRESTClient.Async.Login("test7594", "pass4388", (bool ok) =>
        {
            if (ok)
            {
                Debug.Log("Servere Baðlandý");
                FirstLogin();
                PlayerPrefs.SetInt("ServerStatus", 1);

               
                    loginCheck=true; 
               

              
            }
            else
            {
                PlayerPrefs.SetInt("ServerStatus", 0);
                Debug.LogError("Servere Baðlanamadý !!");
            }
        });
    }
   
    public void FirstLogin()
    {
       

        k_adi_giris_public= CanvasManager.instance.kullaniciAdi.text;
        sifre_giris_public = CanvasManager.instance.sifre.text;

        if (loginCheck && loginLoading==false)
             {
            loginLoading = true;
            Invoke("login",.1f);
            }
        
      
      
    }
  
    private void login()
    {

        var result = UniRESTClient.Async.Read(
        API.userLogin_firstLogin,
        new DB.Kullanicilar { kullaniciAdi = CanvasManager.instance.RemoveInvisibleCharacters(k_adi_giris_public).ToLower(), Sifre = CanvasManager.instance.RemoveInvisibleCharacters(sifre_giris_public)},
        (DB.Kullanicilar[] results) =>
        {
            if (results.Length > 0)
            {
                Debug.Log("Manuel Giriþ Baþarili");
                loginLoading = false;

            }
            else
            {
                Debug.Log("Manuel Giriþ Baþarisiz");
                loginLoading = false;
            }
        }
    );
  }






}
