using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float mouseSense = 150f;
    public Transform body;
    float xRot = 0f;

    // Update is called once per frame
    void Update()
    {
        // Camera
        float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        body.Rotate(Vector3.up * mouseX);
    }
}
