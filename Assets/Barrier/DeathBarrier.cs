using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DeathBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log($"{other} hit death barrier.");
        Destroy(other.gameObject);
    }
}
