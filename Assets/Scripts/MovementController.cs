using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour {
    [SerializeField] bool isControlsEnabled = true;
    [SerializeField] float defaultMovementSpeed = 5f;
    [SerializeField] float runningMovementSpeed = 7.5f;

    private Rigidbody2D rb;
    private bool isRunEnabled = false;
    private Vector2 moveVector = Vector2.zero;
    private float movementSpeed = 0;

    public bool IsControlsEnabled { get { return isControlsEnabled; } }
    public float MovementSpeed { get { return movementSpeed; } }
    public bool IsRunEnabled { get { return isRunEnabled; } }
    public Vector2 MoveVector { get { return moveVector; } }

    #region Events
    public event Action OnJump;
    public event Action<bool> OnRunToggle;
    #endregion

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        movementSpeed = defaultMovementSpeed;

        AddEventCallbacks();
    }

    private void OnDestroy() {
        RemoveEventCallbacks();
    }

    private void FixedUpdate() {
        if (!isControlsEnabled)
            return;

        //Movement
        rb.MovePosition(rb.position + moveVector * movementSpeed * Time.fixedDeltaTime);
    }

    private void AddEventCallbacks() {
        //Subscribe to Event Callbacks
        InputManager.Instance.OnMovementStart += OnMovementStart;
        InputManager.Instance.OnMovementEnd += OnMovementEnd;
        InputManager.Instance.OnShiftStarted += OnRunEnabled;
        InputManager.Instance.OnShiftEnded += OnRunDisabled;
        InputManager.Instance.OnJumpPressed += Jump;
        InputManager.Instance.OnInteractPressed += Interact;

        GameManager.Instance.OnGamePaused += DisableControls;
        GameManager.Instance.OnGameResumed += EnableControls;
    }

    private void RemoveEventCallbacks() {
        //Unsubscribe to Event Callbacks
        InputManager.Instance.OnMovementStart -= OnMovementStart;
        InputManager.Instance.OnMovementEnd -= OnMovementEnd;
        InputManager.Instance.OnShiftStarted -= OnRunEnabled;
        InputManager.Instance.OnShiftEnded -= OnRunDisabled;
        InputManager.Instance.OnJumpPressed -= Jump;
        InputManager.Instance.OnInteractPressed -= Interact;

        GameManager.Instance.OnGamePaused -= DisableControls;
        GameManager.Instance.OnGameResumed -= EnableControls;
    }

    private void OnMovementStart(Vector2 input) {
        //Assign Input Value to Local Move Vector
        moveVector = input;
    }

    private void OnMovementEnd() {
        moveVector = Vector2.zero;
    }

    private void Jump() {
        OnJump?.Invoke();
    }

    private void OnRunEnabled() {
        isRunEnabled = true;
        movementSpeed = runningMovementSpeed;
        OnRunToggle?.Invoke(isRunEnabled);
    }

    private void OnRunDisabled() {
        isRunEnabled = false;
        movementSpeed = defaultMovementSpeed;
        OnRunToggle?.Invoke(isRunEnabled);
    }

    private void Interact() {
        //Add Interact Functionality Here
        Debug.Log("Interact");
    }

    private void DisableControls() {
        isControlsEnabled = false;
    }

    public void EnableControls() {
        isControlsEnabled = true;
    }
}
