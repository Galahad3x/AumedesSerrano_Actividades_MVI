using System.Collections;
using System.Collections.Generic;
using Labyrinth;
using UnityEngine;

public class PressurePlate : MonoBehaviour {
    [SerializeField] private int id;
    
    [SerializeField] private GameManagerSO gm;
    
    void Start() {
        gm.OnPressurePlateActivated += lowerPlate;
        gm.OnPressurePlateDeactivated += raisePlate;
    }

    void Update() { }

    public int getId() {
        return id;
    }

    private void lowerPlate(int plateId) {
        if (plateId != id) {
            return;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
    }
    
    private void raisePlate(int plateId) {
        if (plateId != id) {
            return;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
    }
}