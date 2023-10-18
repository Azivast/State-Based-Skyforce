using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class PropPlaneDespawnState : BaseState<PropPlaneBehaviour.AvailableStates> {

    public PropPlaneDespawnState(PropPlaneBehaviour.AvailableStates key) : base(key) { }

    public void SetupState(PropPlaneBehaviour stateMachine) {
        base.SetupState(stateMachine);
    }

    public override void EnterState() {
        MonoBehaviour.Destroy(stateMachine.gameObject);
    }

    public override void ExitState() {
    }
}