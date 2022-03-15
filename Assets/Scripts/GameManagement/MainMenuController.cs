using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    [SerializeField] private GameObject selectCharacterPanel;
    [SerializeField] private GameObject mainMenuPanel;
    
    private void Start() {
        mainMenuPanel.SetActive(true);
        selectCharacterPanel.SetActive(false);
    }

    public void ShowSelectCharacterPanel() {
        selectCharacterPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
}
