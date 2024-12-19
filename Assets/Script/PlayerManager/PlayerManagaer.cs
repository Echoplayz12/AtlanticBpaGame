using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagaer : MonoBehaviour
{
    #region Singleton
    
    public static PlayerManagaer Instance;

    void Awake()
    {
        Instance = this;    
    }
   #endregion

    public GameObject player;
}
