using Labyrinth;
using UnityEngine;

public class Lava : MonoBehaviour {
    [SerializeField] private GameManagerSO gm;
    
    void Start() { }

    void Update() { }

    private void OnCollisionEnter(Collision other) {
        if (other.transform.TryGetComponent(out PlayerRigidCollider player)) {
            gm.RaisePlayerDeath();
        }
    }
}