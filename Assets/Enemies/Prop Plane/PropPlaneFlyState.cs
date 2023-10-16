using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

[Serializable]
public class PropPlaneFlyState : BaseState<PropPlaneBehaviour.AvailableStates>, IDamageable {
    
    [SerializeField] private float speed = 3;
    [SerializeField] private int ramDamage = 1;
    
    private PropPlaneBehaviour behaviour;
    private Path path;
    private int targetCheckpointIndex;
    [SerializeField] private Vector2 target;
    private float TARGETMARGIN = 0.5f;
    
    public PropPlaneFlyState(PropPlaneBehaviour.AvailableStates key) : base(key) { }

    public void SetupState(PropPlaneBehaviour behaviour, Path path) {
        this.behaviour = behaviour;
        this.path = path;
    }

    public override void EnterState() {
        targetCheckpointIndex = 1; //  Ship will be instantiated at checkpoint 0 so first target is 1
        target = path.GetCheckpoint(targetCheckpointIndex);
    }

    public override void ExitState() {
        behaviour.Body.velocity = Vector2.zero;
    }

    public override void UpdateState() {
        var dist = target - (Vector2)behaviour.transform.position;
        if (dist.magnitude <= TARGETMARGIN) {
            NextTarget();
        }
        
        Vector2 direction = ((Vector3)target - behaviour.transform.position).normalized;
        behaviour.transform.rotation = Quaternion.FromToRotation(Vector3.down, direction);
    }

    public override void FixedUpdateState() {
        behaviour.Body.velocity = ((Vector3)target - behaviour.transform.position).normalized * speed;
    }

    public override PropPlaneBehaviour.AvailableStates GetNextState() { // TODO: Cleaner implementation
        if (behaviour.Health <= 0) {
            return PropPlaneBehaviour.AvailableStates.Die;
        }
        else if ((path.GetLastCheckpoint() - behaviour.transform.position).magnitude <= TARGETMARGIN) {
            return PropPlaneBehaviour.AvailableStates.Despawn;
        }
        else return PropPlaneBehaviour.AvailableStates.Fly;
    }

    public override void OnTriggerEnter2D(Collider2D col) {
        if (col.TryGetComponent(out IDamageable damageable)) {
            damageable.Damage(ramDamage);
            behaviour.Health = 0;
        }
    }

    private void NextTarget() {
        targetCheckpointIndex++;
        if (targetCheckpointIndex < path.Checkpoints.Count) {
            target = path.GetCheckpoint(targetCheckpointIndex);
        }
    }
    
    public void Damage(int amount) {
        behaviour.Health = Math.Max(behaviour.Health - amount, 0);
    }
}