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

            Quaternion rotation = path.Checkpoints.Count == 1
                ? Quaternion.identity
                : Quaternion.FromToRotation(Vector3.down,
                    ((Vector3)path.GetCheckpoint(1) - path.GetFirstCheckpoint()).normalized);

            var enemy = Instantiate(enemyPrefab, path.GetFirstCheckpoint(), rotation);
            if (enemy.TryGetComponent<IPathFollower>(out var pathFollower)) {
                pathFollower.Path = path;
            }
            
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
