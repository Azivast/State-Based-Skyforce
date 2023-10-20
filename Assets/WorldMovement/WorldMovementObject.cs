using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "WorldMovement", menuName = "WorldMovementObject")]
public class WorldMovementObject : ScriptableObject { 
    public Vector2 BackgroundMovement; 
    public Vector2 ForegroundMovement;
}
