using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance;
    public bool start;
    public bool gameover;
    public AnimationManager animationManager;
    public CharacterManager characterManager;
    public MagnetSystem magnetSystem;
    public SplineFollower splineFollower;
    public PoolManager poolManager;
    public GameObject inGameCam;
    public GameObject outGameCam;
    public GameObject refCamPoint;
    public int puan;

    //Mesh data
    [SerializeField]
    public SplineMesh yol1engelsplinemesh;
    public List<Transform> yolengelsol;
    public List<Transform> yolengelorta;
    public List<Transform> yolengelsag;
    public float rightOffSet;
    public float leftOffSet;

    private void Awake()
    {
       Application.targetFrameRate = 30;
        Instance = this;
        firstLoadGameData();

    }
    private void Start()
    {
       
    }

    void YerlestirVeAktifDurumuAyarla(List<Transform> engel,int localPos=0)
    {
        foreach (var engelTransform in engel)
        {
          
            GameObject engelObjesi = GetKullanilmayanEngel();
            if (engelObjesi != null) // Eðer kullanýlabilir bir engel varsa
            {
              
                if (localPos==0)
                {
                    engelObjesi.transform.position = engelTransform.localPosition;
                    engelObjesi.transform.rotation = engelTransform.rotation;
                }
                else if (localPos==1) //right
                {
                    engelObjesi.transform.position = engelTransform.localPosition + engelTransform.transform.right * rightOffSet;
                    engelObjesi.transform.rotation = engelTransform.rotation;
                }
                else if (localPos==2)//left
                {
                    engelObjesi.transform.position = engelTransform.localPosition + engelTransform.transform.right * leftOffSet;
                    engelObjesi.transform.rotation = engelTransform.rotation;

                }
                engelObjesi.SetActive(true);
            }
       

           

        }
    }

    GameObject GetKullanilmayanEngel()
    {
        int rdmEngel = Random.Range(0,4);
        if (rdmEngel==0)
        {
            foreach (var engel in poolManager.engelNo1)
            {
                if (!engel.activeInHierarchy) // Eðer engel aktif deðilse, kullanýlmayan bir engeldir
                {
                    return engel; // Bu engeli döndür
                }
            }
        }
        else if (rdmEngel == 1)
        {
            foreach (var engel in poolManager.engelNo2)
            {
                if (!engel.activeInHierarchy) // Eðer engel aktif deðilse, kullanýlmayan bir engeldir
                {
                    return engel; // Bu engeli döndür
                }
            }
        }
        else if (rdmEngel == 2)
        {
            foreach (var engel in poolManager.engelNo3)
            {
                if (!engel.activeInHierarchy) // Eðer engel aktif deðilse, kullanýlmayan bir engeldir
                {
                    return engel; // Bu engeli döndür
                }
            }
        }
        else if (rdmEngel == 3)
        {
            foreach (var engel in poolManager.engelNo4Agac)
            {
                if (!engel.activeInHierarchy) // Eðer engel aktif deðilse, kullanýlmayan bir engeldir
                {
                    return engel; // Bu engeli döndür
                }
            }
        }
        return null; // Eðer tüm engeller kullanýlýyorsa, null döndür
    }
    public void firstLoadGameData()
    {
        animationManager.GoIdle();

    }
    public void EndGame() {
        gameover = true;
        animationManager.GoFail();


    }
    public void startGame()
    {
        start = true;
        splineFollower.followSpeed = 10;
        animationManager.GoRun();
    }
}
