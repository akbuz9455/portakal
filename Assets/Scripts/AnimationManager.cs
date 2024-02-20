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
        ResetAllTriggers(); // T�m tetikleyicileri s�f�rla
        animator.SetTrigger("GoFail"); // Run animasyonunu ba�lat
    }

    public void GoFlip()
    {
        ResetAllTriggers(); // T�m tetikleyicileri s�f�rla

        int randomAnim = Random.Range(0,4);
        if (randomAnim==0)
        {
            animator.SetTrigger("GoFlip"); // Run animasyonunu ba�lat

        }
        else
        {
            animator.SetTrigger("GoFlip2"); // Run animasyonunu ba�lat

        }
    }

    public void GoJump()
    {
        ResetAllTriggers(); // T�m tetikleyicileri s�f�rla

        int randomAnim = Random.Range(0, 2);
        if (randomAnim == 0)
        {
            animator.SetTrigger("GoJump"); // Run animasyonunu ba�lat

        }
        else
        {
            animator.SetTrigger("GoJump2"); // Run animasyonunu ba�lat

        }
    }
    public void GoRun()
    {
        ResetAllTriggers(); // T�m tetikleyicileri s�f�rla
        animator.SetTrigger("GoRun"); // Run animasyonunu ba�lat
    }
    public void GoIdle()
    {
        //esetAllTriggers(); // T�m tetikleyicileri s�f�rla

    }

    public void GoFastRun()
    {
        ResetAllTriggers(); // T�m tetikleyicileri s�f�rla
        animator.SetTrigger("GoFastRun"); // Run animasyonunu ba�lat
    }

 
}
