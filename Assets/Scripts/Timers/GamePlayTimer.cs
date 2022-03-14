using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayTimer : MonoBehaviour
{
    [HideInInspector]
    public TMPro.TextMeshProUGUI timeText;
    private GameController gameManager;

    public bool timerIsRunning = false;
    public float timeRemaining = 30.0f; // How long before game starts

    void Start()
    {
        timeText = FindObjectOfType<GamePlayTimer>().GetComponent<TMPro.TextMeshProUGUI>(); // Reference timer text
        gameManager = FindObjectOfType<GameController>();

        timerIsRunning = true; // Start the timer
    }

    void Update()
    {
        if (timerIsRunning)
        {
            timeRemaining -= Time.deltaTime; // Every frame, minus deltaTime from remaining time, counts down.
            DisplayTime(timeRemaining);
        }
    }
    void DisplayTime(float timeToDisplay) // TODO: Timer UI
    {
        if (timeRemaining <= 0.0f)
        {
            timeText.text = string.Format("FINISH!");
            gameManager.GameOver();
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