using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface to be shared between AI and player scripts so there is a common
/// entry point for collision detection
/// </summary>
public interface MovementInput {

    void UpdateMoveDirection(Vector3 newDirection);
}
