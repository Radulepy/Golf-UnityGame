using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObj : MonoBehaviour
{

    public AudioSource Hit;
    public AudioSource End;
    public AudioSource Reset;
    // Start is called before the first frame update

    public void playHit()
    {
        Hit.Play();
    }
    public void playEnd()
    {
        Reset.Play();
    }
    public void playReset()
    {
        Reset.Play();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
