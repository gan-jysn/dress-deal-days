using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Popup : MonoBehaviour {
    [SerializeField] GameObject popupPanel;
    [SerializeField] Button closeBtn;
    [SerializeField] float closeDelay = 1.5f;

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
    }

    //Close Panel
    public void ClosePanel() {
        StartCoroutine(DelayClose());
    }

    //Adds Delay to Close for Button Animations & SFX
    private IEnumerator DelayClose() {
        yield return new WaitForSeconds(closeDelay);
        popupPanel.SetActive(false);
        closeBtn.interactable = true;
    }
}
