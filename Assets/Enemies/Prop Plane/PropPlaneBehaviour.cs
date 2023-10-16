using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PropPlaneBehaviour : StateMachine<PropPlaneBehaviour.AvailableStates> {
    [SerializeField] private PropPlaneFlyState FlyState = new PropPlaneFlyState(AvailableStates.Fly);
    [SerializeField] private PropPlaneFlyState DespawnState = new PropPlaneFlyState(AvailableStates.Despawn)
        ;
    
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
        States.Add(AvailableStates.Despawn, DespawnState);
    }

    private void Start() {
        FlyState.SetupState(this, Path);
    }
}
