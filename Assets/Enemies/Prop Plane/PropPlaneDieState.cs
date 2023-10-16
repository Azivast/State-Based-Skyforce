using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

[Serializable]
public class PropPlaneDieState : BaseState<PropPlaneBehaviour.AvailableStates> {

    [SerializeField] private GameObject ExplosionPrefab;
    [SerializeField] private GameObject ScorePrefab;
    private PropPlaneBehaviour behaviour;
    
    public PropPlaneDieState(PropPlaneBehaviour.AvailableStates key) : base(key) { }
    
    public void SetupState(PropPlaneBehaviour behaviour) {
        this.behaviour = behaviour;
    }

    public override void EnterState() {
        MonoBehaviour.Instantiate(ExplosionPrefab, behaviour.transform.position, behaviour.transform.rotation);
    }

    public override void ExitState() {
    }
    
    public override PropPlaneBehaviour.AvailableStates GetNextState() {
        return PropPlaneBehaviour.AvailableStates.Despawn;
    }

}