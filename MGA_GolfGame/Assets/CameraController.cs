﻿
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraController : MonoBehaviour
{
    private bool doMovement = true;


    public float panSpeed = 10f;
    public float scrollSpeed = 5f;
    public float panBorderThickness = 10f;

    public float minY = 1.5f;
    public float maxY = 10f;


    // Update is called once per frame
    void Update()


    {
        if (Input.GetKeyDown(KeyCode.Escape)) // if you press ESC, then you will block the camera in present position;
            doMovement = !doMovement;
        if (Input.GetKeyDown(KeyCode.P)) // if you press ESC, then you will block the camera in present position;
            SceneManager.LoadScene("MenuScene");

        if (!doMovement)
            return;
        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World); // Vector3.forward
        }

        if (Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World); // Vector3.forward
        }

        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); // Vector3.forward
        }

        if (Input.mousePosition.x < panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World); // Vector3.forward
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        //Debug.Log(scroll);

        Vector3 pos = transform.position;
        pos.y -= scroll * 700 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

    }
}
