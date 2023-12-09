using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable {
    public void Interact();
}

public interface IEquipable {
    public void EquiptItem(Item item);
    public void UnequipItem();
}
