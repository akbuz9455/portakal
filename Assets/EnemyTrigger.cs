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
    void MoveCharacterBackwards(Transform characters)
    {
        Vector3 backwards = transform.forward * distance; // Karakterin tam tersi y�nde bir vekt�r olu�tur
        characters.transform.DOMove(transform.position + backwards, duration); // DOTween ile bu pozisyona do�ru hareketi ba�lat
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
