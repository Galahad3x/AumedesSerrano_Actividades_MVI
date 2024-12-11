using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour {
    [SerializeField] private float horizontalSensitivity = 800f;
    [SerializeField] private float verticalSensitivity = 3.6f;

    [SerializeField] private GameObject player;

    private float rotationY = 0.0f;
    
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSensitivity;

        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, -80, 80);

        transform.localRotation = Quaternion.Euler(rotationY, 0, 0);

        player.transform.Rotate(mouseX * Time.deltaTime * Vector3.up);
    }
}