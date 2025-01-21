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

    void OnDestroy() {
        gm.OnPressurePlateActivated -= lowerPlate;
        gm.OnPressurePlateDeactivated -= raisePlate;
    }

    void Update() { }

    public int getId() {
        return id;
    }

    private void lowerPlate(int plateId) {
        if (plateId != id) {
            return;
        }
        
        transform.Translate(Vector3.down * 0.1f);
    }

    private void raisePlate(int plateId) {
        if (plateId != id) {
            return;
        }
        
        transform.Translate(Vector3.up * 0.1f);
    }
}