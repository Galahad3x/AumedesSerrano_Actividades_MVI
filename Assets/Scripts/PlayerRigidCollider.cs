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
        if (other.gameObject.TryGetComponent(out PressurePlate plate)) {
            if (pressurePlateActivated) {
                nextExitShouldActivate = true;
                gm.RaisePressurePlateActivated(plate.getId());
            }
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.TryGetComponent(out PressurePlate plate)) {
            if (nextExitShouldActivate) {
                gm.RaisePressurePlateDeactivated(plate.getId());
                pressurePlateActivated = false;
                nextExitShouldActivate = false;
            }
        }
    }
}