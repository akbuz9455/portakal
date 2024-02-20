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
        ResetAllTriggers(); // T�m tetikleyicileri s�f�rla
        animator.SetTrigger("GoFlip"); // Run animasyonunu ba�lat
    }

    public void GoJump()
    {
        ResetAllTriggers(); // T�m tetikleyicileri s�f�rla
        animator.SetTrigger("GoJump"); // Run animasyonunu ba�lat
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
