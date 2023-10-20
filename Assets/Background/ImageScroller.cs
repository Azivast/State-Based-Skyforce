using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageScroller : MonoBehaviour {
    [SerializeField] private float speed = 1;
    [SerializeField] private bool backgroundMovement = true;
    [SerializeField] private WorldMovementObject movementObject;
    [SerializeField] private Renderer renderer;

    private Vector2 offset = new Vector2();

    void Update() {
        Vector2 dir = backgroundMovement ? -movementObject.BackgroundMovement : -movementObject.ForegroundMovement;
        offset += dir * (speed * Time.deltaTime);
        renderer.material.mainTextureOffset = offset;
    }
}
