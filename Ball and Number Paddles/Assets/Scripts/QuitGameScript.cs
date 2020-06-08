using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameScript : MonoBehaviour
{
    GameControllerScript gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void backToMenu()
    {
        gameController.backToMenu();
    }
}
