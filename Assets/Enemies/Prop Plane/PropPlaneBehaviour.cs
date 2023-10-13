using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PropPlaneBehaviour : MonoBehaviour {
    [SerializeField] private PropPlaneFlyState FlyState = new PropPlaneFlyState();
    
    protected Dictionary<AvailableStates, BaseState> States = new Dictionary<AvailableStates, BaseState>();
    public enum AvailableStates {
        Fly,
    }
    
    private BaseState CurrentState;
    public BaseState NextState;
    
    
    [HideInInspector]public Rigidbody2D Body;
    [HideInInspector]public Path Path;

    private void Awake() {
        Body = GetComponent<Rigidbody2D>();
        States.Add(AvailableStates.Fly, FlyState);
    }

    private void Start() {
        FlyState.SetupState(this, Path);
        
        CurrentState = States[AvailableStates.Fly];
        NextState = CurrentState;
        
        CurrentState.EnterState();
    }

    private void Update() {
        if (NextState.Equals(CurrentState)) {
            CurrentState.UpdateState();
        }
        else {
            TransitionToState(NextState);
        }
    }
    private void FixedUpdate() {
        CurrentState.FixedUpdateState();
    }

    private void TransitionToState(BaseState state) {
        CurrentState.ExitState();
        CurrentState = state;
        CurrentState.EnterState();
    }
}
