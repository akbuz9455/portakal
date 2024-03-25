using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceManager : MonoBehaviour
{
    public static PerformanceManager Instance;


    [Header("Level1 Performance Objects")]
    public GameObject level1Tamamý;
    public GameObject level1Giris;
    public GameObject level1Devam1;

    [Header("Level2 Performance Objects")]

    public GameObject level2Tamamý;
    public GameObject level2Giris;
    public GameObject level2Devam1;
    public GameObject level2Devam2;
    public GameObject level2Orta1;
  

    [Header("Level3 Performance Objects")]

    public GameObject level3Tamamý;
    public GameObject level3Giris;
    public GameObject level3Devam1;

    [Header("Level4 Performance Objects")]

    public GameObject level4Tamamý;
    public GameObject level4Giris;
    public GameObject level4Devam1;

    private void Start()
    {
        Instance = this;
    }
    public void level1devamGo()
    {
        level1Giris.SetActive(false);
        level1Devam1.SetActive(true);
      
 
    }

    public void level1OrtaGo()
    {
        level2Tamamý.SetActive(false);
    }

    public void level1Start()
    {
        level1Giris.SetActive(true);
        level1Devam1.SetActive(false);


        level2Tamamý.SetActive(true);
        level2Giris.SetActive(true);



    }

    public void level1Orta()
    {
         
        level2Tamamý.SetActive(false);
        

    }

    public void level2OrtaDevam()
    {

        level2Orta1.SetActive(true);
        level2Devam2.SetActive(false);


    }
    public void level2Start()
    {
        level2Tamamý.SetActive(true);
        level2Giris.SetActive(true);
        level2Devam1.SetActive(true);
   
    }
    public void level2Orta()
    {
        level2Giris.SetActive(false);
      
    }
    public void level2DevamGo()
    {
        level1Tamamý.SetActive(false);
        level2Tamamý.SetActive(true);
        level2Giris.SetActive(false);
        level2Devam1.SetActive(true);
    }

    public void level2Stop()
    {
        level2Tamamý.SetActive(false);
        level2Giris.SetActive(false);
        level2Devam1.SetActive(false);

    }


    public void level3Start()
    {
        level3Tamamý.SetActive(true);
   

    }
    public void level3GirisGo()
    {
        level3Giris.SetActive(true);
    }
    
}
