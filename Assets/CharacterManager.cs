using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    public Collider FullBodyCollider;
   
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
