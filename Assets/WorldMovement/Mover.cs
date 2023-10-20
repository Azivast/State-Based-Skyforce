using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private bool foregroundMovement = true;
    [SerializeField] private bool backgroundMovement = false;
    [SerializeField] private WorldMovementObject movementObject;

    private void OnValidate() {
        backgroundMovement = !foregroundMovement;
    }

    private void Update() {
        if (foregroundMovement) transform.position += (Vector3)movementObject.ForegroundMovement * Time.deltaTime;
        else transform.position += (Vector3)movementObject.BackgroundMovement * Time.deltaTime;
    }
}
