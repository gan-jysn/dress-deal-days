using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : UI_Popup {
    [Header("Inventory References")]
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform itemViewContainer;
    [SerializeField] InventoryHandler inventoryHandler;

    [Header("Button References")]
    [SerializeField] Button useBtn;
    [SerializeField] TextMeshProUGUI useBtnTxt;
    [SerializeField] Button equipBtn;

    [Header("Item Info References")]
    [SerializeField] TextMeshProUGUI itemNameTxt;
    [SerializeField] TextMeshProUGUI itemDescTxt;

    private int activeItemID;
    private List<UI_Item> UIItems = new List<UI_Item>();

    public override void Start() {
        base.Start();
        ClearItemInfo();
        InitializeInventory();
    }

    public override void OnEnable() {
        base.OnEnable();
        UpdateInventory();

        //Select First Item
        if (UIItems.Count > 0) {
            UIItems[0].Select();
        }
    }

    public void ClearItemInfo() {
        itemNameTxt.text = "";
        itemDescTxt.text = "";
    }

    private void InitializeInventory() {
        if (inventoryHandler == null) {
            Debug.Log("Unable to Initialize Inventory");
            return;
        }

        int inventorySize = inventoryHandler.Items.Count;
        for (int i = 0;i < inventorySize;i++) {
            CreateItemPrefab(inventoryHandler.Items[i]);
        }
    }

    private void UpdateInventory() {
        int inventorySize = inventoryHandler.Items.Count;

        //Update Data
        for (int i = 0;i < inventorySize;i++) {
            ItemSO data = inventoryHandler.Items[i];
            UI_Item ui = UIItems[i];
            if (ui != null) {
                ui.gameObject.SetActive(true);
                ui.SetItemData(data);
                ui.UpdateUI();
            } else {
                CreateItemPrefab(data);
            }
        }

        //Check if there are left over UI Item GameObjects
        if (UIItems.Count > inventorySize) {
            int excessObjCount = UIItems.Count - inventorySize;

            for (int i = inventorySize - 1; i < UIItems.Count; i++) {
                UIItems[i].gameObject.SetActive(false);
            }
        }
    }

    private void CreateItemPrefab(ItemSO itemData) {
        GameObject obj = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity, itemViewContainer);
        obj.SetActive(true);
        UI_Item item = obj.GetComponent<UI_Item>();
        UIItems.Add(item);
        item.SetItemData(itemData);
        item.UpdateUI();
        //Subscribe to event OnUIItemClicked to setItemInfo
        item.OnItemSelected += SetItemInfo;
    }

    private UI_Item GetActiveItemData() {
        foreach (UI_Item item in UIItems) {
            if (item.ItemData.ItemID == activeItemID) {
                return item;
            }
        }

        Debug.Log("Unable to find ItemData");
        return null;
    }

    public void SetItemInfo(int itemID, ItemType type, string itemName, string itemDesc) {
        activeItemID = itemID;
        SetUseButton(type);
        itemNameTxt.text = itemName;
        itemDescTxt.text = itemDesc;
    }

    private void SetUseButton(ItemType type) {
        switch (type) {
            case ItemType.Clothing:
                useBtn.gameObject.SetActive(true);
                useBtnTxt.text = "Equipt Item";
                break;
            case ItemType.Consumable:
                useBtn.gameObject.SetActive(true);
                useBtnTxt.text = "Use Item";
                break;
            case ItemType.Trophy:
                useBtn.gameObject.SetActive(false);
                break;
        }
    }
}