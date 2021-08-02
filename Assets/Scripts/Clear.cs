using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    private GameObject[]  Bulding;

    public void ClearBuld()
    {
        Bulding = GameObject.FindGameObjectsWithTag("Building");
        for(int i=0; i < Bulding.Length; i++)
        {Destroy(Bulding[i]);

        }
        
    }
}
