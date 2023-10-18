using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

[Serializable]
public class HeliShootState : BaseState<HeliBehaviour.AvailableStates> {

    [SerializeField] private GameObject projectile;
    [SerializeField] private float timeBeforeFirstShot = 1f;
    [SerializeField] private float numberOfShots = 3;
    [SerializeField] private float timeBetweenShots = 0.5f;
    private HeliBehaviour behaviour => (HeliBehaviour)stateMachine;
    private float timeSinceStart;
    private float timeSinceShot;
    private float shotsFired;
    
    public  HeliShootState (HeliBehaviour.AvailableStates key) : base(key) { }

    public void SetupState(HeliBehaviour stateMachine) {
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
        if (shotsFired >= numberOfShots) {
            TransitionToState(HeliBehaviour.AvailableStates.Fly);
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
        var bullet = MonoBehaviour.Instantiate(projectile, behaviour.transform.position, behaviour.transform.rotation);
        bullet.layer = LayerMask.NameToLayer("EnemyProjectiles");
        shotsFired++;
        timeSinceShot = 0;
    }
}