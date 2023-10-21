using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

[Serializable]
public class  ShipDespawnState : BaseState< ShipBehaviour.AvailableStates> {
    
    private ShipBehaviour behaviour;
    
    public  ShipDespawnState(ShipBehaviour.AvailableStates key) : base(key) { }
    
    public void SetupState(ShipBehaviour stateMachine) {
        base.SetupState(stateMachine);
        behaviour = stateMachine;
    }

    public override void EnterState() {
        MonoBehaviour.Destroy(behaviour.gameObject);
    }

    public override void ExitState() {
    }

}