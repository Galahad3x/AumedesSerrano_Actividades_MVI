using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOscillator : MonoBehaviour {
    [SerializeField] private float range;
    [SerializeField] private float speed;

    private Light _light;
    private float initialIntensity;

    private bool increase = false;

    void Start() {
        _light = GetComponent<Light>();
        initialIntensity = _light.intensity;
    }

    void Update() {
        if (increase) {
            _light.intensity += range/speed * Time.deltaTime;
            if (_light.intensity >= initialIntensity + range / 2) {
                increase = false;
            }
        } else {
            _light.intensity -= range/speed * Time.deltaTime;
            if (_light.intensity <= initialIntensity - range / 2) {
                increase = true;
            }
        }
    }
}