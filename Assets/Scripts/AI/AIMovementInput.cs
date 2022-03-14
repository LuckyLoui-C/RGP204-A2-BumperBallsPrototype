using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AI version of input script to capture movement direction
/// </summary>
public class AIMovementInput : MonoBehaviour, MovementInput
{

    private Vector3 movementDirection;
    private Movement movement;
    private GameController gameManager;

    private void Start()
    {
        movement = GetComponent<Movement>();
        gameManager = FindObjectOfType<GameController>();
    }

    public void Move(Vector3 input)
    {
        if (gameManager.playersCanMove)
        {
            movementDirection.x = input.x;
            movementDirection.z = input.z;

            movement.MovementDirection = movementDirection;
        }
    }

    public void UpdateMoveDirection(Vector3 newDirection, float speed)
    {
        movement.MovementDirection = movementDirection;
        movement.CurrentSpeed = speed;
        StartCoroutine(ResetSpeed());
    }

    private IEnumerator ResetSpeed()
    {
        yield return new WaitForSeconds(0.8f); // todo remove magic number
        movement.ResetSpeed();
    }
}
