using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

//TODO:
// subtract force variable
// check if ball position is under the Track (Ball falls of the board) & reset level
public class XControl : MonoBehaviour
{
    public float zForce = 0; // gravity 'Z' Button

    public bool isMoving = false;
    public bool rotationReset = false;


    public Transform aimArrow;

    public Camera MainCam; // camera Obj

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
        if ((GetComponent<Rigidbody>().velocity == Vector3.zero) && (rotationReset = false))
        {

            rotationReset = true;
            Vector3 newRotation = transform.eulerAngles;
            newRotation.y = MainCam.transform.eulerAngles.y;
            transform.eulerAngles = newRotation;

        }

        if (GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            GameObject.Find("arrow").transform.localScale = new Vector3(1, 1, 1); // make arrow invisible
        }
        else
        {
            GameObject.Find("arrow").transform.localScale = new Vector3(0, 0, 0); // make arrow visible
        }


        MainCam.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;

    }

    void OnMouseDown()
    {


        if (GetComponent<Rigidbody>().velocity == Vector3.zero)
        {


            GameObject.Find("arrow").transform.localScale = new Vector3(0, 0, 0); // MAKE INVISIBLE

            GetComponent<Rigidbody>().AddRelativeForce(0, 0, zForce); // X Y Z


        }


    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("BALL COLIDED WITH TRIGGER");
        EditorSceneManager.LoadScene("MainScene"); // go to next scene after ball entered hole
    }


}
