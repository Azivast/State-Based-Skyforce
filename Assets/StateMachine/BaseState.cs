using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState<EState> where EState : Enum {
    protected StateMachine<EState> stateMachine;
    
    public BaseState(EState key) {
        StateKey = key;
    }

    public EState StateKey { get; private set; }

    public void SetupState(StateMachine<EState> stateMachine) {
        this.stateMachine = stateMachine;
    }
    
    public abstract void EnterState();
    public abstract void ExitState();
    public virtual void UpdateState() { }
    public virtual void FixedUpdateState() { }

    public void TransitionToState(EState nextState) {
        stateMachine.TransitionToState(nextState);
    }
    public virtual void OnTriggerEnter2D(Collider2D col) { }
    public virtual void OnTriggerStay2D(Collider2D col) { }
    public virtual void OnTriggerExit2D(Collider2D col) { }
}
