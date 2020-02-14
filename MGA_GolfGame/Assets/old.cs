using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

//TODO:
// subtract force variable
// check if ball position is under the Track (Ball falls of the board) & reset level
public class old : MonoBehaviour
{
    public float zForce = 0; // gravity 'Z' Button

    public bool isMoving = false;
    public bool rotationReset = false;


    public Transform aimArrow;

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
        if ((GetComponent<Rigidbody>().velocity == Vector3.zero) && (rotationReset = false))
        {

            transform.localEulerAngles = new Vector3(0, -90, 0);
            rotationReset = true;

        }

        if (GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            GameObject.Find("arrow").transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            GameObject.Find("arrow").transform.localScale = new Vector3(0, 0, 0);
        }


        MainCam.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;

    }

    void OnMouseDown()
    {


        if (GetComponent<Rigidbody>().velocity == Vector3.zero)
        {

            //aimArrow.GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("arrow").transform.localScale = new Vector3(0, 0, 0); // MAKE INVISIBLE
                                                                                  //     transform.localEulerAngles = new Vector3(0, -90, 0);
            GetComponent<Rigidbody>().AddRelativeForce(0, 0, zForce); // X Y Z
            StartCoroutine(stopBall()); // CALL stopBall 
            Debug.Log(isMoving);
            GetComponent<Rigidbody>().transform.Rotate(0, 0, 0);

        }
        else
        {
            // transform.localEulerAngles = new Vector3(0, 0, 0);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("BALL COLIDED WITH TRIGGER");
        EditorSceneManager.LoadScene("MainScene"); // go to next scene after ball entered hole
    }

    IEnumerator stopBall()
    {


        //  yield return new WaitForSeconds(2); // check if velocitiy is 0 and make this 0
        if (GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(0.5f);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            transform.localEulerAngles = new Vector3(0, -90, 0);
            //GetComponent<Rigidbody>().transform.Rotate(0, -90, 0);
            Vector3 newRotation = transform.eulerAngles;
            newRotation.y = MainCam.transform.eulerAngles.y;
            transform.eulerAngles = newRotation;

        }

        // GetComponent<Rigidbody>().transform.Rotate(0, -90, 0);
    }
}
