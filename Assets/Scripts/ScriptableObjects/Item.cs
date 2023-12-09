using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject {
    public string itemName;
    public string description;
    public int value;
    public ItemType type;
    public Sprite icon;
}

public enum ItemType {
    Clothing,
    Consumable,
    Trophy
}

public enum EquipType {
    Head,
    Body,
    Pants,
    Shoes,
    Weapon
}
