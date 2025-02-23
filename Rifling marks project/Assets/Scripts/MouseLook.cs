using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float Sensitivity = 0;

    public float xDead = 0;
    public float yDead = 0;

    public Transform playerBody;

    float xRot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;

        xRot -= x;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * y);
    }
}
