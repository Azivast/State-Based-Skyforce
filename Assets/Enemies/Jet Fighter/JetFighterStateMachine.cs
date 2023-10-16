using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetFighterStateMachine : StateMachine<PropPlaneBehaviour.AvailableStates> {
    public enum AvailableStates {
        Fly,
        Die,
        Dead,
    }
}
