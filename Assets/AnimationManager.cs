using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator; // Animator bile�enine referans

    // Ba�lang��ta Animator bile�enini al
    void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Jump animasyonuna ge�i�i tetikle
    public void GoJump()
    {
        // T�m animasyonlar� durdur (parametreleri s�f�rla)
        ResetAllTriggers();

        // Jump animasyonunu ba�lat
        animator.SetTrigger("Jump");
    }

    // T�m animasyon tetikleyicilerini s�f�rla
    void ResetAllTriggers()
    {
        animator.ResetTrigger("Pose");
        animator.ResetTrigger("Idle");
        animator.ResetTrigger("Walk");
        animator.ResetTrigger("Run");
        animator.ResetTrigger("Punch");
        animator.ResetTrigger("Dance");
        // Jump tetikleyicisi d���ndaki di�er tetikleyicileri buraya ekleyin
    }

    // Di�er animasyonlara ge�i� yapmak i�in benzer fonksiyonlar ekleyebilirsiniz
    // �rne�in, karakteri ko�ma durumuna getirmek i�in:
    public void GoRun()
    {
        ResetAllTriggers(); // T�m tetikleyicileri s�f�rla
        animator.SetTrigger("Run"); // Run animasyonunu ba�lat
    }
}
