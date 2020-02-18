
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraController : MonoBehaviour
{
    private bool doMovement = false;

    public float panSpeed = 10f;
    public float scrollSpeed = 0.1f;
    public float panBorderThickness = 20f;

    public float minY = 0.5f;
    public float maxY = 4f;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // if you press ESC, then you will block the camera in present position;
            doMovement = !doMovement;
        if (Input.GetKeyDown(KeyCode.P)) // if you press ESC, then you will block the camera in present position;
            SceneManager.LoadScene("MenuScene");
        if (!doMovement)
            return;

        if (Input.GetKey("up") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World); // Vector3.forward
        }

        if (Input.GetKey("down") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World); // Vector3.forward
        }

        if (Input.GetKey("right") ||  Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); // Vector3.forward
        }

        if (Input.GetKey("left") || Input.mousePosition.x < panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World); // Vector3.forward
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 700 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
