using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Equipable Item")]
public class EquipableItem : Item {
    public EquipType equipType;
    public Sprite spriteSheet;
    public GameObject itemPrefab;
}

public enum EquipType {
    Hat,
    Body,
    Weapon
}
