using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;
using TMPro;



public class UserManager : MonoBehaviour
{
    public void UserRegister()
    {

        var result = UniRESTClient.Async.Write(
     API.userLogin_firstLogin,
     new DB.Kullanicilar
     {
         id = UniRESTClient.UserID,
         kullaniciAdi = CanvasManager.instance.RemoveInvisibleCharacters(CanvasManager.instance.kayitKullaniciAdi.text.ToString().ToLower()),
         Sifre = CanvasManager.instance.RemoveInvisibleCharacters(CanvasManager.instance.kayitSifre.text.ToString().ToLower())
     },
     (bool ok) =>
     {
         if (ok)
         {
             Debug.Log("Written! Record ID: " + UniRESTClient.DBresponse);
         }
         else
         {
             Debug.Log("Writing failed");
         }
     }
);

    }
}
