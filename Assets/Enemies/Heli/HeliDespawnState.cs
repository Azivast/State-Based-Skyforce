using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

[Serializable]
public class  HeliDespawnState : BaseState< HeliBehaviour.AvailableStates> {
    
    private HeliBehaviour behaviour;
    
    public  HeliDespawnState(HeliBehaviour.AvailableStates key) : base(key) { }
    
    public void SetupState(HeliBehaviour stateMachine) {
        base.SetupState(stateMachine);
        behaviour = stateMachine;
    }

    public override void EnterState() {
        MonoBehaviour.Destroy(behaviour.gameObject);
    }

    public override void ExitState() {
    }

}