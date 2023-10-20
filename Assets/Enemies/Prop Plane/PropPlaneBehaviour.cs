using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PropPlaneBehaviour : StateMachine<PropPlaneBehaviour.AvailableStates>, IDamageable, IPathFollower {
    [SerializeField] private PropPlaneFlyState FlyState = new PropPlaneFlyState(AvailableStates.Fly);
    [SerializeField] private PropPlaneDieState DieState = new PropPlaneDieState(AvailableStates.Die);
    [SerializeField] private PropPlaneDespawnState DespawnState = new PropPlaneDespawnState(AvailableStates.Despawn);
    public int Health = 3;
    public enum AvailableStates {
        Fly,
        Die,
        Despawn,
    }
    public Path Path { get; set; }
    [HideInInspector]public Rigidbody2D Body;


    private void Awake() {
        Body = GetComponent<Rigidbody2D>();
        States.Add(AvailableStates.Fly, FlyState);
        States.Add(AvailableStates.Die, DieState);
        States.Add(AvailableStates.Despawn, DespawnState);

        CurrentState = States[AvailableStates.Fly];
    }

    private void Start() {
        FlyState.SetupState(this, Path);
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
