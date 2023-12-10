using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    private bool isGamePaused = true;
    private bool hasGameStarted = false;

    public bool IsGamePaused { get { return isGamePaused; } }

    #region Events
    public event Action OnGamePaused;
    public event Action OnGameResumed;
    public event Action OnGameStarted;
    #endregion

    private void Start() {
        ResetParameters();
        SoundManager.Instance.PlayTitleBGM();

        OnGameStarted += OnGameStart;
    }

    private void OnDestroy() {
        OnGameStarted -= OnGameStart;
    }

    private void ResetParameters() {
        isGamePaused = false;
        hasGameStarted = false;
    }

    public void StartGame() {
        OnGameStarted?.Invoke();
    }

    private void OnGameStart() {
        hasGameStarted = true;
        SoundManager.Instance.PlayGameBGM();
    }

    public void PauseGame() {
        isGamePaused = true;
        OnGamePaused?.Invoke();
    }

    public void ResumeGame() {
        isGamePaused = false;
        OnGameResumed?.Invoke();
    }
}
