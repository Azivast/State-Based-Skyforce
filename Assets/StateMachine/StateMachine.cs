using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public abstract class StateMachine<EState> : MonoBehaviour where EState : Enum {
    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();

    protected BaseState<EState> CurrentState;

    private void Start() {
        CurrentState.EnterState();
    }

    private void Update() {
        CurrentState.UpdateState();
    }
    
    private void FixedUpdate() {
        CurrentState.FixedUpdateState();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        CurrentState.OnCollisionEnter2D(other);
    }

    private void OnCollisionStay2D(Collision2D other) {
        CurrentState.OnCollisionStay2D(other);
        
    }

    private void OnCollisionExit2D(Collision2D other) {
        CurrentState.OnCollisionExit2D(other);
    }

    public void TransitionToState(EState stateKey) {
        CurrentState.ExitState();
        CurrentState = States[stateKey];
        CurrentState.EnterState();
    }
}
