using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameCanvas : MonoBehaviour
{

    public TextMeshProUGUI FPSText;
    private float deltaTime = 0.0f;
    private float cacheDeltatime=0.0f;
    void Start()
    {
        
    }


    private void LateUpdate()
    {

    }

    void Update()
    {
        // Delta time'� hesapla ve FPS de�erini g�ncelle
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        if (fps!=cacheDeltatime)
        {
            FPSText.text = string.Format("{0:0.} FPS", fps);
            cacheDeltatime=fps; 
        }
        else
        {

        }
    }
}
