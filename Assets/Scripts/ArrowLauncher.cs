using System.Collections;
using System.Collections.Generic;
using Labyrinth;
using UnityEngine;

public class ArrowLauncher : MonoBehaviour {
    [SerializeField] private GameManagerSO gm;

    [SerializeField] private int id;
    
    [SerializeField] private GameObject dart;
    
    void Start() {
        gm.OnPressurePlateActivated += createArrow;
    }
    
    void Update()
    {
        
    }

    void createArrow(int plateId) {
        Debug.Log("Event tirat " + plateId + " " + id);
        Instantiate(dart, transform.position, Quaternion.Euler(0, 0, 90));
    }
}
