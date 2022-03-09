using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AI version of input script to capture movement direction
/// </summary>
public class AIMovementInput : MonoBehaviour, MovementInput {
    
    private Vector3 movementDirection;
    private Movement movement;
    
    private void Start() {
        movement = GetComponent<Movement>();
    }

    public void Move(Vector3 input) {
        movementDirection.x = input.x;
        movementDirection.z = input.z;
        
        movement.MovementDirection = movementDirection;
    }

    public void UpdateMoveDirection(Vector3 newDirection) {
        movement.MovementDirection = movementDirection;
    }
}
