using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class WaveManager : MonoBehaviour { 
    [SerializeField] private Wave[] waves;

    [SerializeField]private int currentWave = 0;
    [SerializeField]private bool spawningWave = false;

    public UnityAction OnAllWavesSpawned = delegate { };

    private IEnumerator SpawnWave(int index) {
        foreach (GameObject enemyPrefab in waves[index].wave.Enemies) {
            var path = waves[index].path;

            Quaternion rotation = path.Checkpoints.Count == 1
                ? Quaternion.identity
                : Quaternion.FromToRotation(Vector3.down,
                    ((Vector3)path.GetCheckpoint(1) - path.GetFirstCheckpoint()).normalized);

            var enemy = Instantiate(enemyPrefab, path.GetFirstCheckpoint(), rotation);
            if (enemy.TryGetComponent<IPathFollower>(out var pathFollower)) {
                pathFollower.Path = path;
            }
            
            yield return new WaitForSeconds(waves[index].wave.TimeBetweenEnemies);
        }
        
        yield return new WaitForSeconds(waves[index].cooldownAfterWave);
        spawningWave = false;
    }

    private void NextWave() {
        spawningWave = true;
        StartCoroutine(SpawnWave(currentWave));
        currentWave++;
        if (currentWave >= waves.Length) OnAllWavesSpawned.Invoke();
    }

    private void Update() {
        if (currentWave >= waves.Length) return;

        if (spawningWave == false) NextWave();
    }
    
    [Serializable]
    private struct Wave {
        public WaveObject wave;
        public Path path;
        public float cooldownAfterWave;
    }
}
