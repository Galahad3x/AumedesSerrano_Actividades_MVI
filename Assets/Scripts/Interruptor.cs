using System.Collections;
using System.Collections.Generic;
using Labyrinth;
using UnityEngine;

public class Interruptor : MonoBehaviour {
    [SerializeField] private GameManagerSO gm;
    [SerializeField] private int id;
    
    private bool pressed = false;
    private float pressTime = 0.6f;

    void Start() {
        gm.OnSwitchPressed += pressSwitch;
    }

    void OnDestroy() {
        gm.OnSwitchPressed -= pressSwitch;
    }


    void Update() {
        if (pressed && pressTime >= 0) {
            pressTime -= Time.deltaTime;
            transform.Translate( 0.1f/0.6f * Time.deltaTime * transform.forward, Space.World);
        }
    }

    public int getId() {
        return id;
    }

    private void pressSwitch(int switchId) {
        if (switchId == id) {
            pressed = true;
        } 
    }
}