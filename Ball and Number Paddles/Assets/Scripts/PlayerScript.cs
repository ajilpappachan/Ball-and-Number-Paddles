using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    GameObject player;

    public float speed = 5.0f;

    GameControllerScript gameController;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Move Paddle

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 0 && Camera.main.ScreenToWorldPoint(Input.mousePosition).y < 8 && player.transform.position.x > -4.5f)
            {
                player.transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f);
                if (!gameController.isPlaying)
                {
                    gameController.startLevel();
                }
            }

            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > 0 && Camera.main.ScreenToWorldPoint(Input.mousePosition).y < 8 && player.transform.position.x < 4.5f)
            {
                player.transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
                if (!gameController.isPlaying)
                {
                    gameController.startLevel();
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            gameController.nextLevel();
        }
    }
}
