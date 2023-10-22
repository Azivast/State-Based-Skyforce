using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] private int Speed = 3;
    [SerializeField] private float spread = 0;
    public int Damage = 1;

    private void Start() {

        transform.Rotate(Vector3.forward, UnityEngine.Random.Range(-spread, spread));
    }

    private void FixedUpdate() {
        transform.position += transform.up * (Speed * Time.fixedDeltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.TryGetComponent(out IDamageable damageable)) {
            damageable.Damage(Damage);
        }
        Destroy(gameObject);
    }
}
