using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public abstract class StateMachine: MonoBehaviour {
    protected BaseState[] States;

    protected BaseState CurrentState;
    protected BaseState NextState;

    void Start() {
        CurrentState.EnterState();
    }

    void Update() {
        if (NextState.Equals(CurrentState)) {
            CurrentState.UpdateState();
        }
        else {
            TransitionToState(NextState);
        }
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

    private void TransitionToState(BaseState state) {
        CurrentState.ExitState();
        CurrentState = state;
        CurrentState.EnterState();
    }
}
