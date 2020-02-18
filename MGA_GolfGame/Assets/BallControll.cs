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

    public bool isMoving = false;
    public bool rotationReset = false;


    public Transform aimArrow;

    public Camera MainCam; // camera Obj


    // Update is called once per frame
    void Update()
    {

        // transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        if (Input.GetKeyDown("z")) // adds 100 force
        {
            zForce += 100;
        }
        if (Input.GetKeyDown("x")) // adds 10 force
        {
            zForce += 10;
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(0, 5, 0);
        }
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, -5, 0);
        }
        if ((GetComponent<Rigidbody>().velocity == Vector3.zero) && (rotationReset == false))
        { 
            GameObject.Find("arrow").transform.localScale = new Vector3(1, 1, 1); // make arrow visible\
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            rotationReset = true;
        }

        if((isMoving == true )&&( GetComponent<Rigidbody>().velocity == Vector3.zero))
        {
            rotationReset = false;
            isMoving = false;
        }

        // camera settings:

          Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
         MainCam.transform.LookAt(targetPosition);



       // MainCam.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;

        MainCam.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;  // CAMERA FOLLOWING THE BALL 



        if (Input.GetKey("space")) // shoots with space key
        {
            shoot();
        }

    }

    void shoot()
    {
        if (GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
           

            GameObject.Find("arrow").transform.localScale = new Vector3(0, 0, 0); // make arrow invisible

 
            GetComponent<Rigidbody>().AddRelativeForce(0, 0, zForce); // X Y Z

            isMoving = true;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("BALL COLIDED WITH TRIGGER");
        EditorSceneManager.LoadScene("MainScene"); // go to next scene after ball entered hole
    }


}
// update