using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Popup : MonoBehaviour {
    [SerializeField] GameObject popupPanel;
    [SerializeField] Button closeBtn;
    [SerializeField] float delayTime = 0.5f;
    [SerializeField] bool isInactiveStart = true;

    public float DelayTime { get { return delayTime; } }

    #region Events
    public event Action OnPopupOpened;
    #endregion

    public virtual void Start() {
        //Set Default Active Status
        if (isInactiveStart) {
            popupPanel.SetActive(false);
        } else {
            popupPanel.SetActive(true);
        }
    }

    public virtual void OnEnable() {
        closeBtn.interactable = true;
    }

    //Open Panel
    public virtual void OpenPanel() {
        popupPanel.SetActive(true);
        OnPopupOpened?.Invoke();
        GameManager.Instance.PauseGame();
    }

    //Close Panel
    public virtual void ClosePanel() {
        PlayBtnSFX();
        StartCoroutine(DelayClose());
    }

    //Adds Delay to Close for Button Animations & SFX
    private IEnumerator DelayClose() {
        yield return new WaitForSeconds(delayTime);
        popupPanel.SetActive(false);
        closeBtn.interactable = true;
        GameManager.Instance.ResumeGame();
    }

    public void PlayBtnSFX() {
        SoundManager.Instance.PlayBtnSFX();
    }
}
