using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    private bool isGamePaused = true;

    public bool IsGamePaused { get { return isGamePaused; } }

    #region Events
    public event Action OnGamePaused;
    public event Action OnGameResumed;
    #endregion

    private void Start() {
        ResetParameters();
    }

    public void ResetParameters() {
        isGamePaused = false;
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
