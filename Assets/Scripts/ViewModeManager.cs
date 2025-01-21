using System;
using Labyrinth;
using UnityEngine;
using UnityEngine.Serialization;

public class ViewModeManager : MonoBehaviour {
    // True -> Normal
    // False -> Classic
    private bool viewMode = true;

    private LookAround lookAround;
    private LookAroundClassic lookAroundClassic;

    [SerializeField] private GameManagerSO gm;
    
    private Camera _camera;

    void Start() {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
        lookAround = _camera.GetComponent<LookAround>();
        lookAroundClassic = _camera.GetComponent<LookAroundClassic>();

        gm.OnPlayerDeath += disableBoth;
    }

    private void OnDestroy() {
        gm.OnPlayerDeath -= disableBoth;
    }

    void Update() {
        if (viewMode && Input.GetKeyDown(KeyCode.F)) {
            viewMode = false;
            lookAround.enabled = false;
            lookAroundClassic.enabled = true;
            lookAroundClassic.Init();
        } else if (!viewMode && Input.GetKeyDown(KeyCode.F) && lookAroundClassic.isEnabled) {
            viewMode = true;
            lookAround.rotationY = 0.0f;
            lookAround.enabled = true;
            lookAroundClassic.enabled = false;
        }
    }

    public bool GetViewMode() {
        return viewMode;
    }

    public void disableBoth() {
        lookAround.enabled = false;
        lookAroundClassic.enabled = false;
    }

    public Camera getCamera() {
        return _camera;
    }
}