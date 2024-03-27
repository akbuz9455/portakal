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

    public GameObject level2;
    public GameObject level2Giris;
    public GameObject level2Devam1;
    public GameObject level2Devam2;
    public GameObject level2Devam3;


    [Header("Level3 Performance Objects")]

    public GameObject level3;
    public GameObject level3Giris;
    public GameObject level3Devam1;
    public GameObject level3Devam2;
    public GameObject level3Devam3;

    [Header("Level4 Performance Objects")]

    public GameObject level4;
    public GameObject level4Giris;
    public GameObject level4Devam1;
    public GameObject level4Devam2;
    public GameObject level4Devam3;



    public void levelgecis(int level)
    {
        if (InGameManager.Instance.isNewMap)
        {
            if (level==1)
            {
                level2AcKapat(true);
                level2StartAcKapat(true);
            }
            else if (level==2)
            {

            }
        }
        else
        {

            if (level==1)
            {
                level1Devam1AcKapat(false);
                level1Devam2AcKapat(false);
                level1Devam2AcKapat(false);
            }
        

        }

    }

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



    public void level2AcKapat(bool isAcik)
    {
        level2.SetActive(isAcik);

    }
    public void level2StartAcKapat(bool isAcik)
    {
        level2Giris.SetActive(isAcik);
    }
    public void level2Devam1AcKapat(bool isAcik)
    {
        level2Devam1.SetActive(isAcik);
    }

    public void level2Devam2AcKapat(bool isAcik)
    {
        level2Devam2.SetActive(isAcik);
    }

    public void level2Devam3AcKapat(bool isAcik)
    {
        level2Devam3.SetActive(isAcik);
    }


    public void level3AcKapat(bool isAcik)
    {
        level3.SetActive(isAcik);

    }
    public void level3StartAcKapat(bool isAcik)
    {
        level3Giris.SetActive(isAcik);
    }
    public void level3Devam1AcKapat(bool isAcik)
    {
        level3Devam1.SetActive(isAcik);
    }

    public void level3Devam2AcKapat(bool isAcik)
    {
        level3Devam2.SetActive(isAcik);
    }

    public void level3Devam3AcKapat(bool isAcik)
    {
        level3Devam3.SetActive(isAcik);
    }


    public void level4AcKapat(bool isAcik)
    {
        level4.SetActive(isAcik);

    }

    public void level3GirisAcKapat(bool isAcik)
    {

        level3Giris.SetActive(isAcik);
    }


}
