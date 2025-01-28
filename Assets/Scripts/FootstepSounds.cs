using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSounds : MonoBehaviour {
    private AudioSource[] audioSources;

    private bool step = false;

    private Coroutine routine;

    [SerializeField] private Player player;

    [SerializeField] private float walkSeparation = 0.57f;
    [SerializeField] private float sprintSeparation = 0.36f;

    void Start() {
        audioSources = GetComponents<AudioSource>();

        routine = StartCoroutine("playFootstepSounds");
    }

    private IEnumerator playFootstepSounds() {
        while (true) {
            if (player.getIsAlive() && player.getIsGrounded() && player.getMovementAmount() > 0.0f) {
                if (step) {
                    audioSources[1].Play();
                } else {
                    audioSources[0].Play();
                }
                step = !step;

                if (Input.GetKey(KeyCode.LeftShift)) {
                    yield return new WaitForSeconds(sprintSeparation);
                } else {
                    yield return new WaitForSeconds(walkSeparation);
                }
            } else {
                yield return new WaitForSeconds(sprintSeparation);
            }
        }
    }
}