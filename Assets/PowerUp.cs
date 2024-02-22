using DG.Tweening;
using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public bool DoubleSpeed;
    public bool GoldShow;
    public bool Magnet;

    public bool isCollected;

    private GameObject player;
    public GameObject collectedParticle;

    public void GoSpeed()
    {
        player.transform.parent.transform.GetComponent<SplineFollower>().followSpeed += 7;
        Invoke("GoSlow", 3);

    }
    public void GoSlow()
    {
        if (InGameManager.Instance.gameover) return;
        player.transform.parent.transform.GetComponent<SplineFollower>().followSpeed -= 7;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (InGameManager.Instance.gameover|| isCollected) return;

        if (other.transform.tag=="Player")
        {
            isCollected = true;
            player = other.transform.gameObject;

            if (DoubleSpeed)
            {
                GoSpeed();
                InGameManager.Instance.characterManager.GoSpeedParticle();
                collectedParticle.transform.parent = null;
                collectedParticle.GetComponent<ParticleSystem>().Play();
                transform.DOScale(Vector3.zero,.15f);

            }
            if (GoldShow)
            {
                collectedParticle.transform.parent = null;
                collectedParticle.GetComponent<ParticleSystem>().Play();
                transform.DOScale(Vector3.zero, .15f);
            }
            if (Magnet)
            { 
                InGameManager.Instance.magnetSystem.ActivateMagnet(10f);
                InGameManager.Instance.characterManager.GoMoneyParticle();
                collectedParticle.transform.parent = null;
                collectedParticle.GetComponent<ParticleSystem>().Play();
                transform.DOScale(Vector3.zero, .15f);
               
            }

        }
    }
}
