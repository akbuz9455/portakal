using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceTrigger : MonoBehaviour
{
    public bool isBaslangic;
    public bool isOrta;
    public bool isOrtaDevam;
    public int level;

    public bool loopActive;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && loopActive)
        {
            InGameManager.Instance.splineFollower.wrapMode = Dreamteck.Splines.SplineFollower.Wrap.Loop;

        }
        else if (other.tag == "Player" && !loopActive)
        {
            InGameManager.Instance.splineFollower.wrapMode = Dreamteck.Splines.SplineFollower.Wrap.Default;

        }
        if (other.tag == "Player")
        {
            if (level==1)
            {
                if (isBaslangic)
                {
                    PerformanceManager.Instance.level1Start();
                }
               else if (isOrta)
                {
                    PerformanceManager.Instance.level1Orta();

                }
                else
                {
                    PerformanceManager.Instance.level1devamGo();
                }

            }
            else if (level == 2)
            {
                if (isBaslangic)
                {
                    PerformanceManager.Instance.level2Start();


                }
                else if (isOrta)
                {
                    PerformanceManager.Instance.level2Orta();
                }
                else if (isOrtaDevam)
                {
                    PerformanceManager.Instance.level2OrtaDevam();
                    PerformanceManager.Instance.level3Start();
                }
                else
                {
                    PerformanceManager.Instance.level2DevamGo();

                }

            }
            else if (level==3)
            {
               
                if (isBaslangic)
                {
                    PerformanceManager.Instance.level3GirisGo();
                }
                if (isOrta)
                {
                    PerformanceManager.Instance.level2Stop();
                }
            }
            else if (level==4)
            {
                if (!isBaslangic)
                {
                    PerformanceManager.Instance.level3Kapat();
                }

            }
        }
    }

}
