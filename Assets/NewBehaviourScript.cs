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
        float currentMoveSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            currentMoveSpeed /= 5f; // ���������� � 5 ��� ��� ������� Ctrl
        }

        float moveX = Input.GetAxis("Horizontal") * currentMoveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * currentMoveSpeed * Time.deltaTime;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.Space)) // ������ ����� ��� ������� �������
        {
            moveY = currentMoveSpeed / 8 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) // ����� ���� ��� ������� Shift
        {
            moveY = -currentMoveSpeed / 8 * Time.deltaTime;
        }

        transform.Translate(new Vector3(moveX, moveY, moveZ), Space.Self);
    }

    private void HandleRotation()
    {
        if (Input.GetMouseButton(1)) // ������ ������ ���� ��� ��������
        {
            float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float rotY = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            rotationX += rotX;
            rotationY += rotY;
            rotationY = Mathf.Clamp(rotationY, -90f, 90f); // ����������� ���� �� ��� Y

            transform.eulerAngles = new Vector3(rotationY, rotationX, 0f);
        }
    }

    private void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * scroll, Space.Self);
    }
}
