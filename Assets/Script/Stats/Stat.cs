using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class Stat
{
    //serialized class for handling Stats

    [SerializeField]
    private int baseValue;

    public int getValue()
    {
        return baseValue;
    }
}