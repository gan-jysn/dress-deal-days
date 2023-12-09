using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimHandler : MonoBehaviour {
    [SerializeField] MovementController movementController;

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        
        if (movementController == null) {
            movementController = GetComponentInParent<MovementController>();
        }
    }

    private void Update() {
        UpdateMovementVariables();
    }

    private void UpdateMovementVariables() {
        if (movementController != null) {
            Vector2 movement = movementController.MoveVector;
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }
}
