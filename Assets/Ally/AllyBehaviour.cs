using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AllyBehaviour : MonoBehaviour {
    [SerializeField] private UnityEvent OnEnter;
    [SerializeField] private UnityEvent OnLeave;
    [SerializeField] private float timeForPickup = 3;
    [SerializeField] private int pickupScore = 1000;
    [SerializeField] private ScoreObject scoreObject;
    [SerializeField] private Image bar;
    private float timer = 0;

    private void Start() {
        transform.rotation = Quaternion.identity;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        timer = 0;
        OnEnter.Invoke();
    }

    private void OnTriggerStay2D(Collider2D other) {
        timer =  Mathf.Min(timer + Time.deltaTime, timeForPickup);
        bar.fillAmount = timer/timeForPickup;

        if (timer >= timeForPickup) {
            scoreObject.IncreaseScore(pickupScore);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        OnLeave.Invoke();
    }
}
