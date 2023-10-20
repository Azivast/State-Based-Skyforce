using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "WeaponStatsObject")]
public class WeaponStatsObject : ScriptableObject {
    [SerializeField] private float fireRate = 1;
    [SerializeField] private float fireRateIncrease = 0.5f;
    [SerializeField] private float maxUpgrades = 10;
    private float equipedUpgrades = 0;
    
    private readonly float startfireRate = 1;
    
    public UnityAction<float> OnUpgrade = delegate{};

    public float FireRate => fireRate;

    public void Upgrade() {
        if (equipedUpgrades < maxUpgrades) {
            fireRate += fireRateIncrease;
            equipedUpgrades++;
            OnUpgrade.Invoke(equipedUpgrades/maxUpgrades);
        }
    }

    public void Reset() {
        equipedUpgrades = 0;
        fireRate = startfireRate;
        OnUpgrade.Invoke(equipedUpgrades/maxUpgrades);
    }
}