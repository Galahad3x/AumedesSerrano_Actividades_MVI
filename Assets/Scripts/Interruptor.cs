using System.Collections;
using System.Collections.Generic;
using Labyrinth;
using UnityEngine;

public class Interruptor : MonoBehaviour {
    [SerializeField] private GameManagerSO gm;
    [SerializeField] private int id;

    void Start() { }


    void Update() { }

    public int getId() {
        return id;
    }
}