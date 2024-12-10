using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour {
    
    [SerializeField]
    private float sensitivity = 50000f;

    [SerializeField]
    private GameObject player;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        transform.Rotate(-mouseY * sensitivity * Time.deltaTime * Vector3.right);
        
        player.transform.Rotate(mouseX * sensitivity * Time.deltaTime * Vector3.up);
    }
}