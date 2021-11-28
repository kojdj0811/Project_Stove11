using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSoundManager : MonoBehaviour
{

    public AudioSource footAudio;

    private void Awake() {
        footAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        footAudio.Play();
    }
}
