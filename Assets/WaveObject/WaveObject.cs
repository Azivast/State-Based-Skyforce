using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "WaveObject")]
public class WaveObject : ScriptableObject
{
    public GameObject[] Enemies;
    public float TimeBetweenEnemies = 1f;
}
