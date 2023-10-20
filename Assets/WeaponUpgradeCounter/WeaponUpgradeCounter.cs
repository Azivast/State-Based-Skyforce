using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgradeCounter : MonoBehaviour {
   [SerializeField] private WeaponStatsObject stats;
   [SerializeField] private Image bar;

   private void OnEnable() {
      stats.OnUpgrade += SyncBar;
   }

   private void OnDisable() {
      stats.OnUpgrade -= SyncBar;
   }

   private void SyncBar(float fillAmount) {
      bar.fillAmount = fillAmount;
   }
}
