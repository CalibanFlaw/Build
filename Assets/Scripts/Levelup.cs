using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Levelup : MonoBehaviour
{
    
    Grids grids;

    public GameObject LevelPan;
    public GameObject NewPref;
    public GameObject OldPref;


    void Start()
    {
        grids = FindObjectOfType<Grids>();
      
    }


    public  void Uo()
    {

        Instantiate(NewPref, OldPref.transform.position, OldPref.transform.rotation);
        
        Destroy(OldPref);

    }
    

    private void OnMouseDown()
    {

        if (grids.building == false)
        {
            LevelPan.SetActive(true);
        }


    }
}
