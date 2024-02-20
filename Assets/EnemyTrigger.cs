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
        if (other.tag=="Player"&& !InGameManager.Instance.gameover)
        {
            Debug.Log("Player Geldi");
            other.transform.GetChild(0).transform.SetParent(null);
            other.transform.GetComponent<SplineFollower>().followSpeed = 0;
            other.transform.GetComponent<SplineFollower>().enabled = false;
            InGameManager.Instance.animationManager.GoFail();
            MoveCharacterBackwards(other.transform);
           // InGameManager.Instance.inGameCam.GetComponent<CinemachineVirtualCamera>().LookAtTargetAttachment(transform.gameObject);
          Invoke("Cam2Active", .35f);


        }
    }

}
