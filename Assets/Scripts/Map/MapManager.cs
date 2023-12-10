using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Sirenix.OdinInspector;

public class MapManager : Singleton<MapManager> {
    [SerializeField, FoldoutGroup("Tilemap Layers")] TilemapRenderer underground;   
    [SerializeField, FoldoutGroup("Tilemap Layers")] TilemapRenderer ground;   
    [SerializeField, FoldoutGroup("Tilemap Layers")] TilemapRenderer interior;
    [SerializeField, FoldoutGroup("Tilemap Layers")] TilemapRenderer interiorWalls;
    [SerializeField, FoldoutGroup("Tilemap Layers")] TilemapRenderer interiorAccessories;
    [SerializeField, FoldoutGroup("Tilemap Layers")] TilemapRenderer buildings;
    [SerializeField, FoldoutGroup("Tilemap Layers")] TilemapRenderer buildingDoors;
    [SerializeField, FoldoutGroup("Tilemap Layers")] TilemapRenderer buildingRoofs;
    [SerializeField, FoldoutGroup("Tilemap Layers")] TilemapRenderer buildingAccessories;

    [SerializeField, FoldoutGroup("Tilemap Colliders")] TilemapCollider2D interiorColliders;
    [SerializeField, FoldoutGroup("Tilemap Colliders")] TilemapCollider2D buildingColliders;

    #region Events
    public event Action OnPlayerEnterInterior;
    public event Action OnPlayerExitInterior;
    #endregion

    private void Start() {
        AddEventCallbacks();
    }

    private void OnDestroy() {
        RemoveEventCallbacks();
    }

    private void AddEventCallbacks() {
        OnPlayerEnterInterior += OnEnterInterior;
        OnPlayerExitInterior += OnExitInterior;
    }

    private void RemoveEventCallbacks() {
        OnPlayerEnterInterior -= OnEnterInterior;
        OnPlayerExitInterior -= OnExitInterior;
    }

    private void OnEnterInterior() {
        //Set Colliders Active Status
        interiorColliders.enabled = true;
        buildingColliders.enabled = false;

        //Set Renderer Active Status
        interior.enabled = true;
        interiorWalls.enabled = true;
        interiorAccessories.enabled = true;
        buildings.enabled = false;
        buildingDoors.enabled = false;
        buildingRoofs.enabled = false;
        buildingAccessories.enabled = false;
    }

    private void OnExitInterior() {
        //Set Colliders Active Status
        interiorColliders.enabled = false;
        buildingColliders.enabled = true;

        //Set Renderer Active Status
        interior.enabled = false;
        interiorWalls.enabled = false;
        interiorAccessories.enabled = false;
        buildings.enabled = true;
        buildingDoors.enabled = true;
        buildingRoofs.enabled = true;
        buildingAccessories.enabled = true;
    }

    public void OnTriggerPlayerEnterInterior() {
        OnPlayerEnterInterior?.Invoke();
    }

    public void OnTriggerPlayerExitInterior() {
        OnPlayerExitInterior?.Invoke();
    }
}
