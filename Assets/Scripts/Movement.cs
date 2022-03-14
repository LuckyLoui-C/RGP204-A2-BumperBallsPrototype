using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour {

    public float speed = 0;

    private Vector3 movementDirection;
    private bool stopMoving;
    private Rigidbody rb;
    private float originalSpeed;
    private float currentSpeed;

    public bool StopMoving {
        get => stopMoving;
        set => stopMoving = value;
    }

    public Vector3 MovementDirection {
        set => movementDirection = value;
    }

    public float CurrentSpeed {
        set => currentSpeed = value;
    }

    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        originalSpeed = speed;
        currentSpeed = speed;
    }

    private void FixedUpdate()
    {
        if (!stopMoving) {
            rb.AddForce(movementDirection * currentSpeed, ForceMode.Impulse);
        }
    }

    public void ResetSpeed() {
        currentSpeed = originalSpeed;
    }
}
