using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int nrOfShots = 0;

    void Start()
    {
        
    }

    public void addShot()
    {
        nrOfShots+=1;
        Debug.Log(nrOfShots);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
