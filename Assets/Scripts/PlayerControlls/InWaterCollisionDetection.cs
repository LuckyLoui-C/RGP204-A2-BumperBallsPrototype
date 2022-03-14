using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWaterCollisionDetection : MonoBehaviour {
    
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            // if a player falls in just disable them for now
            // TODO add end of game detection?
            // Debug.Log(":: in water :: " + collision.gameObject.name);
            collision.gameObject.GetComponent<PlayerController>().PlayerDied();
        }
    }
}
