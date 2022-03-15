using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float resetForwardMovementTime = 0.5f;

    public event Action<string> OnPlayerDied;

    [SerializeField] private string playerName;

    private bool isPlayerControlled;

    public bool IsPlayerControlled => isPlayerControlled;
    public string PlayerName => playerName;

    private void Start() {

        if (PlayerPrefs.HasKey(playerName + "_type")) {
            int isAIInt = PlayerPrefs.GetInt(playerName + "_type");
            // todo remove magic numbers
            if (isAIInt == 0) {
                // Debug.Log(":: player controlled :: " + playerName);
                // is player controlled
                Destroy(GetComponent<AIFollowNearestTarget>());
                PlayerMovementInput playerMovementInput = gameObject.AddComponent(typeof(PlayerMovementInput)) as PlayerMovementInput;
                playerMovementInput?.SetResetTime(this.resetForwardMovementTime);

                PlayerInput playerInput = GetComponent<PlayerInput>();
                InputAction ia = playerInput.actions["Player/Move"];
                if (ia != null) {
                    ia.performed += playerMovementInput.Move;
                } 
                
                isPlayerControlled = true;
            } else if (isAIInt == 1) {
                // Debug.Log(":: ai controlled :: " + playerName);
                // is ai controlled
                Destroy(GetComponent<PlayerInput>());
                AIMovementInput aiMovementInput = gameObject.AddComponent(typeof(AIMovementInput)) as AIMovementInput;
                aiMovementInput?.SetResetTime(this.resetForwardMovementTime);
                isPlayerControlled = false; 
            }
        } 
    }

    public void PlayerDied() {
        OnPlayerDied?.Invoke(gameObject.name);
        gameObject.SetActive(false);
    }
}
