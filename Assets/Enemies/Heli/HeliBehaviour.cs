using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class HeliBehaviour : StateMachine<HeliBehaviour.AvailableStates>, IDamageable, IPathFollower {
    [SerializeField] private  HeliFlyState FlyState = new  HeliFlyState(AvailableStates.Fly);
    [SerializeField] private  HeliShootState ShootState = new  HeliShootState(AvailableStates.Shoot);
    [SerializeField] private  HeliDieState DieState = new  HeliDieState(AvailableStates.Die);
    [SerializeField] private  HeliDespawnState DespawnState = new  HeliDespawnState(AvailableStates.Despawn);
    [SerializeField] private UnityEvent OnHit;

    public int Health = 3;
    
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
        States.Add(AvailableStates.Fly, FlyState);
        States.Add(AvailableStates.Shoot, ShootState);
        States.Add(AvailableStates.Die, DieState);
        States.Add(AvailableStates.Despawn, DespawnState);

        CurrentState = States[AvailableStates.Fly];
    }

    private void Start() {
        FlyState.SetupState(this, Path);
        ShootState.SetupState(this);
        DespawnState.SetupState(this);
        DieState.SetupState(this);
    }

    public void Damage(int amount) {
        Health = Math.Max(Health - amount, 0);
        OnHit.Invoke();
        
        if (Health <= 0) {
            TransitionToState(AvailableStates.Die);
        }
    }
}
