using System;
using Labyrinth;
using UnityEngine;

public class BarTrapPieces : MonoBehaviour {
    [SerializeField] private GameManagerSO gm;

    [SerializeField] private BarTrap barTrap;

    void Start() { }

    void Update() { }

    private void OnCollisionEnter(Collision other) {
        if (other.transform.TryGetComponent(out PlayerRigidCollider player) && barTrap.getIsMoving()) {
            gm.RaisePlayerDeath();
        }
    }
}