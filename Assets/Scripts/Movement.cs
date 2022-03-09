using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour {

    public float speed = 0;

    private Vector3 movementDirection;
    private bool stopMoving;
    private Rigidbody rb;

    public bool StopMoving {
        get => stopMoving;
        set => stopMoving = value;
    }

    public Vector3 MovementDirection {
        get => movementDirection;
        set => movementDirection = value;
    }

    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!stopMoving) {
            rb.AddForce(movementDirection * speed, ForceMode.Impulse);
        }
    }
}
