using Cysharp.Threading.Tasks;
using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
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
     //   Application.targetFrameRate = 30;
        Instance = this;
        firstLoadGameData();

    }
    private void Start()
    {
        yolengelorta = yol1engelsplinemesh.GetChannelMeshTransforms(0);
        yolengelsol = yol1engelsplinemesh.GetChannelMeshTransforms(1);
        yolengelsag = yol1engelsplinemesh.GetChannelMeshTransforms(2);

        OffSetForEnemy(yolengelsol,leftOffSet);
        OffSetForEnemy(yolengelsol, rightOffSet);

        YerlestirVeAktifDurumuAyarla(yolengelsol);
        YerlestirVeAktifDurumuAyarla(yolengelsag);
        YerlestirVeAktifDurumuAyarla(yolengelorta);

    }

    void OffSetForEnemy(List<Transform> ofsetObj,float offSet)
    {

        foreach (var item in ofsetObj)
        {
            Debug.Log("item transfer position :"+item.transform.position);
            item.transform.localPosition=item.transform.localPosition + item.transform.right * offSet;
            Debug.Log("item new transfer position :" + item.transform.position);
        }
    }

    void YerlestirVeAktifDurumuAyarla(List<Transform> engel)
    {
        foreach (var engelTransform in engel)
        {
            GameObject engelObjesi = GetKullanilmayanEngel();
            if (engelObjesi != null) // Eðer kullanýlabilir bir engel varsa
            {
                engelObjesi.transform.position = engelTransform.localPosition;
                engelObjesi.transform.rotation = engelTransform.rotation;
                engelObjesi.SetActive(true);
            }
        }
    }

    GameObject GetKullanilmayanEngel()
    {
        foreach (var engel in poolManager.engelNo1)
        {
            if (!engel.activeInHierarchy) // Eðer engel aktif deðilse, kullanýlmayan bir engeldir
            {
                return engel; // Bu engeli döndür
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
