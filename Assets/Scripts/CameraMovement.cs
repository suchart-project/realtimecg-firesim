using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;

    public float sensitivityX = 15f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * sensitivityX;
        rotationY += Input.GetAxis("Mouse Y") * sensitivityX;
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        if (Input.GetKey(KeyCode.W))
        {
            MoveForward();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveBackward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        } 
        if (Input.GetKey(KeyCode.Space))
        {
            MoveUp();
        }
    }

    void MoveForward() {
        transform.position = new Vector3(transform.position.x + (transform.forward * Time.deltaTime * 10).x, transform.position.y, transform.position.z + (transform.forward * Time.deltaTime * 10).z);
    }

    void MoveBackward() {
        transform.position = new Vector3(transform.position.x - (transform.forward * Time.deltaTime * 10).x, transform.position.y, transform.position.z - (transform.forward * Time.deltaTime * 10).z);
    }

    void MoveLeft() {
        transform.position = new Vector3(transform.position.x - (transform.right * Time.deltaTime * 10).x, transform.position.y, transform.position.z - (transform.right * Time.deltaTime * 10).z);
    }

    void MoveRight() {
        transform.position = new Vector3(transform.position.x + (transform.right * Time.deltaTime * 10).x, transform.position.y, transform.position.z + (transform.right * Time.deltaTime * 10).z);
    }

    void MoveUp() {
        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * 10, transform.position.z);
    }
}