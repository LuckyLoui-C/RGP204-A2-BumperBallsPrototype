using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Uses the new player input system to capture movement.
/// </summary>
public class PlayerMovementInput : MonoBehaviour, MovementInput {
    
    private float resetPlayerCanMoveTime = 0.5f;
    private Vector3 movementDirection = Vector3.zero;
    private Movement movement;

    private bool repelling;
    
    private void Start() {
        movement = GetComponent<Movement>();
    }
    
    public void Move(InputAction.CallbackContext context) {
        // called on player prefab
        if (!repelling) {
            // player can only move if they are not being pushed back after collision
            Vector2 movementVector = context.ReadValue<Vector2>();

            movementDirection.x = movementVector.x;
            movementDirection.z = movementVector.y;
            movement.MovementDirection = movementDirection;
        }
    }

    public void UpdateMoveDirection(float speed) {
        movement.CurrentSpeed = speed;
        repelling = true;
        StartCoroutine(ResetPlayerCanMove());
    }

    public void SetResetTime(float resetTime) {
        this.resetPlayerCanMoveTime = resetTime;
    }

    private IEnumerator ResetPlayerCanMove() {
        yield return new WaitForSeconds(resetPlayerCanMoveTime);
        movement.ResetSpeed();
        repelling = false;
    }
}
