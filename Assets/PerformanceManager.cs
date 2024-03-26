using UnityEngine;

public class PerformanceManager : MonoBehaviour
{
    [Header("Level1 Performance Objects")]
 
    public GameObject level1;
    public GameObject level1Road;
    public GameObject level1Giris;
    public GameObject level1GirisDevam1;
    public GameObject level1GirisDevam2;
    public GameObject level1GirisDevam3;




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

 


    public void level1AcKapat(bool isAcik)
    {
        level1.SetActive(isAcik);
        
    }
    public void level1StartAcKapat(bool isAcik)
    {
        level1Giris.SetActive(isAcik);
    }
    public void level1Devam1AcKapat(bool isAcik)
    {
        level1GirisDevam1.SetActive(isAcik);
    }

    public void level1Devam2AcKapat(bool isAcik)
    {
        level1GirisDevam2.SetActive(isAcik);
    }

    public void level1Devam3AcKapat(bool isAcik)
    {
        level1GirisDevam3.SetActive(isAcik);
    }


}
