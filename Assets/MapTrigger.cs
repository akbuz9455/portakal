using Dreamteck.Splines;
using UnityEngine;

public class MapTrigger : MonoBehaviour
{
    public bool isNewMap;
    public bool isLoopMap;
    public int mapLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isNewMap)
        {
            InGameManager.Instance.isNewMap = true;
            InGameManager.Instance.splineFollower.wrapMode = SplineFollower.Wrap.Default;
           
        }
        if (other.tag == "Player" && isLoopMap)
        {
            InGameManager.Instance.isNewMap = false;
            InGameManager.Instance.splineFollower.wrapMode = SplineFollower.Wrap.Loop;

        }
       
      switch (mapLevel)
        {
            case 1:
                Debug.Log("gecis 1");
                InGameManager.Instance.level1.bridges[0].active = InGameManager.Instance.isNewMap; 
                
                break;
            case 2:
                
                Debug.Log("gecis 2");
                InGameManager.Instance.level2.bridges[0].active = InGameManager.Instance.isNewMap;

                break;
            case 3:
                
                Debug.Log("gecis 3");
                InGameManager.Instance.level3.bridges[0].active = InGameManager.Instance.isNewMap;

                break;
            case 4:
                
                Debug.Log("gecis 4");
                InGameManager.Instance.level4.bridges[0].active = InGameManager.Instance.isNewMap;

                break;

        }
    }



}
