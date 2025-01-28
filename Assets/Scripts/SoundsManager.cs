using System.Collections;
using Labyrinth;
using UnityEngine;

public class SoundsManager : MonoBehaviour {
    private AudioSource[] sources;

    [SerializeField] private GameManagerSO gm;

    void Start() {
        sources = GetComponents<AudioSource>();
        gm.OnPlayerDeath += startDeathSounds;
    }

    void OnDestroy() {
        gm.OnPlayerDeath -= startDeathSounds;
    }

    void Update() { }

    private void startDeathSounds() {
        StartCoroutine("deathSounds");
    }

    private IEnumerator deathSounds() {
        sources[0].Stop();
        sources[1].Play();
        yield return new WaitForSeconds(6f);
        sources[2].Play();
    }
}