using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

[Serializable]
public class  HeliDieState : BaseState< HeliBehaviour.AvailableStates> {

    [SerializeField] private GameObject ExplosionPrefab;
    [SerializeField] private GameObject ScorePrefab;
    private  HeliBehaviour behaviour;
    
    public  HeliDieState(HeliBehaviour.AvailableStates key) : base(key) { }
    
    public void SetupState(HeliBehaviour stateMachine) {
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
        TransitionToState(HeliBehaviour.AvailableStates.Despawn);
    }

}