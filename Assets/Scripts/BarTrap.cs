using UnityEngine;

public class BarTrap : MonoBehaviour {
    private float travelAngle = 135f;

    private float switchTimer = 2.0f;
    private float travelTimer = 0.5f;

    // false = quieto, true = en moviment
    private bool state = false;
    private bool direction = true;

    void Start() { }

    void Update() {
        if (!state) {
            switchTimer -= Time.deltaTime;
            if (switchTimer <= 0) {
                state = true;
                switchTimer = 2.0f;
            }
        } else {
            travelTimer -= Time.deltaTime;
            if (direction) {
                transform.Rotate(Time.deltaTime * travelAngle / 0.5f * Vector3.up);
            } else {
                transform.Rotate(Time.deltaTime * -travelAngle / 0.5f * Vector3.up);
            }
            if (travelTimer <= 0) {
                state = false;
                direction = !direction;
                travelTimer = 0.5f;
            }
        }
    }

    public bool getIsMoving() {
        return state;
    }
}