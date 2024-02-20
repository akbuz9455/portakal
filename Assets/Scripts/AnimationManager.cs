using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator; 
    void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }
    void ResetAllTriggers()
    {
        animator.ResetTrigger("GoRun");
        animator.ResetTrigger("GoFastRun");
        animator.ResetTrigger("GoFlip");
        animator.ResetTrigger("GoJump");
      
      
    }

    public void GoFlip()
    {
        ResetAllTriggers(); // Tüm tetikleyicileri sýfýrla
        animator.SetTrigger("GoFlip"); // Run animasyonunu baþlat
    }

    public void GoJump()
    {
        ResetAllTriggers(); // Tüm tetikleyicileri sýfýrla
        animator.SetTrigger("GoJump"); // Run animasyonunu baþlat
    }
    public void GoRun()
    {
        ResetAllTriggers(); // Tüm tetikleyicileri sýfýrla
        animator.SetTrigger("GoRun"); // Run animasyonunu baþlat
    }
    public void GoIdle()
    {
        //esetAllTriggers(); // Tüm tetikleyicileri sýfýrla

    }

    public void GoFastRun()
    {
        ResetAllTriggers(); // Tüm tetikleyicileri sýfýrla
        animator.SetTrigger("GoFastRun"); // Run animasyonunu baþlat
    }

 
}
