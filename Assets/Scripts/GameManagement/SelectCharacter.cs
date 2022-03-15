using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI yellowPlayerButtonText;
    [SerializeField] private TextMeshProUGUI greenPlayerButtonText;
    [SerializeField] private TextMeshProUGUI pinkPlayerButtonText;
    [SerializeField] private TextMeshProUGUI bluePlayerButtonText;

    private const string YELLOW = "Yellow_type";
    private const string GREEN = "Green_type";
    private const string PINK = "Pink_type";
    private const string BLUE = "Blue_type";
    private const string PLAYER = "Player";
    private const string AI = "AI";
    
    private void Start() {
        if (PlayerPrefs.HasKey(YELLOW)) {
            int keyValue = PlayerPrefs.GetInt(YELLOW);
            yellowPlayerButtonText.text = keyValue == 0 ? PLAYER : AI;
        } else {
            yellowPlayerButtonText.text = PLAYER;
            PlayerPrefs.SetInt(YELLOW, 0);
        }

        if (PlayerPrefs.HasKey(GREEN)) {
            int keyValue = PlayerPrefs.GetInt(GREEN);
            greenPlayerButtonText.text = keyValue == 0 ? PLAYER : AI;
        } else {
            greenPlayerButtonText.text = AI;
            PlayerPrefs.SetInt(GREEN, 1);
        }
        
        if (PlayerPrefs.HasKey(BLUE)) {
            int keyValue = PlayerPrefs.GetInt(BLUE);
            bluePlayerButtonText.text = keyValue == 0 ? PLAYER : AI;
        } else {
            bluePlayerButtonText.text = AI;
            PlayerPrefs.SetInt(BLUE, 1);
        }
        
        if (PlayerPrefs.HasKey(PINK)) {
            int keyValue = PlayerPrefs.GetInt(PINK);
            pinkPlayerButtonText.text = keyValue == 0 ? PLAYER : AI;
        } else {
            pinkPlayerButtonText.text = AI;
            PlayerPrefs.SetInt(PINK, 1);
        }
    }

    public void ToggleYellowPlayer() {
        string buttonText = yellowPlayerButtonText.text;

        if (buttonText == PLAYER) {
            yellowPlayerButtonText.text = AI;
            PlayerPrefs.SetInt(YELLOW, 1);
        } else if (buttonText == AI) {
            yellowPlayerButtonText.text = PLAYER;
            PlayerPrefs.SetInt(YELLOW, 0);
        }
    }
    
    public void ToggleGreenPlayer() {
        string buttonText = greenPlayerButtonText.text;

        if (buttonText == PLAYER) {
            greenPlayerButtonText.text = AI;
            PlayerPrefs.SetInt(GREEN, 1);
        } else if (buttonText == AI) {
            greenPlayerButtonText.text = PLAYER;
            PlayerPrefs.SetInt(GREEN, 0);
        }
    }
    
    public void TogglePinkPlayer() {
        string buttonText = pinkPlayerButtonText.text;

        if (buttonText == PLAYER) {
            pinkPlayerButtonText.text = AI;
            PlayerPrefs.SetInt(PINK, 1);
        } else if (buttonText == AI) {
            pinkPlayerButtonText.text = PLAYER;
            PlayerPrefs.SetInt(PINK, 0);
        }
    }
    
    public void ToggleBluePlayer() {
        string buttonText = bluePlayerButtonText.text;

        if (buttonText == PLAYER) {
            bluePlayerButtonText.text = AI;
            PlayerPrefs.SetInt(BLUE, 1);
        } else if (buttonText == AI) {
            bluePlayerButtonText.text = PLAYER;
            PlayerPrefs.SetInt(BLUE, 0);
        }
    }
}
