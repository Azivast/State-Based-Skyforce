using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PropPlaneStateMachine : StateMachine {

    protected BaseState[] States;
    
    public enum PropPlaneState {
        Fly,
        Die,
        Dead,
    }

    private void Awake() {
        //CurrentState = States[PropPlaneState.Fly];
    }
}
