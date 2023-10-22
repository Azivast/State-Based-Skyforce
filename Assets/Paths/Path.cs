using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {
    public List<Transform> Checkpoints =  new List<Transform>();

    public Vector3 GetCheckpoint(int index) {
        return Checkpoints[index].position;
    }

    public Vector3 GetFirstCheckpoint() {
        return GetCheckpoint(0);
    }
    public Vector3 GetLastCheckpoint() {
        return GetCheckpoint(Checkpoints.Count-1);
    }

    public void OnDrawGizmos() {
        if (Checkpoints.Count == 0) return;
        
        Gizmos.color = Color.white;
        for (int i = 0; i < Checkpoints.Count-1; i++) {
            Gizmos.DrawLine(Checkpoints[i].position, Checkpoints[i+1].position);
        }
    }

    private void OnDrawGizmosSelected() {
        if (Checkpoints.Count == 0) return;
        
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.GetChild(0).position, 0.1f);
        for (int i = 0; i < transform.childCount-1; i++) {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i+1).position);
            Gizmos.DrawSphere(transform.GetChild(i).position, 0.1f);
        }
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.GetChild(transform.childCount-1).position, 0.1f);
    }

}
