using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Equipable Item")]
public class EquipableItems : Item {
    public EquipType equipType;
    public Sprite spriteSheet;
}
