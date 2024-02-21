using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BusTrigger : MonoBehaviour
{
    public GameObject bus;
    public GameObject goTarget;
    public float goTime=1f;
    public bool isMove;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isMove && !InGameManager.Instance.gameover)
        {isMove = true;
           bus.transform.DOMove(new Vector3(goTarget.transform.position.x,bus.transform.position.y,goTarget.transform.position.z),goTime);
        }
       

    }
}
