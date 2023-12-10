using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Settings : UI_Popup {
    [SerializeField] Toggle toggleSFX;
    [SerializeField] Toggle toggleMusic;
    [SerializeField] Slider audioSlider;

    #region Events
    public event Action OnToggleSFX;
    public event Action OnToggleMusic;
    public event Action OnAdjustedAudioSlider;
    #endregion

    public override void Start() {
        base.Start();
        OnToggleSFX += ToggleSFX;
        OnToggleMusic += ToggleMusic;
        OnAdjustedAudioSlider += AdjustAudioSlider;
    }

    private void OnDestroy() {
        OnToggleSFX -= ToggleSFX;
        OnToggleMusic -= ToggleMusic;
        OnAdjustedAudioSlider -= AdjustAudioSlider;
    }

    private void ToggleSFX() {
        SoundManager.Instance.IsSFXEnabled = !toggleSFX.isOn;
    }

    private void ToggleMusic() {
        SoundManager.Instance.IsMusicEnabled = !toggleMusic.isOn;
    }

    private void AdjustAudioSlider() {
        SoundManager.Instance.UpdateMusicVolume(audioSlider.value);
        SoundManager.Instance.UpdateSFXVolume(audioSlider.value);
    }

    public void ToggleSFXListener() {
        OnToggleSFX?.Invoke();
    }

    public void ToggleMusicListener() {
        OnToggleMusic?.Invoke();
    }

    public void AdjustedSliderListener() {
        OnAdjustedAudioSlider?.Invoke();
    }
}
