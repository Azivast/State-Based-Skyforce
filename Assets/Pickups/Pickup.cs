using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickup : MonoBehaviour {
    [SerializeField] private UnityEvent OnPickup;
    private void OnTriggerEnter2D(Collider2D other) {
        OnPickup.Invoke();
        Destroy(gameObject);
    }
}
