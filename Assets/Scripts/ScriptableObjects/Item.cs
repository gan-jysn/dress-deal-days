using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject {
    public int ItemID;
    public string ItemName;
    public string Description;
    public int Value;
    public ItemType Type;
    public Sprite Icon;
}

public enum ItemType {
    Clothing,
    Consumable,
    Trophy
}