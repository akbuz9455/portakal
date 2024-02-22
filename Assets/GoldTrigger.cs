using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GoldTrigger : MonoBehaviour
{
    private bool collected;
    public GameObject particles;
    private void Awake()
    {
        particles = transform.GetChild(0).gameObject;
      
    }
    private void Start()
    {
       

    }
    private void OnTriggerEnter(Collider other)
    {
        if (InGameManager.Instance.gameover|| collected) return;


        if (other.transform.tag=="Player") {
            collected=true;
            InGameManager.Instance.puan++;
            transform.GetChild(0).parent = null;
            particles.GetComponent<ParticleSystem>().Play();
            transform.DOScale(Vector3.zero,.10f).SetEase(Ease.OutSine);
        }
    }
}
