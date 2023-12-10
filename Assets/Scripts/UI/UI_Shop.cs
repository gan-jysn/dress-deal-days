using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Shop : UI_Popup {
    [Header("Shop References")]
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform itemViewContainer;
    [SerializeField] ShopHandler shopHandler;

    [Header("UI Elements - Panels")]
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject buyPanel;
    [SerializeField] GameObject sellPanel;

    [Header("UI Elements - Buttons")]
    [SerializeField] Button buyBtn;
    [SerializeField] Button sellBtn;

    private void Start() {
        ResetPanelUI();
    }

    public void ResetPanelUI() {
        menuPanel.SetActive(true);
        buyPanel.SetActive(false);
        sellPanel.SetActive(false);
    }

    public void OpenBuyPanel() {
        SoundManager.Instance.PlayBtnSFX();
        StartCoroutine(DelayAction(() => {
            menuPanel.SetActive(false);
            buyPanel.SetActive(true);
        }));
    }

    public void OpenSellPanel() {
        SoundManager.Instance.PlayBtnSFX();
        StartCoroutine(DelayAction(() => {
            menuPanel.SetActive(false);
            sellPanel.SetActive(true);
        }));
    }

    public void ReturnToMenu() {
        SoundManager.Instance.PlayBtnSFX();
        StartCoroutine(DelayAction(() => {
            buyPanel.SetActive(false);
            sellPanel.SetActive(false);
            menuPanel.SetActive(true);

            buyBtn.interactable = true;
            sellBtn.interactable = true;
        }));
    }

    private IEnumerator DelayAction(Action action) {
        yield return new WaitForSeconds(DelayTime);
        action?.Invoke();
    }
}
