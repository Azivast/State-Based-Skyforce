using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetFighterStateMachine : StateMachine<JetFighterStateMachine.JetFighterState> {
    public enum JetFighterState {
        Fly,
        Die,
        Dead,
    }
}
