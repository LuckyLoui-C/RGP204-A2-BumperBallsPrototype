using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI winnerNameText;

    private List<string> deadPlayers;
    private Dictionary<string, PlayerController> players;
    
    private void Awake() {

        PlayerController[] playerControllers = FindObjectsOfType<PlayerController>();
        players = new Dictionary<string, PlayerController>();

        foreach (PlayerController controller in playerControllers) {
            string playerName = controller.gameObject.name;
            players[playerName] = controller;

            if (!PlayerPrefs.HasKey(playerName + "_type")) {
                PlayerPrefs.SetInt(playerName + "_type", playerName == "Player1" ? 0 : 1);
            }

            controller.OnPlayerDied += PlayerDied;
        }
        
        // force save
        PlayerPrefs.Save();
    }

    private void PlayerDied(string deadPlayerName) {
        deadPlayers.Add(deadPlayerName);

        if (deadPlayers.Count == 3) {

            foreach(var playerName in players.Keys) {
                if (deadPlayers.Contains(playerName)) {
                    continue;
                }

                winnerNameText.text = playerName;
            }
            GameOver();
        }
    }

    private void Start() {
        deadPlayers = new List<string>();
        
        gameOverScreen.SetActive(false);
        // todo move this when menu is added
        Time.timeScale = 1.0f;
    }

    private void GameOver() {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ReplayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
