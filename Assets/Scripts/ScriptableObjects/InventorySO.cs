using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Inventory")]
public class InventorySO : ScriptableObject {
    public int currency;
    public List<ItemSO> Items = new List<ItemSO>();

    public int Currency { get { return currency; } set { currency = value; } }

    public ItemSO GetItemViaID(int id) {
        foreach (ItemSO item in Items) {
            if (item.ItemID == id) {
                return item;
            }
        }
        return null;
    }
}
