using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

[Serializable]
public class  ShipDieState : BaseState< ShipBehaviour.AvailableStates> {

    [SerializeField] private GameObject ExplosionPrefab;
    [SerializeField] private GameObject ScorePrefab;
    private  ShipBehaviour behaviour;
    
    public  ShipDieState(ShipBehaviour.AvailableStates key) : base(key) { }
    
    public void SetupState(ShipBehaviour stateMachine) {
        base.SetupState(stateMachine);
        behaviour = stateMachine;
    }

    public override void EnterState() {
        MonoBehaviour.Instantiate(ExplosionPrefab, behaviour.transform.position, behaviour.transform.rotation);
        MonoBehaviour.Instantiate(ScorePrefab, behaviour.transform.position, Quaternion.identity);
    }

    public override void ExitState() {
    }
    
    public override void UpdateState() { 
        TransitionToState(ShipBehaviour.AvailableStates.Despawn);
    }

}