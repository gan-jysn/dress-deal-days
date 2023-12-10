using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Inventory")]
public class InventorySO : ScriptableObject {
    public int Currency;
    public List<ItemSO> Items = new List<ItemSO>();
}
