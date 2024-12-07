using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour {
    private bool helpActive = false;

    void Start() { }

    void Update() {
        if (Input.GetKeyDown(KeyCode.H)) {
            ToggleHelp();
        }
    }

    void ToggleHelp() {
        if (!helpActive) {
            transform.position = new Vector3(0, -2, 0);
            helpActive = true;
        } else {
            transform.position = new Vector3(0, -20, 0);
            helpActive = false;
        }
    }
}