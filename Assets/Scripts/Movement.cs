using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour {

    public float speed = 2.0f;

    private Vector3 movementDirection;
    private Rigidbody rb;
    private float originalSpeed;
    private float currentSpeed;

    public Vector3 MovementDirection {
        set => movementDirection = value;
    }

    public float CurrentSpeed {
        set => currentSpeed = value;
    }

    void Start() {
        rb = GetComponent<Rigidbody>();
        originalSpeed = speed;
        currentSpeed = speed;
    }

    private void FixedUpdate() {
        rb.AddForce(movementDirection * currentSpeed, ForceMode.Impulse);
    }

    public void ResetSpeed() {
        currentSpeed = originalSpeed;
    }
}
