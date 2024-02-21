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
    void MoveCharacterBackwards(Transform characters)
    {
        Vector3 backwards = transform.forward * distance; // Karakterin tam tersi yönde bir vektör oluþtur
        characters.transform.DOMove(transform.position + backwards, duration); // DOTween ile bu pozisyona doðru hareketi baþlat
    }
    public void Cam2Active()
    {
        InGameManager.Instance.outGameCam.SetActive(true);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            Debug.Log("Player Geldi");
            GameObject parentObj = other.transform.parent.gameObject;
            parentObj.transform.GetComponent<SplineFollower>().followSpeed = 0;
            parentObj.transform.GetComponent<SplineFollower>().enabled = false;
            other.transform.SetParent(null);
           
            InGameManager.Instance.animationManager.GoFail();
            MoveCharacterBackwards(parentObj.transform);
            Invoke("Cam2Active", .35f);


        }
    }

}
