using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionDetection : MonoBehaviour {

    public event Action OnCollisionDetected;

    [SerializeField] private float repelSpeed = 4.0f;
    
    private MovementInput movementInput;
    private Rigidbody rb;
    
    
    private void Start() {
        movementInput = GetComponent<MovementInput>();
        rb = GetComponent<Rigidbody>();
    }
    
    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.CompareTag("Player")) {
            // Debug.Log(":: " + gameObject.name + " :: hit :: " + collision.gameObject.name);

            Vector3 vel = rb.velocity;
            float tempf = 1.0f;
            Vector3 currentMovement = new Vector3(vel.x > 0 ? -tempf : tempf, 0.0f, vel.z > 0 ? -tempf : tempf);
            movementInput.UpdateMoveDirection(currentMovement, repelSpeed);
            
            OnCollisionDetected?.Invoke();

        }
    }
}
