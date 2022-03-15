using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject gameStartScreen;
    [SerializeField] private GameObject inGameCanvas;
    [SerializeField] private TextMeshProUGUI winnerNameText;
    [SerializeField] private GamePlayTimer gamePlayTimer;

    private SceneHandler sceneManager;

    public bool playersCanMove;

    private List<string> deadPlayers;
    private Dictionary<string, PlayerController> players;

    private void Awake() {
        sceneManager = FindObjectOfType<SceneHandler>();
        
        playersCanMove = false;

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
        Time.timeScale = 0.0f;
    }

    public void StartGame(float delayStartTime)
    {
        StartCoroutine(DelayStart(delayStartTime));
    }

    IEnumerator DelayStart(float delayTime)
    {
        yield return new WaitForSecondsRealtime(delayTime);
        playersCanMove = true;
        gameStartScreen.SetActive(false);
        inGameCanvas.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void GameOver() {
        playersCanMove = false;
        gamePlayTimer.timerIsRunning = false;
        inGameCanvas.SetActive(false);
        gameOverScreen.SetActive(true);
        
        Time.timeScale = 0.0f;
    }

    public void ReplayGame() {
        sceneManager.LoadScene("SceneWithTimer");
    }
}
