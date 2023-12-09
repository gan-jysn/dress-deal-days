using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : SingletonPersistent<SoundManager> {
    private const string VOLUME_SFX = "volume_sfx";
    private const string VOLUME_MUSIC = "volume_music";
    private const int SOUND_POOL_LENGTH = 10;

    [SerializeField] bool isMusicEnabled = true;
    [SerializeField] bool isSFXEnabled = true;
    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] GameObject audioSourcePrefab;

    //[SerializeField, FoldoutGroup("Audio Clips", Expanded = false)] AudioClip buttonSFX;

    private float volumeSFX;
    private float volumeMusic;
    private List<GameObject> sourcePool = new List<GameObject>();

    public bool IsMusicEnabled { get { return isMusicEnabled; } set { isMusicEnabled = value; } }
    public bool IsSFXEnabled { get { return isSFXEnabled; } set { isSFXEnabled = value; } }


    public override void Awake() {
        base.Awake();

        //SFX ObjectPool
        CreateSourcePool();
    }

    private void Start() {
        UpdateVolume();
    }

    private void CreateSourcePool() {
        for (int i = 0; i < SOUND_POOL_LENGTH; i++) {
            GameObject obj = Instantiate(audioSourcePrefab);
            obj.transform.parent = transform;
            sourcePool.Add(obj);
        }
    }

    private void UpdateVolume() {
        volumeSFX = PlayerPrefs.GetFloat(VOLUME_SFX);
        volumeMusic = PlayerPrefs.GetFloat(VOLUME_MUSIC);
        mixer.SetFloat(MixerGroup.SFX.ToString(), Mathf.Log10(volumeSFX) * 20);
        mixer.SetFloat(MixerGroup.Music.ToString(), Mathf.Log10(volumeMusic) * 20);
    }

    public void UpdateSFXVolume(float volume) {
        volumeSFX = volume;
        PlayerPrefs.SetFloat(VOLUME_SFX, volume);
        mixer.SetFloat(MixerGroup.SFX.ToString(), Mathf.Log10(volumeSFX) * 20);
    }

    public void UpdateMusicVolume(float volume) {
        volumeMusic = volume;
        PlayerPrefs.SetFloat(VOLUME_MUSIC, volume);
        mixer.SetFloat(MixerGroup.Music.ToString(), Mathf.Log10(volumeMusic) * 20);
    }

    public void PlaySound() {
        if (!isMusicEnabled)
            return;
    }

    public void PlaySFX() {
        if (!isSFXEnabled)
            return;
    }
}

public enum MixerGroup {
    Music,
    SFX
}

