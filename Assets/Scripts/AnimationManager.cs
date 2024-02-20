using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        animator.ResetTrigger("GoFlip2");
        animator.ResetTrigger("GoJump");
        animator.ResetTrigger("GoJump2");
        animator.ResetTrigger("GoFail");

    }

    public void GoFail()
    {
        ResetAllTriggers(); // Tüm tetikleyicileri sýfýrla
        animator.SetTrigger("GoFail"); // Run animasyonunu baþlat
    }

    public void GoFlip()
    {
        ResetAllTriggers(); // Tüm tetikleyicileri sýfýrla

        int randomAnim = Random.Range(0,4);
        if (randomAnim==0)
        {
            animator.SetTrigger("GoFlip"); // Run animasyonunu baþlat

        }
        else
        {
            animator.SetTrigger("GoFlip2"); // Run animasyonunu baþlat

        }
    }

    public void GoJump()
    {
        ResetAllTriggers(); // Tüm tetikleyicileri sýfýrla

        int randomAnim = Random.Range(0, 2);
        if (randomAnim == 0)
        {
            animator.SetTrigger("GoJump"); // Run animasyonunu baþlat

        }
        else
        {
            animator.SetTrigger("GoJump2"); // Run animasyonunu baþlat

        }
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
