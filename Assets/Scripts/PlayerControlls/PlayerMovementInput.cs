using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Uses the new player input system to capture movement.
/// </summary>
public class PlayerMovementInput : MonoBehaviour, MovementInput {
    
    private Vector3 movementDirection = Vector3.zero;
    private Movement movement;
    private GameController gameManager;

    private void Start() {
        movement = GetComponent<Movement>();
        gameManager = FindObjectOfType<GameController>();
    }
    
    public void Move(InputAction.CallbackContext context) {
        // called on player prefab
        if (gameManager.playersCanMove)
        {
            Vector2 movementVector = context.ReadValue<Vector2>();

            movementDirection.x = movementVector.x;
            movementDirection.z = movementVector.y;
            movement.MovementDirection = movementDirection;
        }
    }

    public void UpdateMoveDirection(Vector3 newDirection, float speed) {
        movement.MovementDirection = movementDirection;
    }
}
