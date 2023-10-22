using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DeleteAfterAudio : MonoBehaviour {
    private AudioSource source;
    private void Awake() {
        source = GetComponent<AudioSource>();
    }

    private void Start() {
        source.transform.parent = null;
        source.Play();
    }

    private void Update() {
        if (source.isPlaying == false) {
            Destroy(gameObject);
        }
    }
}
