using UnityEngine;

public class LookAroundClassic : MonoBehaviour {
    [SerializeField] private float horizontalSensitivity = 200f;

    [SerializeField] private GameObject player;

    private float rotationY = 0.0f;

    private float resetSpeed = 0.0f;

    public bool isEnabled = false;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;

        Init();
    }

    public void Init() {
        rotationY = GetComponent<LookAround>().rotationY;
        resetSpeed = rotationY;
    }

    void Update() {
        float hInput = Input.GetAxisRaw("Horizontal") * horizontalSensitivity;

        if (rotationY * resetSpeed > 0) {
            rotationY -= resetSpeed * Time.deltaTime; // Reiniciar la rotacion vertical a 0 
            transform.localRotation = Quaternion.Euler(rotationY, 0, 0); // Rotar cámara arriba y abajo
        } else {
            isEnabled = true;
        }

        player.transform.Rotate(hInput * Time.deltaTime * Vector3.up); // Rotar el personaje (com la cámara) a los lados
    }
}