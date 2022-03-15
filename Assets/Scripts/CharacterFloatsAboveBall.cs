using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFloatsAboveBall : MonoBehaviour
{
    public GameObject playerTransform; // The balls transform
    public float characterDistanceAboveBall = 0.9f; // How far above the ball the player floats
    Vector3 previousPosition;
    Vector3 direction;
    void Update()
    {    // The balls transform + how far above you want the character to appear
        transform.position = playerTransform.gameObject.transform.position + new Vector3(0.0f, characterDistanceAboveBall, 0.0f);
        // direction the ball is facing
        direction = (playerTransform.transform.position - previousPosition.normalized.normalized);
        transform.LookAt(direction);
        Vector3 characterRotation = new Vector3(-55.0f , 0, 0); // compensating for the wrong angle of the X
        transform.Rotate(characterRotation);
        // set the previous position
        previousPosition = playerTransform.transform.position;
    }
    private void Start()
    {
        // Initial value for previous position
        previousPosition = playerTransform.transform.position;
    }
}
