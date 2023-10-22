using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

[Serializable]
public class HeliFlyState : BaseState<HeliBehaviour.AvailableStates> {
    
    [SerializeField] private float speed = 3;
    [SerializeField] private int rotationSpeed = 2;
    [SerializeField] private int ramDamage = 1;
    
    private HeliBehaviour behaviour => (HeliBehaviour)stateMachine;
    private Path path;
    private int targetCheckpointIndex;
    [SerializeField] private Vector2 target;
    private const float TARGETMARGIN = 0.5f;
    
    public HeliFlyState (HeliBehaviour.AvailableStates key) : base(key) { }

    public void SetupState(HeliBehaviour stateMachine, Path path) {
        base.SetupState(stateMachine);
        this.path = path;
        targetCheckpointIndex = 1; //  Ship will be instantiated at checkpoint 0 so first target is 1
        target = path.GetCheckpoint(targetCheckpointIndex);
    }
    
    public override void EnterState() {

    }

    public override void ExitState() {
        behaviour.Body.velocity = Vector2.zero;
    }

    public override void UpdateState() {
        var dist = target - (Vector2)behaviour.transform.position;
        if (dist.magnitude <= TARGETMARGIN) {
            NextTarget();
        }
        
        Vector2 current = -behaviour.transform.up;
        Vector2 to = (Vector3)target - behaviour.transform.position;
        behaviour.transform.up = -Vector3.RotateTowards(current, to, rotationSpeed * Time.deltaTime, 0f);

    }

    public override void FixedUpdateState() {
        behaviour.Body.velocity = -behaviour.transform.up * speed;
    }


    public override void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Enemies")) return;
        
        if (other.collider.TryGetComponent(out IDamageable damageable)) {
            damageable.Damage(ramDamage);
            behaviour.Health = 0;
            TransitionToState(HeliBehaviour.AvailableStates.Die);
        }
    }

    private void NextTarget() {
        targetCheckpointIndex++;
        if (targetCheckpointIndex < path.Checkpoints.Count) {
            target = path.GetCheckpoint(targetCheckpointIndex);
            TransitionToState(HeliBehaviour.AvailableStates.Shoot);
        }
        else {
            TransitionToState(HeliBehaviour.AvailableStates.Despawn);
        }
    }
}