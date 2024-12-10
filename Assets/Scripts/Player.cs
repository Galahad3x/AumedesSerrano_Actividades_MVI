using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private float speed = 3.0f;
    private float sprintMultiplier = 1.5f;
    
    void Start() { }

    void Update() {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        
        Vector3 movementDirection = new Vector3(hInput, 0, vInput).normalized;
        
        float totalSpeed = Input.GetKey(KeyCode.LeftShift) ? speed * sprintMultiplier : speed;
        
        transform.Translate(totalSpeed * Time.deltaTime * movementDirection, Space.Self);
    }
    
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Trophy Collided");
        Destroy(other.gameObject);
    }
}