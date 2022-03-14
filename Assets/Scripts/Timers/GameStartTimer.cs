using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartTimer : MonoBehaviour
{
    [HideInInspector]
    public TMPro.TextMeshProUGUI timeText;
    private GameObject startGameCanvas;
    private GameController gameManager;

    public bool timerIsRunning = false;
    public float timeToPlay = 3.0f; // How long before game starts
    public float delayStart = 1.0f;

    void Start()
    {
        timeText = FindObjectOfType<GameStartTimer>().GetComponent<TMPro.TextMeshProUGUI>(); // Reference timer text
        gameManager = FindObjectOfType<GameController>();

        timerIsRunning = true; // Start the timer
    }

    void Update()
    {
        if (timerIsRunning)
        {
            timeToPlay -= Time.deltaTime; // Every frame, minus deltaTime from remaining time, counts down.
            DisplayTime(timeToPlay);
        }
        else
        {
            gameManager.StartGame(delayStart);
        }
    }
    void DisplayTime(float timeToDisplay) // TODO: Timer UI
    {
        if (timeToPlay <= 0.0f)
        {
            timeText.text = string.Format("GO!");
            timerIsRunning = false;
        }
        else
        {
            timeToDisplay += 1;
            float seconds = Mathf.FloorToInt(timeToDisplay % 60); // Modulus 60 to get sec. remaining
            timeText.text = string.Format("{0:0}", seconds);
        }
    }
}