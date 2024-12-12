using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private float speed = 3.0f;
    private float sprintMultiplier = 1.7f;

    private CharacterController controller;
    
    private float gravityAcceleration = -9.81f;
    private float verticalAcceleration = -1.0f;
    
    private ViewModeManager viewModeManager;
    
    void Start() {
        controller = GetComponent<CharacterController>();
        viewModeManager = GetComponent<ViewModeManager>();
    }

    void Update() {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        
        bool grounded = controller.isGrounded;
        
        // Mover en la dirección de input
        if (!viewModeManager.GetViewMode()) {
            hInput = 0.0f;
        }
        Vector3 movementDirectionLocal = new Vector3(hInput, 0, vInput).normalized;
        Vector3 movementDirectionWorld = transform.TransformDirection(movementDirectionLocal); // Transformar el vector de local a global, para mover el personaje hacia donde mira la cámara
        
        float totalSpeed = Input.GetKey(KeyCode.LeftShift) ? speed * sprintMultiplier : speed;
        
        controller.Move(totalSpeed * Time.deltaTime * movementDirectionWorld);

        // Gravedad
        verticalAcceleration += gravityAcceleration * Time.deltaTime; // Se necesita una fuerza constante hacia abajo para que funcione isGrounded
        if (grounded && Input.GetKeyDown(KeyCode.Space)) {
            verticalAcceleration = 5f;
        }
        
        controller.Move(verticalAcceleration * Time.deltaTime * Vector3.up);
    }
    
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Trophy Collided");
        Destroy(other.gameObject);
    }
}