using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ShipMoveState : BaseState<ShipBehaviour.AvailableStates> {
    
    [SerializeField] private float speed = 1;
    [SerializeField] private Transform turret;
    [SerializeField] private PositionObject playerPosition;
    [SerializeField] private WorldMovementObject movement;
    
    [SerializeField] private float timeBetweenShootState = 4f;
    private float timer;
    
    private ShipBehaviour behaviour => (ShipBehaviour)stateMachine;
    
    public ShipMoveState (ShipBehaviour.AvailableStates key) : base(key) { }

    public void SetupState(ShipBehaviour stateMachine) {
        base.SetupState(stateMachine);
    }
    
    public override void EnterState() {
        behaviour.Body.velocity = movement.BackgroundMovement * 1/speed;
        timer = 0;
    }

    public override void ExitState() {
    }

    public override void UpdateState() {
        // Rotate turret
        Vector2 direction = (playerPosition.Position - behaviour.transform.position).normalized;
        turret.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

        timer += Time.deltaTime;
        if (timer >= timeBetweenShootState) {
            TransitionToState(ShipBehaviour.AvailableStates.Shoot);
        }
    }
}