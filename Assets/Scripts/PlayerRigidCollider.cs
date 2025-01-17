using System.Collections;
using System.Collections.Generic;
using Labyrinth;
using UnityEngine;

public class PlayerRigidCollider : MonoBehaviour {
    [SerializeField] private GameManagerSO gm;

    private bool pressurePlateActivated = true;
    private bool nextExitShouldActivate = true;
    private float pressurePlateTimer = 0.4f;

    void Start() {
        pressurePlateActivated = true;
    }

    void Update() {
        if (!pressurePlateActivated) {
            pressurePlateTimer -= Time.deltaTime;
            if (pressurePlateTimer <= 0f) {
                pressurePlateActivated = true;
                pressurePlateTimer = 0.4f;
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Plate")) {
            if (pressurePlateActivated) {
                nextExitShouldActivate = true;
                gm.RaisePressurePlateActivated(other.gameObject.GetComponent<PressurePlate>().getId());
            }
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Plate")) {
            if (nextExitShouldActivate) {
                gm.RaisePressurePlateDeactivated(other.gameObject.GetComponent<PressurePlate>().getId());
                pressurePlateActivated = false;
                nextExitShouldActivate = false;
            }
        }
    }
}