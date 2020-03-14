using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{

    PlayerStats ps = new PlayerStats();
    public void GoToMenu()
    {

        SceneManager.LoadScene("Menu");
        ps.resetShot();
    }

    public void PlayAgain()
    {
        ps.resetShot();
        SceneManager.LoadScene("MainScene");


    }
}
