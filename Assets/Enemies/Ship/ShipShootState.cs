using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

[Serializable]
public class ShipShootState : BaseState<ShipBehaviour.AvailableStates> {

    [SerializeField] private Transform turret;
    [SerializeField] private Transform firingPosition;
    [SerializeField] private PositionObject playerPosition;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float timeBeforeFirstShot = 1f;
    [SerializeField] private float numberOfShots = 3;
    [SerializeField] private float timeBetweenShots = 0.5f;
    private ShipBehaviour behaviour => (ShipBehaviour)stateMachine;
    private float timeSinceStart;
    private float timeSinceShot;
    private float shotsFired;
    
    public  ShipShootState (ShipBehaviour.AvailableStates key) : base(key) { }

    public void SetupState(ShipBehaviour stateMachine) {
        base.SetupState(stateMachine);
    }

    public override void EnterState() {
        timeSinceStart = 0;
        timeSinceShot = 0;
        shotsFired = 0;
    }

    public override void ExitState() {
    }

    public override void UpdateState() {
        // Rotate turret
        Vector2 direction = (playerPosition.Position - behaviour.transform.position).normalized;
        turret.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        
        // Shooting
        if (shotsFired >= numberOfShots) {
            TransitionToState(ShipBehaviour.AvailableStates.Fly);
        }
        
        if ((timeSinceStart += Time.deltaTime) < timeBeforeFirstShot) return;

        timeSinceShot += Time.deltaTime;
        if (timeSinceShot >= timeBetweenShots) {
            Shoot();
        }
    }

    public override void FixedUpdateState() {
    }

    public void Damage(int amount) {
        behaviour.Health = Math.Max(behaviour.Health - amount, 0);
    }


    private void Shoot() {
        var bullet = MonoBehaviour.Instantiate(projectile, firingPosition.position, firingPosition.rotation);
        bullet.layer = LayerMask.NameToLayer("EnemyProjectiles");
        shotsFired++;
        timeSinceShot = 0;
    }
}