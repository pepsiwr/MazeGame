﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //ควบคุมเมาส์ในเกมX
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; //ควบคุมเมาส์ในเกมY

        xRotation -= mouseY; //Rotateจะถูกลบด้วยการเคลื่อนที่ของMouseY
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Rotateได้ไม่เกิน90

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //Rotate
        playerBody.Rotate(Vector3.up * mouseX);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
