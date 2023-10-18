using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position, 0.15f);
    }
}
