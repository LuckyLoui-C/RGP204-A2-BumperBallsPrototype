using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowNearestTarget : MonoBehaviour {

    private List<Transform> targets = new List<Transform>();

    private bool targeting;
    private Transform currentTarget;

    private AIMovementInput movement;
    private BallCollisionDetection detector;
    private bool collided;

    private void Start() {
        // find all available other balls
        BallCollisionDetection[] possibleTargets = FindObjectsOfType<BallCollisionDetection>();
        foreach (BallCollisionDetection aiCollisionDetection in possibleTargets) {
            targets.Add(aiCollisionDetection.transform);
        }
        // Debug.Log(":: target total " + possibleTargets.Length);
        
        // get components
        movement = GetComponent<AIMovementInput>();
        detector = GetComponent<BallCollisionDetection>();
        if (detector != null) {
            detector.OnCollisionDetected += CollisionDetected;
        }

        // move toward centre at start
        currentTarget = GameObject.FindGameObjectWithTag("InitialTarget").transform;
    }

    private void CollisionDetected() {
        collided = true;
        // FindNearestTarget();
    }

    private void FixedUpdate() {

        if (currentTarget == null || !currentTarget.gameObject.activeSelf) {
            Debug.Log(":: need to find new target ::");
            FindNearestTarget();

            if (currentTarget == null || !currentTarget.gameObject.activeSelf) {
                movement.Move(Vector3.zero);
                return;
            }
        }

        if (currentTarget != null && !collided) {
            // Get new position
            Vector3 newPosn = transform.position - currentTarget.position;
            movement.Move(Vector3.Normalize(-newPosn));
            
            // FindNearestTarget();
            
        } else if (collided) {
            // FindNearestTarget();
            StartCoroutine(ReturnToFollowMovement());
        }
    }

    private IEnumerator ReturnToFollowMovement() {
        yield return new WaitForSeconds(0.8f);// todo remove magic number
        collided = false;
        // TODO this needs to be called somewhere again
        // FindNearestTarget();
    }

    private void FindNearestTarget() {
        float nearestDistance = 0.0f;
        int nearestIndex = 0;
        
        
        for(int i = 0; i < targets.Count; i++) {
            if (targets[i].gameObject.name == gameObject.name) {
                // found self so don't do anything
                continue;
            }
            float temp = Vector3.Distance(transform.position, targets[i].position);
            if (nearestDistance == 0.0f || temp < nearestDistance) {
                nearestIndex = i;
                nearestDistance = temp;
            }
        }
        
        // Debug.Log(gameObject.name + ":: nearest index :: " + nearestIndex + " :: " + targets[nearestIndex].gameObject.name);
        // Debug.Log(gameObject.name + ":: nearest distance :: " + nearestDistance + " :: " + targets[nearestIndex].gameObject.name);

        currentTarget = targets[nearestIndex];
    }
}
