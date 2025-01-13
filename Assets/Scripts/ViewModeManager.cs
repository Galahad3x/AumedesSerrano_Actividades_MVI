using UnityEngine;

public class ViewModeManager : MonoBehaviour {
    // True -> Normal
    // False -> Classic
    private bool viewMode = true;

    private LookAround lookAround;
    private LookAroundClassic lookAroundClassic;
    
    [SerializeField]
    private Camera camera;

    void Start() {
        lookAround = camera.GetComponent<LookAround>();
        lookAroundClassic = camera.GetComponent<LookAroundClassic>();
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
}