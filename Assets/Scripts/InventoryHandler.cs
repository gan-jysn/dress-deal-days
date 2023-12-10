using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour {
    [SerializeField] InventorySO inventory;

    public int Currency { get { return inventory.Currency; } }
    public List<ItemSO> Items { get { return inventory.Items; } }

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
        inventory.RemoveItem(item);
        AddCurrency(item.Value);
    }
}
