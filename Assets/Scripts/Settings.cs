using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Button closeButton;
    [SerializeField] private float closeDelayTime = 0.25f;

    private void Start() {
        //Set Default Active Status
        settingsPanel.SetActive(false);
    }

    private void OnEnable() {
        closeButton.interactable = true;
    }

    //Open Settings Panel
    public void OpenPanel() {
        settingsPanel.SetActive(true);
    }

    //Close Settings Panel
    public void ClosePanel() {
        StartCoroutine(DelayClose());
    }

    //Adds Delay to Close for Button Animations & SFX
    private IEnumerator DelayClose() {
        yield return new WaitForSeconds(closeDelayTime);
        settingsPanel.SetActive(false);
        closeButton.interactable = true;
    }
}
