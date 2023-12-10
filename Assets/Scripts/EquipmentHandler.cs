using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class EquipmentHandler : MonoBehaviour {
    [SerializeField] InventoryHandler inventoryHandler;
    [SerializeField] GameObject clothesObject;
    [SerializeField] SpriteLibrary spriteLib;
    [SerializeField] ItemSO currentHat;
    [SerializeField] ItemSO currentClothes;

    public ItemSO CurrentHat { get { return currentHat; } }
    public ItemSO CurrentClothes { get { return currentClothes; } }

    #region Events
    public event Action OnEquipClothing;
    #endregion

    public void EquiptItem(ItemSO item) {
        if (item.Type != ItemType.Clothing)
            return;

        EquipableItemSO equipableItem = (EquipableItemSO)item;
        StoreItemInInventory(equipableItem.EquipType);

        switch (equipableItem.EquipType) {
            case EquipType.Hat:
                EquipHat(equipableItem);
                break;
            case EquipType.Body:
                EquipClothes(equipableItem);
                break;
        }
    }

    private void EquipClothes(EquipableItemSO item) {
        //Set Sprite Libary Asset
        if (item.itemAsset != null) {
            spriteLib.spriteLibraryAsset = item.itemAsset;
        }
        
        if (clothesObject != null) {
            Destroy(clothesObject);
        }

        if (item.ItemPrefab != null) {
            clothesObject = Instantiate(item.ItemPrefab, this.transform);
            clothesObject.transform.position = Vector3.zero;
        }

        OnEquipClothing?.Invoke();
    }

    private void EquipHat(EquipableItemSO item) {
        
    }

    private void StoreItemInInventory(EquipType type) {
        switch (type) {
            case EquipType.Hat:
                if (currentHat != null) {
                    inventoryHandler.StoreItem(currentHat);
                    currentHat = null;
                }
                break;
            case EquipType.Body:
                if (currentClothes != null) {
                    inventoryHandler.StoreItem(currentClothes);
                    currentClothes = null;
                }
                break;
        }
    }
}
