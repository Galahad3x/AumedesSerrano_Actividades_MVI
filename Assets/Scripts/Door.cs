using Labyrinth;
using UnityEngine;

public class Door : MonoBehaviour {
    [SerializeField] private GameManagerSO gm;
    [SerializeField] private int id;

    [SerializeField] private float doorTime = 5.0f;
    private bool doorOpen = false;

    void Start() {
        gm.OnSwitchPressed += openDoor;
    }

    void Update() {
        if (doorOpen && doorTime >= 0) {
            doorTime -= Time.deltaTime;
            transform.Translate(2 / 5f * Time.deltaTime * Vector3.down);
        }
    }

    private void openDoor(int doorId) {
        Debug.Log("openDoor");
        if (id == doorId) {
            Debug.Log("id: " + doorId);
            doorOpen = true;
        }
    }
}