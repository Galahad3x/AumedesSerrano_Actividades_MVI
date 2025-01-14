using System;
using System.Collections;
using System.Collections.Generic;
using Labyrinth;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour {
    [SerializeField] private GameManagerSO gm;

    [SerializeField] private Image image;

    private bool fadeIn;
    
    void Start() {
        gm.OnPlayerDeath += screenFadeIn;
    }

    private void Update() {
        if (fadeIn) {
            Color currentColor = image.color;
            if (currentColor.a < (24/255f)) {
                currentColor.a += (12f/255) * Time.deltaTime;
            }
            image.color = currentColor;
        }
    }

    private void screenFadeIn() {
        fadeIn = true;
    }
}