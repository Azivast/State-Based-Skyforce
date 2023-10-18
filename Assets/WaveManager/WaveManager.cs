using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {
    [SerializeField] private WaveObject[] waves;
    [SerializeField] private Path[] paths;
    [SerializeField] private float[] cooldownAfterWave;

    [SerializeField]private int currentWave = 0;
    [SerializeField]private bool spawningWave = false;

    private void OnValidate() {
        if (paths.Length != waves.Length) {
            Debug.LogWarning("Number of Waves and Paths must be equal.");
        }
        if (paths.Length != waves.Length) {
            Debug.LogWarning("Number of Waves and Paths must be equal.");
        }
    }

    private IEnumerator SpawnWave(int index) {
        foreach (GameObject enemyPrefab in waves[index].Enemies) {
            var path = paths[index];
            var enemy = Instantiate(enemyPrefab, path.GetFirstCheckpoint(), Quaternion.identity);
            enemy.GetComponent<IPathFollower>().Path = path; // TODO: Reduce coupling
            yield return new WaitForSeconds(waves[index].TimeBetweenEnemies);
        }
        
        yield return new WaitForSeconds(cooldownAfterWave[index]);
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
