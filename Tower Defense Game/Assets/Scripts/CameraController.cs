using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;
    public float panSpeed = 20f;
    public float panBoarderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 100f;

    void Update()
    {
        if (GameManager.isGameOver) return;

        if (Input.GetKey(KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement) return;
        // Move Up
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBoarderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        // Move Down
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBoarderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        // Move Right
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBoarderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        // Move Left
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBoarderThickness)
        {
            transform.Translate(Vector3.left * panSpeed* Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * scrollSpeed * Time.deltaTime * 1000;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        
        transform.position = pos;

        

        
    }
}
