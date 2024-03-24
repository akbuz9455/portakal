using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceTrigger : MonoBehaviour
{
    public bool isBaslangic;
    public bool isOrta;
    public int level;



    private void OnTriggerEnter(Collider other)
    {
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
                    InGameManager.Instance.splineFollower.wrapMode = Dreamteck.Splines.SplineFollower.Wrap.Loop;
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
                else
                {
                    PerformanceManager.Instance.level2DevamGo();

                }

            }
        }
    }

}
