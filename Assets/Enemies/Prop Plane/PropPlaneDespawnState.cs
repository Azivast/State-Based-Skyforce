using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

[Serializable]
public class PropPlaneDespawnState : BaseState<PropPlaneBehaviour.AvailableStates> {
    
    private PropPlaneBehaviour behaviour;
    
    public PropPlaneDespawnState(PropPlaneBehaviour.AvailableStates key) : base(key) { }
    
    public void SetupState(PropPlaneBehaviour behaviour) {
        this.behaviour = behaviour;
    }

    public override void EnterState() {
        MonoBehaviour.Destroy(behaviour.gameObject);
    }

    public override void ExitState() {
    }
    
    public override PropPlaneBehaviour.AvailableStates GetNextState() {
        return PropPlaneBehaviour.AvailableStates.Despawn;
    }

}