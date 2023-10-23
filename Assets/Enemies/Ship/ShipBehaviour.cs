using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipBehaviour : StateMachine<ShipBehaviour.AvailableStates>, IDamageable, IPathFollower { 
    [SerializeField] private  ShipMoveState moveState = new  ShipMoveState(AvailableStates.Move);
    [SerializeField] private  ShipShootState ShootState = new  ShipShootState(AvailableStates.Shoot);
    [SerializeField] private  ShipDieState DieState = new  ShipDieState(AvailableStates.Die);
    [SerializeField] private UnityEvent OnHit;

    public int Health = 10;
    
    public enum AvailableStates {
        Move,
        Shoot,
        Die,
    }
    
    public Path Path { get; set; }
    
    [HideInInspector]public Rigidbody2D Body;

    private void Awake() {
        Body = GetComponent<Rigidbody2D>();
        States.Add(AvailableStates.Move, moveState);
        States.Add(AvailableStates.Shoot, ShootState);
        States.Add(AvailableStates.Die, DieState);

        CurrentState = States[AvailableStates.Move];
    }

    private void Start() {
        moveState.SetupState(this);
        ShootState.SetupState(this);
        DieState.SetupState(this);
    }

    public void Damage(int amount) {
        if (CurrentState == States[AvailableStates.Die]) return;
        Health = Math.Max(Health - amount, 0);
        OnHit.Invoke();
        
        if (Health <= 0) {
            TransitionToState(AvailableStates.Die);
        }
    }
}
