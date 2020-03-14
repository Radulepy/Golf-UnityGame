using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    public AudioSource End;

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1);
        End.Play();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter(Collider other)
    {

       
        StartCoroutine(ChangeScene());
        Debug.Log("trigger");
        

    }
}
