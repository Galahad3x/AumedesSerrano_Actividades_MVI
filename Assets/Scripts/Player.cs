using System;
using System.Collections;
using System.Collections.Generic;
using Labyrinth;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float speed = 3.0f;
    private float sprintMultiplier = 1.7f;

    private CharacterController controller;

    private float gravityAcceleration = -9.81f;
    private float verticalAcceleration = -1.0f;

    private ViewModeManager viewModeManager;

    private Rigidbody rb;

    private bool isAlive = true;

    [SerializeField] private GameManagerSO gm;

    void Start() {
        controller = GetComponent<CharacterController>();
        viewModeManager = GetComponent<ViewModeManager>();
        rb = GetComponent<Rigidbody>();

        gm.OnPlayerDeath += playerDie;
    }

    private void OnDestroy() {
        gm.OnPlayerDeath -= playerDie;
    }

    void Update() {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");

        bool grounded = controller.isGrounded;
        if (grounded) {
            verticalAcceleration = -1.0f;
        }

        // Mover en la dirección de input
        if (!viewModeManager.GetViewMode()) {
            hInput = 0.0f;
        }

        Vector3 movementDirectionLocal = new Vector3(hInput, 0, vInput).normalized;
        Vector3
            movementDirectionWorld =
                transform.TransformDirection(
                    movementDirectionLocal); // Transformar el vector de local a global, para mover el personaje hacia donde mira la cámara

        float totalSpeed = Input.GetKey(KeyCode.LeftShift) ? speed * sprintMultiplier : speed;

        if (isAlive) {
            controller.Move(totalSpeed * Time.deltaTime * movementDirectionWorld);
        }

        // Gravedad
        verticalAcceleration +=
            gravityAcceleration *
            Time.deltaTime; // Se necesita una fuerza constante hacia abajo para que funcione isGrounded
        if (grounded && isAlive && Input.GetKeyDown(KeyCode.Space)) {
            verticalAcceleration = 5f;
        }

        if (isAlive) {
            controller.Move(verticalAcceleration * Time.deltaTime * Vector3.up);
        }
        
        if (Input.GetKey(KeyCode.K)) {
            gm.RaisePlayerDeath();
        }

        // Press buttons
        if (Input.GetKeyDown(KeyCode.E)) {
            Camera camera = viewModeManager.getCamera();
            // Debug.DrawRay(camera.transform.position, viewModeManager.getCamera().transform.forward * 2f, Color.red);
            if (Physics.Raycast(camera.transform.position, 2f * viewModeManager.getCamera().transform.forward, out RaycastHit hit,
                    1)) {
                if (hit.transform.TryGetComponent(out Interruptor activador)) {
                    gm.RaiseSwitchPressed(activador.getId());
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Equals("Trophy")) {
            Debug.Log("Trophy Collided");
            Destroy(other.gameObject);
        }
    }

    private void playerDie() {
        isAlive = false;
        controller.enabled = false;
        rb.useGravity = true;
        rb.isKinematic = false;
    }
}