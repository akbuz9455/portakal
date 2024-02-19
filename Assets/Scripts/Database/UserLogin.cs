using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;
public class UserLogin : MonoBehaviour
{
    public static UserLogin Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        UniRESTClient.debugMode = true;
      
    }

}
