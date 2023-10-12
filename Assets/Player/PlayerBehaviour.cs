using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour {
    [SerializeField] private float speed = 10;
    [SerializeField] private GameObject healthObect;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform[] firingPositions;
    [SerializeField] private float fireRate = 1;
    private float fireRateTimer;
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate(){
        float velocityX = speed * Input.GetAxis("Horizontal");
        float velocityY = speed * Input.GetAxis("Vertical");
        rb.velocity = new Vector2(velocityX, velocityY);

        if (Input.GetKey(KeyCode.Space) && fireRateTimer <= 0) {
            fireRateTimer = 1 / fireRate;
            foreach (var pos in firingPositions) {
                Instantiate(projectile, pos.position, pos.rotation);
            }
        }

        fireRateTimer -= Time.fixedDeltaTime;
    }
}
