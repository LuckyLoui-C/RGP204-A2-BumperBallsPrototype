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
    
    public float timeToPlay = 3.0f; // How long before game starts
    public float delayStart = 1.0f;

    void Start()
    {
        timeText = FindObjectOfType<GameStartTimer>().GetComponent<TMPro.TextMeshProUGUI>(); // Reference timer text
        gameManager = FindObjectOfType<GameController>();

        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown() {
        float totalTime = 0;
        DisplayTime(timeToPlay);
        
        while(totalTime <= timeToPlay) {
            yield return new WaitForSecondsRealtime(1.0f);
            totalTime++;
            DisplayTime(timeToPlay - totalTime);
        }
        
        gameManager.StartGame(delayStart);
    }
    
    private void DisplayTime(float timeToDisplay) {
        if (timeToDisplay <= 0.0f) {
            timeText.text = "GO!";
        } else {
            float seconds = Mathf.FloorToInt(timeToDisplay % 60); // Modulus 60 to get sec. remaining
            timeText.text = string.Format("{0:0}", seconds);
        }
    }
}