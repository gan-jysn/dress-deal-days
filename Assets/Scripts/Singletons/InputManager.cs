using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager> {
    private InputActions inputActions;
    
    public InputActions InputActions { get { return inputActions; } }

    #region Events
    public event Action<Vector2> OnMovementStart;
    public event Action OnMovementEnd;
    public event Action OnInteractPressed;
    public event Action OnJumpPressed;
    public event Action OnShiftStarted;
    public event Action OnShiftEnded;
    #endregion

    public void Awake() {
        //Initialize Input Action
        inputActions = new InputActions();
    }

    private void Start() {
        AddEventCallbacks();
    }

    private void OnDestroy() {
        RemoveEventCallbacks();
    }

    private void AddEventCallbacks() {
        //Subscribe to Local Events
        inputActions.Game.Movement.performed += OnMovementPerformed;
        inputActions.Game.Movement.canceled += OnMovementCancelled;
        inputActions.Game.Interact.performed += OnInteractPerformed;
        inputActions.Game.Jump.performed += OnJumpPerformed;
        inputActions.Game.Shift.started += OnShiftStart; 
        inputActions.Game.Shift.canceled += OnShiftEnd; 
    }

    private void RemoveEventCallbacks() {
        //Unsubscribe to Local Events
        inputActions.Game.Movement.performed -= OnMovementPerformed;
        inputActions.Game.Movement.canceled -= OnMovementCancelled;
        inputActions.Game.Interact.performed -= OnInteractPerformed;
        inputActions.Game.Jump.performed -= OnJumpPerformed;
        inputActions.Game.Shift.started -= OnShiftStart;
        inputActions.Game.Shift.canceled -= OnShiftEnd;
    }

    private void OnEnable() {
        if (inputActions != null) {
            inputActions.Enable();
        }
    }

    private void OnDisable() {
        if (inputActions != null) {
            inputActions.Disable();
        }
    }

    private void OnMovementPerformed(InputAction.CallbackContext value) {
        Vector2 readValue = value.ReadValue<Vector2>();
        OnMovementStart?.Invoke(readValue);
    }

    private void OnMovementCancelled(InputAction.CallbackContext value) {
        OnMovementEnd?.Invoke();
    }

    private void OnInteractPerformed(InputAction.CallbackContext value) {
        OnInteractPressed?.Invoke();
    }

    private void OnJumpPerformed(InputAction.CallbackContext value) {
        OnJumpPressed?.Invoke();
    }

    private void OnShiftStart(InputAction.CallbackContext value) {
        OnShiftStarted?.Invoke();
    }

    private void OnShiftEnd(InputAction.CallbackContext value) {
        OnShiftEnded?.Invoke();
    }
}
