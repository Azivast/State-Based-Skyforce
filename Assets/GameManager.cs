using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {
    [SerializeField] private UnityEvent OnLevelStart;
    private void OnEnable() {
        OnLevelStart.Invoke();
    }
}
