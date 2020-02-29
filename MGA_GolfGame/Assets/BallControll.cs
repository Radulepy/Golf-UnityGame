using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

//MAXIM VALUES:
// Force = 1000
// Scale = 6

//TODO:
// subtract force variable
// check if ball position is under the Track (Ball falls of the board) & reset level
public class BallControll : MonoBehaviour
{
    public float zForce = 25; // gravity 'Z' Button
    public float zScale = 1;

    public bool isMoving = false;
    public bool rotationReset = false;
    public bool count = false;

    public Transform aimArrow;

    public Camera MainCam; // camera Obj

    public GameObject arrowSign;

    PlayerStats playerStats = new PlayerStats();




    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0.05f) // BALL FELT OF THE TRACK! (RESTART)
        {

            StartCoroutine(ExampleCoroutine());

        }


        // transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        if (Input.GetKeyDown("w") && zForce < 1000) // adds 100 force
        {
            zForce += 100;
            zScale += 0.5f;
            arrowSign.transform.localScale = new Vector3(zScale, 1, 1);
        }
        if (Input.GetKeyDown("s") && zForce > 0) // adds 10 force
        {
            zForce -= 50;
            zScale -= 0.25f;
            aimArrow.GetComponent<Transform>().localScale = new Vector3(zScale, 1, 1);

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

        if ((isMoving == true) && (GetComponent<Rigidbody>().velocity == Vector3.zero))
        {
            rotationReset = false;
            isMoving = false;
            count = true;
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

        // TODO: SET COLOR
        if (zScale == 1)
        {
            arrowSign.GetComponent<Renderer>().material.color = new Color(255, 0, 0);

        }
        if(zScale != 1)
        {
            arrowSign.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        }

    }

    // TODO BALL TRAIL 


    IEnumerator ExampleCoroutine()
    {

        Debug.Log("Touched The Ground!");


        yield return new WaitForSeconds(2); // TODO SET A RESTART BUTTON VISIBLE!


        //UnityEditor.PrefabUtility.ResetToPrefabState(this.gameObject);
       // UnityEditor.PrefabUtility.ResetToPrefabState(MainCam.gameObject);
       gameObject.transform.position = new Vector3(-0.7f, 0.17f, -6.2f);
        MainCam.transform.position = new Vector3(-0f, 1.25f, -6f);
         Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        MainCam.transform.LookAt(targetPosition);
        //Destroy(gameObject);

    }

    void shoot()
    {
        if (GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            

            GameObject.Find("arrow").transform.localScale = new Vector3(0, 0, 0); // make arrow invisible


            GetComponent<Rigidbody>().AddRelativeForce(0, 0, zForce); // X Y Z


            isMoving = true;
            // Reset values:
            zForce = 25;
            zScale = 1;

            if(count == true)
            {
                playerStats.addShot();
              //  Debug.Log(playerStats.nrOfShots);
             
                count = false;

            }





        }

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("BALL COLIDED WITH TRIGGER");
            EditorSceneManager.LoadScene("MainScene"); // go to next scene after ball entered hole
        }


    }
}
// update