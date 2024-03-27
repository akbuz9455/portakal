using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine; // Cinemachine namespace'ini eklemeyi unutmayýn

public class EnemyTrigger : MonoBehaviour
{

    public float distance = 5f; // Geriye doðru hareket edilecek mesafe
    public float duration = 1f; // Hareketin süresi
    public bool isBus;
    public bool isTree;
 

    void MoveCharacterBackwards(Transform characters)
    {
        Vector3 backwards = transform.forward * distance; // Karakterin tam tersi yönde bir vektör oluþtur
        characters.transform.DOMove(transform.position + backwards, duration); // DOTween ile bu pozisyona doðru hareketi baþlat
    }
    void MoveBusBackwards(Transform characters)
    {
       Vector3 backwards = -transform.up * (distance/2); // Karakterin tam tersi yönde bir vektör oluþtur
        transform.DOMove(transform.position + backwards, duration / 2).OnComplete(() =>
        {

            transform.DOShakeRotation(5, 1, 1, 2);

        }); 
    }
    public void Cam2Active()
    {
        InGameManager.Instance.outGameCam.SetActive(true);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player" && !InGameManager.Instance.gameover)
        {
            transform.DOKill();
            if (isBus)
            {
                MoveBusBackwards(transform);
            }
            Debug.Log("Player Geldi");
            if (other.transform.parent!=null)
            {

            }
            InGameManager.Instance.EndGame();
            if (other.transform.parent==null)
            {
                return;
            }
            GameObject parentObj = other.transform.parent.gameObject;
            parentObj.transform.GetComponent<SplineFollower>().followSpeed = 0;
            parentObj.transform.GetComponent<SplineFollower>().enabled = false;
            other.transform.SetParent(null);
           
            
            MoveCharacterBackwards(parentObj.transform);
            Invoke("Cam2Active", .35f);


        }
  
    }

}
