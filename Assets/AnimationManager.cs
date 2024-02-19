using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator; // Animator bileþenine referans

    // Baþlangýçta Animator bileþenini al
    void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Jump animasyonuna geçiþi tetikle
    public void GoJump()
    {
        // Tüm animasyonlarý durdur (parametreleri sýfýrla)
        ResetAllTriggers();

        // Jump animasyonunu baþlat
        animator.SetTrigger("Jump");
    }

    // Tüm animasyon tetikleyicilerini sýfýrla
    void ResetAllTriggers()
    {
        animator.ResetTrigger("Pose");
        animator.ResetTrigger("Idle");
        animator.ResetTrigger("Walk");
        animator.ResetTrigger("Run");
        animator.ResetTrigger("Punch");
        animator.ResetTrigger("Dance");
        // Jump tetikleyicisi dýþýndaki diðer tetikleyicileri buraya ekleyin
    }

    // Diðer animasyonlara geçiþ yapmak için benzer fonksiyonlar ekleyebilirsiniz
    // Örneðin, karakteri koþma durumuna getirmek için:
    public void GoRun()
    {
        ResetAllTriggers(); // Tüm tetikleyicileri sýfýrla
        animator.SetTrigger("Run"); // Run animasyonunu baþlat
    }
}
