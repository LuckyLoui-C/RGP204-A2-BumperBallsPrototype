using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowNearestTarget : MonoBehaviour {

    [SerializeField] private float waitTimeAfterCollision = 0.5f;

    private List<Transform> targets = new List<Transform>();

    private bool targeting;
    private Transform currentTarget;

    private AIMovementInput movement;
    private BallCollisionDetection detector;
    private bool collided;
    private bool collidedThisFrame;
    
    private void Start() {

        // find all available other balls
        BallCollisionDetection[] possibleTargets = FindObjectsOfType<BallCollisionDetection>();
        foreach (BallCollisionDetection aiCollisionDetection in possibleTargets) {
            if (aiCollisionDetection.gameObject.name == this.gameObject.name) {
                // dont add self
                continue;
            }
            targets.Add(aiCollisionDetection.transform);
        }
        
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
        collidedThisFrame = true;
    }

    private void FixedUpdate() {

        if (movement == null) {
            movement = GetComponent<AIMovementInput>();
        }

        if (currentTarget == null || !currentTarget.gameObject.activeSelf) {
            // current target fell off, so find new one
            FindNearestTarget();

            if (currentTarget == null || !currentTarget.gameObject.activeSelf) {
                // no targets left so stop
                movement.Move(Vector3.zero);
                return;
            }
        }
        if (collided && collidedThisFrame) {
            // Debug.Log(":: ----- collided going back " + gameObject.name);
            collidedThisFrame = false;
            StartCoroutine(ReturnToFollowMovement());
        } else if (currentTarget != null && !collided) {
            // Get new position
            Vector3 newPosn = transform.position - currentTarget.position;
            // Debug.Log(":: new posn :: " + gameObject.name + " :: " + newPosn + " :: Norm :: "+ Vector3.Normalize(-newPosn));
            movement.Move(Vector3.Normalize(-newPosn));
        } 
    }

    private IEnumerator ReturnToFollowMovement() {
        yield return new WaitForSeconds(waitTimeAfterCollision);
        collided = false;
        FindNearestTarget();
    }

    private void FindNearestTarget() {
        float nearestDistance = 0.0f;
        int nearestIndex = 0;
        
        
        for(int i = 0; i < targets.Count; i++) {
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
