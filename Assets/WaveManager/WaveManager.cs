using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {
    [SerializeField] private WaveObject[] waves;
    [SerializeField] private Path[] Paths;
    [SerializeField] private float timeBetweenWaves = 5f;

    private int currentWave = 0;
    private bool spawningWave = false;

    private void OnValidate() {
        if (Paths.Length != waves.Length) {
            Debug.LogWarning("Number of Waves and Paths must be equal.");
        }
        
    }

    private IEnumerator SpawnWave(int index) {
        currentWave++;
        
        foreach (GameObject enemyPrefab in waves[index].Enemies) {
            var path = Paths[index];
            var enemy = Instantiate(enemyPrefab, path.GetFirstCheckpoint(), Quaternion.identity);
            enemy.GetComponent<PropPlaneBehaviour>().Path = path; // TODO: Reduce coupling
            yield return new WaitForSeconds(waves[index].TimeBetweenEnemies);
        }
        
        yield return new WaitForSeconds(timeBetweenWaves);
        spawningWave = false;
    }

    private void NextWave() {
        spawningWave = true;
        StartCoroutine(SpawnWave(currentWave));
        currentWave++;
    }

    private void Update() { //TODO: fixed update?
        if (currentWave >= waves.Length) return;

        if (spawningWave == false) NextWave();
    }
}
