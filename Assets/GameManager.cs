using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] private UnityEvent OnLevelStart;
    [SerializeField] private GameObject winGUI;
    [SerializeField] private GameObject looseGUI;
    [SerializeField] private GameObject playingGUI;
    [SerializeField] private string mainMenuSceneName;
    [SerializeField] private float timeBeforeMainMenuWin = 7;
    [SerializeField] private float timeBeforeMainMenuLoose = 7;
    [SerializeField] private PlayerHealthObject playerHealth;
    [SerializeField] private WaveManager waveManager;
    private void OnEnable() {
        OnLevelStart.Invoke();
        playingGUI.SetActive(true);
        winGUI.SetActive(false);
        looseGUI.SetActive(false);

        playerHealth.OnPlayerDied += Loose;
        waveManager.OnAllWavesSpawned += Win;
    }

    private void OnDisable() {
        playerHealth.OnPlayerDied -= Loose;
        waveManager.OnAllWavesSpawned -= Win;
    }

    private void Win() {
        playingGUI.SetActive(false);
        winGUI.SetActive(true);
        StartCoroutine(Wait(timeBeforeMainMenuWin));

    }

    private void Loose() {
        playingGUI.SetActive(false);
        looseGUI.SetActive(true);
        StartCoroutine(Wait(timeBeforeMainMenuLoose));
    }
    
    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        SceneManager.LoadScene(mainMenuSceneName);
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            SceneManager.LoadScene(mainMenuSceneName);
        }
    }
}
