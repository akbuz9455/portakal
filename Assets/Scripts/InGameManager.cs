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
    public SplineFollower splineFollower;
    public GameObject inGameCam;
    public GameObject outGameCam;
    public GameObject refCamPoint;
    public int puan;

    private void Awake()
    {
     //   Application.targetFrameRate = 30;
        Instance = this;
        firstLoadGameData();
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
