using UnityEngine;

public class LookAround : MonoBehaviour {
    [SerializeField] private float horizontalSensitivity = 800f;
    [SerializeField] private float verticalSensitivity = 3.6f;

    [SerializeField] private GameObject player;

    public float rotationY = 0.0f;
    
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        
        rotationY = 0.0f;
    }

    void Update() {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSensitivity;

        rotationY -= mouseY; // Guardar información de rotación arriba/abajo
        rotationY = Mathf.Clamp(rotationY, -80, 80); // Limitar para no mirar hacia atrás

        transform.localRotation = Quaternion.Euler(rotationY, 0, 0); // Rotar cámara arriba y abajo

        float normaliser = 1 / (Screen.width / 960f);

        player.transform.Rotate(mouseX * Time.deltaTime * normaliser * Vector3.up); // Rotar el personaje (con la cámara) a los lados 
    }
}