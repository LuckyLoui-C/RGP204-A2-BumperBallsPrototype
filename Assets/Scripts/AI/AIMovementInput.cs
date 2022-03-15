using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AI version of input script to capture movement direction
/// </summary>
public class AIMovementInput : MonoBehaviour, MovementInput {
    
    private float resetSpeedTime = 0.5f;
    private Vector3 movementDirection;
    private Movement movement;
    
    private void Start() {
        movement = GetComponent<Movement>();
    }

    public void Move(Vector3 input) {

        if (movement == null) {
            movement = GetComponent<Movement>();
        }
        movementDirection.x = input.x;
        movementDirection.z = input.z;
        
        movement.MovementDirection = movementDirection;
    }

    public void UpdateMoveDirection(float speed) {
        try {
            movement.CurrentSpeed = speed;
            StartCoroutine(ResetForwardSpeed());
        } catch (Exception e) {
            Debug.Log(":: got exception :: " + gameObject.name);
            Debug.Log(e.StackTrace);
        }
    }

    public void SetResetTime(float resetTime) {
        this.resetSpeedTime = resetTime;
    }

    private IEnumerator ResetForwardSpeed() {
        yield return new WaitForSeconds(resetSpeedTime); 
        movement.ResetSpeed();
    }
}
