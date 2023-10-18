using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

[Serializable]
public class PropPlaneDieState : BaseState<PropPlaneBehaviour.AvailableStates> {

    [SerializeField] private GameObject ExplosionPrefab;
    [SerializeField] private GameObject ScorePrefab;
    
    public PropPlaneDieState(PropPlaneBehaviour.AvailableStates key) : base(key) { }
    
    public void SetupState(PropPlaneBehaviour stateMachine) {
        base.SetupState(stateMachine);
    }

    public override void EnterState() {
        MonoBehaviour.Instantiate(ExplosionPrefab, stateMachine.transform.position, stateMachine.transform.rotation);
        MonoBehaviour.Instantiate(ScorePrefab, stateMachine.transform.position, stateMachine.transform.rotation);
    }

    public override void ExitState() {
    }

    public override void UpdateState() { 
        TransitionToState(PropPlaneBehaviour.AvailableStates.Despawn);
    }
}