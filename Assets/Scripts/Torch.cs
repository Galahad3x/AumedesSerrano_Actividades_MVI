using Labyrinth;
using UnityEngine;

public class Torch : MonoBehaviour {
    private Light torchLight;
    
    private AudioSource audioSource;

    [SerializeField] private GameManagerSO gm;

    void Start() {
        torchLight = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();
        gm.OnPlayerDeath += () => this.enabled = false;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            audioSource.Play();
            torchLight.enabled = !torchLight.enabled;
        }
    }
}