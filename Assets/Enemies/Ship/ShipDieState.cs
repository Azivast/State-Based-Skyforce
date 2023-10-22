using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

[Serializable]
public class  ShipDieState : BaseState< ShipBehaviour.AvailableStates> {

    [SerializeField] private GameObject ExplosionPrefab;
    [SerializeField] private GameObject SmokePrefab;
    [SerializeField] private GameObject ScorePrefab;
    [SerializeField] private Sprite destroyedSprite;
    [SerializeField] private SpriteRenderer renderer;
    private ShipBehaviour behaviour;
    
    public ShipDieState(ShipBehaviour.AvailableStates key) : base(key) { }
    
    public void SetupState(ShipBehaviour stateMachine) {
        base.SetupState(stateMachine);
        behaviour = stateMachine;
    }

    public override void EnterState() {
        MonoBehaviour.Instantiate(ExplosionPrefab, behaviour.transform.position, behaviour.transform.rotation);
        MonoBehaviour.Instantiate(ScorePrefab, behaviour.transform.position, Quaternion.identity);
        SmokePrefab.SetActive(true);
        renderer.sprite = destroyedSprite;
    }

    public override void ExitState() {
    }
}