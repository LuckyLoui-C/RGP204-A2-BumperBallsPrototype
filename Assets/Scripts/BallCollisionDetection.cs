using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionDetection : MonoBehaviour {

    public event Action OnCollisionDetected;

    [SerializeField] private float repelSpeed = 4.0f;
    [SerializeField] private float reenableColliderTime = 0.5f;
    
    private MovementInput movementInput;

    private SphereCollider col;
    
    private void Start() {
        movementInput = GetComponent<MovementInput>();
        col = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            // Debug.Log(":: " + gameObject.name + " :: hit :: " + other.gameObject.name);

            movementInput.UpdateMoveDirection(-repelSpeed);
            col.enabled = false;
            StartCoroutine(EnableCollider());
            OnCollisionDetected?.Invoke();
        }
    }

    private IEnumerator EnableCollider() {
        yield return new WaitForSeconds(reenableColliderTime);
        col.enabled = true;
    }
}
