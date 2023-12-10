using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Items/Equipable Item")]
public class EquipableItem : Item {
    public EquipType EquipType;
    public Sprite SpriteSheet;
    public GameObject ItemPrefab;
}

public enum EquipType {
    Hat,
    Body,
    Weapon
}
