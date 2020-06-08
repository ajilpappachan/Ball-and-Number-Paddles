using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D ball;
    float ballUpSpeed = 10.0f;
    float ballRightSpeed = 0.0f;

    GameControllerScript gameController;

    // Start is called before the first frame update
    void Start()
    {
        ball = gameObject.GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
    }
   
    public void startPlaying()
    {
        ballRightSpeed = Random.Range(-10.0f, 10.0f);
        ball.velocity = new Vector2(ballRightSpeed, ballUpSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.ballsLeft--;
        if (collision.gameObject.CompareTag("Background") && gameController.ballsLeft > 0)
        {
            gameController.resetLevel();
        }
        if(gameController.ballsLeft == 0)
        {
            gameController.gameOver();
        }
    }
}
