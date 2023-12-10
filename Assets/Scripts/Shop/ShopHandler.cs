using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHandler : MonoBehaviour {
    [SerializeField] InventorySO shopInventory;
    [SerializeField] UI_Shop shopUI;
    [SerializeField] ShopTrigger trigger;

    private void Start() {
        if (trigger == null) {
            trigger = FindObjectOfType<ShopTrigger>();
        }

        AddEventCallbacks();
    }

    private void OnDestroy() {
        RemoveEventCallbacks();
    }

    private void AddEventCallbacks() {
        if (trigger != null) {
            trigger.OnInteract += OpenShop;
        }
    }

    private void RemoveEventCallbacks() {
        if (trigger != null) {
            trigger.OnInteract -= OpenShop;
        }
    }

    public void OpenShop() {
        shopUI.OpenPanel();
        shopUI.ResetPanelUI();
    }
}
