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
     
    }

}
