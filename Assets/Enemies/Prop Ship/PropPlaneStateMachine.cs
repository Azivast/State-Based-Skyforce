using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PropPlaneStateMachine : StateMachine<PropPlaneStateMachine.PropPlaneState> {
    public enum PropPlaneState {
        Fly,
        Die,
        Dead,
    }

    private void Awake() {
        CurrentState = States[PropPlaneState.Fly];
    }

    private void Start() {
        States.Add(PropPlaneState.Fly, new PropPlaneFlyState(PropPlaneState.Fly));
    }
}
