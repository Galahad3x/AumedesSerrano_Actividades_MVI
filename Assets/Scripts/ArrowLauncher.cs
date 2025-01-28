using Labyrinth;
using UnityEngine;

public class ArrowLauncher : MonoBehaviour {
    [SerializeField] private GameManagerSO gm;

    [SerializeField] private int id;

    [SerializeField] private GameObject dart;

    void Start() {
        gm.OnPressurePlateActivated += createArrow;
    }

    void OnDestroy() {
        gm.OnPressurePlateActivated -= createArrow;
    }
    
    void Update() { }

    void createArrow(int plateId) {
        if (plateId == id)
        {
            Instantiate(dart, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.Euler(0, 0, 90));
        }
    }
}