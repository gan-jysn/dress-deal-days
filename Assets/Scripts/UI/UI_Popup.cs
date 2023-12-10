using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Popup : MonoBehaviour {
    [SerializeField] GameObject popupPanel;
    [SerializeField] Button closeBtn;
    [SerializeField] float delayTime = 0.75f;

    public float DelayTime { get { return delayTime; } }

    #region Events
    public event Action OnPopupOpened;
    #endregion

    public virtual void Start() {
        //Set Default Active Status
        popupPanel.SetActive(false);
    }

    public virtual void OnEnable() {
        closeBtn.interactable = true;
    }

    //Open Panel
    public void OpenPanel() {
        popupPanel.SetActive(true);
        OnPopupOpened?.Invoke();
    }

    //Close Panel
    public void ClosePanel() {
        PlayBtnSFX();
        StartCoroutine(DelayClose());
    }

    //Adds Delay to Close for Button Animations & SFX
    private IEnumerator DelayClose() {
        yield return new WaitForSeconds(delayTime);
        popupPanel.SetActive(false);
        closeBtn.interactable = true;
    }

    public void PlayBtnSFX() {
        SoundManager.Instance.PlayBtnSFX();
    }
}
