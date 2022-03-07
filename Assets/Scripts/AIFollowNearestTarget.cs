using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowNearestTarget : MonoBehaviour {

    [SerializeField] private float movementSpeed = 1.0f;

    // todo get this is start
    [SerializeField] private Transform[] targets;

    private bool targeting;
    private Transform currentTarget;
    
    private void Start() {
        currentTarget = FindNearestTarget();
    }

    private void Update() {

        if (currentTarget != null) {
            // Move our position a step closer to the target.
            float step =  movementSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, step);

            // Check if the position of the cube and sphere are approximately equal.
            // if (Vector3.Distance(transform.position, target.position) < 0.001f) {
            //     // Swap the position of the cylinder.
            //     target.position *= -1.0f;
            // }
        }
    }

    private Transform FindNearestTarget() {
        float nearestDistance = Vector3.Distance(transform.position, targets[0].position);
        int nearestIndex = 0;
        
        for(int i = 1; i < targets.Length; i++) {
            float temp = Vector3.Distance(transform.position, targets[i].position);
            if (temp < nearestDistance) {
                nearestIndex = i;
                nearestDistance = temp;
            }
        }
        
        Debug.Log(gameObject.name + ":: nearest index :: " + nearestIndex + " :: " + targets[nearestIndex].gameObject.name);
        Debug.Log(gameObject.name + ":: nearest distance :: " + nearestDistance + " :: " + targets[nearestIndex].gameObject.name);

        return targets[nearestIndex];
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log(":: " + gameObject.name + " :: hit :: " + collision.gameObject.name);
    }
}
