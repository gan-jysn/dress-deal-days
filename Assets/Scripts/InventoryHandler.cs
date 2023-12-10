using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour {
    [SerializeField] InventorySO inventory;
    [SerializeField] EquipmentHandler equipmentHandler;
    [SerializeField] UI_Inventory inventoryUI;

    public int Currency { get { return inventory.Currency; } }
    public List<ItemSO> Items { get { return inventory.Items; } }

    #region Events
    public event Action OnItemStored;
    #endregion

    private void Start() {
        /*equipmentHandler.OnEquipClothing += () => {
            ItemSO item = (ItemSO) equipmentHandler.CurrentClothes;
            inventory.RemoveItem(item);
        };*/
    }

    public ItemSO GetPlayerItemViaID(int id) {
        return GetItemViaID(inventory, id);
    }

    private ItemSO GetItemViaID(InventorySO inventory, int id) {
        return inventory.GetItemViaID(id);
    }

    public void AddCurrency(int amount) {
        inventory.AddCurrency(amount);
    }

    public bool TryBuyItem(ItemSO item) {
        int cost = item.Value;
        if (inventory.TryDeductCurrency(cost)) {
            //Buy Item
            inventory.DeductCurrency(cost);
            inventory.AddItem(item);
            return true;
        }
        Debug.Log("Insufficient Funds");
        return false;
    }

    public void SellItem(ItemSO item) {
        RemoveItem(item);
        AddCurrency(item.Value);
    }

    public void StoreItem(ItemSO item) {
        inventory.AddItem(item);
        OnItemStored?.Invoke();
    }

    public void EquiptItem(ItemSO item) {
        if (equipmentHandler != null) {
            equipmentHandler.EquiptItem(item);
            RemoveItem(item);
        }
    }

    private void RemoveItem(ItemSO item) {
        inventory.RemoveItem(item);
        inventoryUI.UpdateInventory();
    }
}
