using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MissleBehaviour : MonoBehaviour
{
    [SerializeField] private int Speed = 3;
    public int Damage = 1;
    [SerializeField] private float HomingTime = 3;
    [SerializeField] private PositionObject targetPositionObject;

    private float timeHomed = 0;
    private Vector3 target;
    

    private void Update() {
        timeHomed += Time.deltaTime;
    }

    private void FixedUpdate() {
        if (timeHomed <= HomingTime) {
            target = targetPositionObject.Position - transform.position;
            target.Normalize();
        }
        
        transform.position += target * (Speed * Time.fixedDeltaTime);
        
        transform.rotation = Quaternion.FromToRotation(Vector3.up, target);
    }
    
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.TryGetComponent(out IDamageable damageable)) {
            damageable.Damage(Damage);
        }
        Destroy(gameObject);
    }
}
