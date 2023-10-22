using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour, IDamageable {
    [SerializeField] private float speed = 10;
    [SerializeField] private PlayerHealthObject healthObect;
    [SerializeField] private PositionObject positionObject;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform[] firingPositions;
    [SerializeField] private WeaponStatsObject weaponStats;
    [SerializeField] private UnityEvent OnHit;
    [SerializeField] private GameObject ExplosionPrefab;
    private float fireRateTimer;
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        healthObect.OnPlayerDied += OnDeath;
    }

    private void OnDisable() {
        healthObect.OnPlayerDied -= OnDeath;
    }

    public void FixedUpdate(){
        float velocityX = speed * Input.GetAxis("Horizontal");
        float velocityY = speed * Input.GetAxis("Vertical");
        rb.velocity = new Vector2(velocityX, velocityY);

        if (Input.GetKey(KeyCode.Space) && fireRateTimer <= 0) {
            fireRateTimer = 1 / weaponStats.FireRate;
            foreach (var pos in firingPositions) {
                var bullet = Instantiate(projectile, pos.position, pos.rotation);
                bullet.layer = LayerMask.NameToLayer("PlayerProjectiles");
            }
        }

        fireRateTimer -= Time.fixedDeltaTime;

        positionObject.Position = transform.position;
    }

    public void Damage(int amount) {
        healthObect.Damage(amount);
        OnHit.Invoke();
    }

    private void OnDeath() {
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
