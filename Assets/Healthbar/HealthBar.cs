using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
   [SerializeField] private PlayerHealthObject health;
   [SerializeField] private Image bar;

   private void OnEnable() {
      health.OnHealthChange += SyncBar;
   }

   private void OnDisable() {
      health.OnHealthChange -= SyncBar;
   }

   private void SyncBar(int newHealth, int maxHealth) {
      bar.fillAmount = (float)newHealth/maxHealth;
   }
}
