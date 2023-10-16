using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PropPlaneBehaviour : StateMachine<PropPlaneBehaviour.AvailableStates> {
    [SerializeField] private PropPlaneFlyState FlyState = new PropPlaneFlyState(AvailableStates.Fly);
    [SerializeField] private PropPlaneDieState DieState = new PropPlaneDieState(AvailableStates.Die);
    [SerializeField] private PropPlaneDespawnState DespawnState = new PropPlaneDespawnState(AvailableStates.Despawn);

    public int Health = 3;
    
    public enum AvailableStates {
        Fly,
        Die,
        Despawn,
    }
    
    [HideInInspector]public Rigidbody2D Body;
    [HideInInspector]public Path Path;

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
    }
}
