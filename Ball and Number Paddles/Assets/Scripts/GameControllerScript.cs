using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    int currentLevel = 0;

    public GameObject Tile;
    public GameObject ball;
    public GameObject board;

    public int tilesLeft = 0;
    public int ballsLeft = 3;
    public bool isPlaying = false;

    public EventSystem eventSystem;
    public Text ballsLeftUI;
    public Button pauseButton;
    public Canvas pauseMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(eventSystem.gameObject);
    }

    public void howToPlay()
    {
        SceneManager.LoadScene("HowToPlay", LoadSceneMode.Single);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        currentLevel = 0;
        pauseButton.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
    }

    public void resumeGame()
    {
        pauseButton.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void pauseGame()
    {
        pauseButton.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void nextLevel()
    {
        currentLevel++;
        SceneManager.LoadScene(currentLevel, LoadSceneMode.Single);
        Invoke("setupLevel", 0.1f);
    }

    public void startLevel()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<BallScript>().startPlaying();
        isPlaying = true;
    }
    
    public void resetLevel()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("Board"));
        Instantiate(board, new Vector3(0.0f, -9.0f, 0.0f), Quaternion.identity);
        Instantiate(ball, new Vector3(0.0f, -8.0f, 0.0f), Quaternion.identity);
        ballsLeftUI.text = "Balls Left : " + ballsLeft;
        isPlaying = false;
    }    

    public void gameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        pauseButton.gameObject.SetActive(false);
        ballsLeftUI.gameObject.SetActive(false);
        currentLevel = 0;
    }

    void setupLevel()
    {
        Debug.Log("Setup");
        if (SceneManager.GetActiveScene().name != "YouWin")
        {
            //Spawn Paddle
            Instantiate(board, new Vector3(0.0f, -9.0f, 0.0f), Quaternion.identity);

            //Spawn Ball
            Instantiate(ball, new Vector3(0.0f, -8.0f, 0.0f), Quaternion.identity);

            //Activate UI
            ballsLeftUI.text = "Balls Left : 3";
            ballsLeftUI.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(true);

            tilesLeft = GameObject.FindGameObjectsWithTag("Tile").Length;
            ballsLeft = 3;
            isPlaying = false;
        }
        else
        {
            ballsLeftUI.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(false);
            currentLevel = 0;

        }
    }

}
