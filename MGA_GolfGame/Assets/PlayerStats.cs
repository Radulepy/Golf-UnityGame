using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int nrOfShots = 1;

    public Text ShotsText;


    void Start()
    {
        
    }

    public void resetShot()
    {
        nrOfShots = 0;
    }

    public void addShot()
    {
        nrOfShots+=1;
        Debug.Log(nrOfShots);

    }

    public int getShots()
    {
        return nrOfShots;
    }

    // Update is called once per frame
    void Update()
    {
        ShotsText.text = "Hits: " + nrOfShots.ToString();
    }
}
