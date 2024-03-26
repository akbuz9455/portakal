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

    [SerializeField]
    public SplineMesh yol1altinsplinemesh;
    public List<Transform> yolAltin;


    public List<GameObject> engelSave;
    public List<GameObject> goldSave;

    public GameObject engelSaveParentLevel1;
    public GameObject goldSaveParentLevel1;

    public float rightOffSet;
    public float leftOffSet;
    public float upOffSetForGold;

    private void Awake()
    {
        
      
        Instance = this;
        firstLoadGameData();
        Application.targetFrameRate = 60;

    }

    private void Start()
    {
          //yolengelorta = yol1engelsplinemesh.GetChannelMeshTransforms(0);
        // yolengelsol = yol1engelsplinemesh.GetChannelMeshTransforms(1);
         //yolengelsag = yol1engelsplinemesh.GetChannelMeshTransforms(2);

     //   YerlestirVeAktifDurumuAyarla(yolengelorta);
       // YerlestirVeAktifDurumuAyarla(yolengelsag, 1);
       // YerlestirVeAktifDurumuAyarla(yolengelsol, 2);

        //        yolAltin = yol1altinsplinemesh.GetChannelMeshTransforms(0);
        //      YerlestirVeAktifDurumuAyarla(yolAltin,0,true);
        //    YerlestirVeAktifDurumuAyarla(yolAltin, 1, true);
        //  YerlestirVeAktifDurumuAyarla(yolAltin, 2, true);


    }

    void YerlestirVeAktifDurumuAyarla(List<Transform> engel, int localPos = 0, bool isGold = false)
    {
        foreach (var engelTransform in engel)
        {
            GameObject engelObjesi;
            if (isGold == true)
            {
                engelObjesi = GetKullanilmayanAltin();
            }
            else
            {
                engelObjesi = GetKullanilmayanEngel();
            }

            if (engelObjesi != null) // E?er kullan?labilir bir engel varsa
            {

                if (localPos == 0)
                {
                    engelObjesi.transform.position = engelTransform.localPosition;
                    engelObjesi.transform.rotation = engelTransform.rotation;
                }
                else if (localPos == 1) //right
                {
                    engelObjesi.transform.position = engelTransform.localPosition + engelTransform.transform.right * rightOffSet;
                    engelObjesi.transform.rotation = engelTransform.rotation;
                }
                else if (localPos == 2)//left
                {
                    engelObjesi.transform.position = engelTransform.localPosition + engelTransform.transform.right * leftOffSet;
                    engelObjesi.transform.rotation = engelTransform.rotation;

                }

                engelObjesi.SetActive(true);
                if (isGold)
                {
                    //engelObjesi.transform.position = engelTransform.position + (engelTransform.transform.up * upOffSetForGold);
                }
                if (isGold)
                {
                    //engelObjesi.transform.position = engelTransform.position + (engelTransform.transform.up * upOffSetForGold);

                }





            }
            if (isGold)
            {
                goldSave.Add(engelObjesi);
                if (engelObjesi != null)
                {
                    engelObjesi.transform.SetParent(goldSaveParentLevel1.transform);

                }
            }
            else
            {
                engelSave.Add(engelObjesi);
                if (engelObjesi != null)
                {
                    engelObjesi.transform.SetParent(engelSaveParentLevel1.transform);

                }
            }




        }
    }
    GameObject GetKullanilmayanAltin()
    {

        foreach (var coin in poolManager.altin)
        {
            if (!coin.activeInHierarchy) // E?er engel aktif de?ilse, kullan?lmayan bir engeldir
            {
                return coin; // Bu engeli d?nd?r
            }
        }


        Debug.Log("Tekrar Engel Arand?");
        return null; // E?er t?m engeller kullan?l?yorsa, null d?nd?r
    }

    GameObject GetKullanilmayanEngel()
    {
        int rdmEngel = Random.Range(0, 11);
        if (rdmEngel > -1 && rdmEngel <= 3)
        {
            foreach (var engel in poolManager.engelNo1)
            {
                if (!engel.activeInHierarchy) // E?er engel aktif de?ilse, kullan?lmayan bir engeldir
                {
                    return engel; // Bu engeli d?nd?r
                }
            }
        }
        else if (rdmEngel > 3 && rdmEngel <= 6)
        {
            foreach (var engel in poolManager.engelNo2)
            {
                if (!engel.activeInHierarchy) // E?er engel aktif de?ilse, kullan?lmayan bir engeldir
                {
                    return engel; // Bu engeli d?nd?r
                }
            }
        }
        else if (rdmEngel > 6 && rdmEngel <= 9)
        {
            foreach (var engel in poolManager.engelNo3)
            {
                if (!engel.activeInHierarchy) // E?er engel aktif de?ilse, kullan?lmayan bir engeldir
                {
                    return engel; // Bu engeli d?nd?r
                }
            }
        }
        else if (rdmEngel > 9)
        {
            foreach (var engel in poolManager.engelNo4Agac)
            {
                if (!engel.activeInHierarchy) // E?er engel aktif de?ilse, kullan?lmayan bir engeldir
                {
                    return engel; // Bu engeli d?nd?r
                }
            }
        }

        Debug.Log("Tekrar Engel Arand?");
        return GetKullanilmayanEngel(); // E?er t?m engeller kullan?l?yorsa, null d?nd?r
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
