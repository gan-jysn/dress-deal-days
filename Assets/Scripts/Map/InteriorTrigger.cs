using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class InteriorTrigger : MonoBehaviour {
    [SerializeField] bool isPlayerInside = false;

    public bool IsPlayerInside { get { return isPlayerInside; } }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            if (!isPlayerInside) {
                MapManager.Instance.OnTriggerPlayerEnterInterior();
            }
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            if (IsPlayerInside) {
                MapManager.Instance.OnTriggerPlayerExitInterior();
            }
            isPlayerInside = false;
        }
    }
}
