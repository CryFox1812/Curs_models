using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;
    public float zoomSpeed = 10f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleZoom();
    }

    private void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(new Vector3(moveX, 0, moveZ), Space.Self);
    }

    private void HandleRotation()
    {
        if (Input.GetMouseButton(1)) // правая кнопка мыши для вращения
        {
            float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float rotY = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            rotationX += rotX;
            rotationY += rotY;
            rotationY = Mathf.Clamp(rotationY, -90f, 90f); // Ограничение угла по оси Y

            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.right);

            transform.localRotation = Quaternion.identity * xQuaternion * yQuaternion;
        }
    }

    private void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * scroll, Space.Self);
    }
}