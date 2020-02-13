using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

//TODO:
// subtract force variable
// check if ball position is under the Track (Ball falls of the board) & reset level
public class BallControll : MonoBehaviour
{
    public float zForce = 0; // gravity 'Z' Button

    public Camera MainCam; // camera Obj
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z")) // adds 100 force
        {
            zForce += 100;
        }
        if (Input.GetKeyDown("x")) // adds 10 force
        {
            zForce += 10;
        }
       

        if (Input.GetKeyDown("d"))
        {
            transform.Rotate(0, 5, 0);
        }
        if (Input.GetKeyDown("a"))
        {
            transform.Rotate(0, -5, 0);

        }

        MainCam.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
    }

    void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddRelativeForce(0, 0, zForce); // X Y Z
        StartCoroutine(stopBall()); // CALL stopBall 
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("BALL COLIDED WITH TRIGGER");
        EditorSceneManager.LoadScene("MainScene"); // go to next scene after ball entered hole
    }

    IEnumerator stopBall()
    {
        yield return new WaitForSeconds(5); // check if velocitiy is 0 and make this 0
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        transform.localEulerAngles = new Vector3(0, -90, 0);

    }
}
