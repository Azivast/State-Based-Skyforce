using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public abstract class StateMachine<EState> : MonoBehaviour where EState : Enum {
    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();

    protected BaseState<EState> CurrentState;

    void Start() {
        CurrentState.EnterState();
    }

    void Update() {
        EState nextStateKey = CurrentState.GetNextState();

        if (nextStateKey.Equals(CurrentState.StateKey)) {
            CurrentState.UpdateState();
        }
        else {
            TransitionToState(nextStateKey);
        }
    }
    
    private void FixedUpdate() {
        CurrentState.FixedUpdateState();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        CurrentState.OnTriggerEnter2D(col);
    }

    private void OnTriggerStay2D(Collider2D col) {
        CurrentState.OnTriggerStay2D(col);
        
    }

    private void OnTriggerExit2D(Collider2D col) {
        CurrentState.OnTriggerExit2D(col);
    }

    private void TransitionToState(EState stateKey) {
        CurrentState.ExitState();
        CurrentState = States[stateKey];
        CurrentState.EnterState();
    }
}
