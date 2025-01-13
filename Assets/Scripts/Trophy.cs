using UnityEngine;

public class Trophy : MonoBehaviour {
    [SerializeField] private float speed = 25f;
    
    void Start() { }
    
    void Update() {
        transform.Rotate(speed * Time.deltaTime * Vector3.up, Space.World);
    }
}