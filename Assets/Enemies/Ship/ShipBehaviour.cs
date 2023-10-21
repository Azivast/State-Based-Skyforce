using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipBehaviour : StateMachine<ShipBehaviour.AvailableStates>, IDamageable, IPathFollower { 
    [SerializeField] private  ShipMoveState moveState = new  ShipMoveState(AvailableStates.Fly);
    [SerializeField] private  ShipShootState ShootState = new  ShipShootState(AvailableStates.Shoot);
    [SerializeField] private  ShipDieState DieState = new  ShipDieState(AvailableStates.Die);
    [SerializeField] private  ShipDespawnState DespawnState = new  ShipDespawnState(AvailableStates.Despawn);

    public int Health = 10;
    
    public enum AvailableStates {
        Fly,
        Shoot,
        Die,
        Despawn,
    }
    
    public Path Path { get; set; }
    
    [HideInInspector]public Rigidbody2D Body;

    private void Awake() {
        Body = GetComponent<Rigidbody2D>();
        States.Add(AvailableStates.Fly, moveState);
        States.Add(AvailableStates.Shoot, ShootState);
        States.Add(AvailableStates.Die, DieState);
        States.Add(AvailableStates.Despawn, DespawnState);

        CurrentState = States[AvailableStates.Fly];
    }

    private void Start() {
        moveState.SetupState(this);
        ShootState.SetupState(this);
        DespawnState.SetupState(this);
        DieState.SetupState(this);
    }

    public void Damage(int amount) {
        Health = Math.Max(Health - amount, 0);
        
        if (Health <= 0) {
            TransitionToState(AvailableStates.Die);
        }
    }
}
