using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Attribute")]
    private float panSpeed = 30f;
    private float scrollSpeed = 4000f;
    private float panBorderThickness = 10;
    private bool isMove;
    private float minX = 0;
    private float maxX = 90;
    private float minY = 10;
    private float maxY = 90;
    private float minZ = -90;
    private float maxZ = 60;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isMove = !isMove;

        if (!isMove)
            return;
            
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            if (!(transform.position.z >= maxZ))
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            if (!(transform.position.z <= minZ))
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            if (!(transform.position.x <= minX))
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            if (!(transform.position.x >= maxX))
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }


        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 positionForZoom = transform.position;
        positionForZoom.y -= scrollSpeed * Time.deltaTime * scroll;
        positionForZoom.y = Mathf.Clamp(positionForZoom.y, minY, maxY);

        transform.position = positionForZoom;
    }
}
