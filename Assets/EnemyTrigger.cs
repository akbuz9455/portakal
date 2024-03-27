using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine; // Cinemachine namespace'ini eklemeyi unutmay�n

public class EnemyTrigger : MonoBehaviour
{

    public float distance = 5f; // Geriye do�ru hareket edilecek mesafe
    public float duration = 1f; // Hareketin s�resi
    public bool isBus;
    public bool isTree;
 

    void MoveCharacterBackwards(Transform characters)
    {
        Vector3 backwards = transform.forward * distance; // Karakterin tam tersi y�nde bir vekt�r olu�tur
        characters.transform.DOMove(transform.position + backwards, duration); // DOTween ile bu pozisyona do�ru hareketi ba�lat
    }
    void MoveBusBackwards(Transform characters)
    {
       Vector3 backwards = -transform.up * (distance/2); // Karakterin tam tersi y�nde bir vekt�r olu�tur
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
