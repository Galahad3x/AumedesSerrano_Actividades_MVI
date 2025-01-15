using System;
using System.Collections;
using System.Collections.Generic;
using Labyrinth;
using UnityEngine;
using Random = System.Random;

public class Dart : MonoBehaviour {
    [SerializeField] private float releaseTimer = 2.0f;

    private Rigidbody rb;

    private bool flying = true;

    [SerializeField] private GameManagerSO gm;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        if (releaseTimer >= 0) {
            releaseTimer -= Time.deltaTime;
            if (releaseTimer < 0) {
                rb.isKinematic = false;

                Vector3 direction = transform.up;
                Random random = new Random();

                direction.y += (random.Next(-20, 20) / 900f);
                direction.z += (random.Next(0, 50) / 900f);
                
                rb.AddForce(15 * direction, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (flying) {
            if (other.gameObject.tag.Equals("Dart") ||
                other.gameObject.tag.Equals("Player") ||
                (other.gameObject.tag.Equals("Wall") && !other.gameObject.name.Equals("Wall (8)") && !other.gameObject.name.Equals("Wall (10)"))) {
                rb.isKinematic = true;
                flying = false;
                if (other.gameObject.tag.Equals("Player")) {
                    gm.RaisePlayerDeath();
                }
            }
        } else {
            if (other.gameObject.tag.Equals("Player")) {
                rb.isKinematic = false;
            }
        }
    }
}