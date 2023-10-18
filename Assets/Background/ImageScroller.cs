using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageScroller : MonoBehaviour {
    [SerializeField] private float speed = 1;
    [SerializeField] private Vector2 direction = Vector2.down;
    [SerializeField] private Renderer renderer;

    private void OnValidate() {
        direction.Normalize();
    }

    void Update() {
        Vector2 offset = direction * (Time.time * speed);
        renderer.material.mainTextureOffset = offset;
    }
}
