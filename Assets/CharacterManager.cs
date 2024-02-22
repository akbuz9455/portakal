using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    public Collider FullBodyCollider;
    public List<GameObject> particle; //0 2x kosma

    public void GoSpeedParticle()
    {
        particle[0].GetComponent<ParticleSystem>().Play();


    }
    public void GoMoneyParticle()
    {
        particle[1].GetComponent<ParticleSystem>().Play();
    }

    public void KarakterKayiyor()
    {
        FullBodyCollider.enabled = false;
        Debug.Log("kaymaya basladi");
    }
    public void KarakterKaydi()
    {
        Debug.Log("kayma bitti");

       FullBodyCollider.enabled = true;
    }

}
