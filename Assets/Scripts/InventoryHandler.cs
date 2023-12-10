using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour {
    [SerializeField] InventorySO inventory;

    public int Currency { get { return inventory.Currency; } protected set { inventory.Currency = value; } }
    public List<ItemSO> Items { get { return inventory.Items; } }

    private int GetItemIndexFromInventory(ItemSO item) {
        for (int i = 0;i < inventory.Items.Count;i++) {
            if (inventory.Items[i] == item) {
                return i;
            }
        }
        return -1;
    }

    private int GetItemIndexFromInventoryViaID(int id) {
        ItemSO item = GetItemFromInventoryViaID(id);
        if (item != null) {
            int index = GetItemIndexFromInventory(item);
            return index;
        }

        return -1;
    }

    private ItemSO GetItemFromInventoryViaID(int id) {
        foreach (ItemSO item in inventory.Items) {
            if (item.ItemID == id) {
                return item;
            }
        }

        Debug.Log("Item not in Inventory");
        return null;
    }

    private int GetItemQuantityViaID(int id) {
        int quantity = 0;
        foreach (ItemSO item in inventory.Items) {
            if (item.ItemID == id) {
                quantity++;
            }
        }

        return quantity;
    }

    public void AddCurrency(int amountToAdd) {
        inventory.Currency += amountToAdd;
    }

    public void DeductCurrency(int amountToDeduct) {
        int tempCurrency = inventory.Currency - amountToDeduct;
        if (tempCurrency < 0) {
            Debug.Log("Insufficient Funds");
            return;
        }
        
        inventory.Currency = tempCurrency;
    }

    public void AddItem(ItemSO item) {
        inventory.Items.Add(item);
        Debug.Log(item.ItemName + " has been added to Inventory");
    }

    public void RemoveItem(ItemSO item) {
        int itemIndex = GetItemIndexFromInventory(item);
        inventory.Items.RemoveAt(itemIndex);
        Debug.Log(item.ItemName + " has been removed from Inventory");
    }

    public void GetItemValueViaID(int id) {

    }
}
