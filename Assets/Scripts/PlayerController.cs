using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    public event Action<string> OnPlayerDied;

    private bool isPlayerControlled;

    public bool IsPlayerControlled => isPlayerControlled;

    private void Start() {

        string playerName = gameObject.name;
        if (PlayerPrefs.HasKey(playerName + "_type")) {
            int isAIInt = PlayerPrefs.GetInt(playerName + "_type");
            // todo remove magic numbers
            if (isAIInt == 0) {
                // is player controlled
                Destroy(GetComponent<AIFollowNearestTarget>());
                Destroy(GetComponent<AIMovementInput>());
                isPlayerControlled = true;
            } else if (isAIInt == 1) {
                // is ai controlled
                Destroy(GetComponent<PlayerMovementInput>());
                Destroy(GetComponent<PlayerInput>());
                isPlayerControlled = false;
            }
        }
    }

    public void PlayerDied() {
        OnPlayerDied?.Invoke(gameObject.name);
        gameObject.SetActive(false);
    }
}
