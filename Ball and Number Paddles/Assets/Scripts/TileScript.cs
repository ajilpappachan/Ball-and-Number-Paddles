using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour
{
    Text hitValue;
    int Health;

    public GameControllerScript gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
        hitValue = GetComponentInChildren<Text>();
        Health = (int)Random.Range(1.0f, 5.0f);
        hitValue.text = "" + Health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Health--;
            hitValue.text = "" + Health;
            if(Health <= 0)
            {
                gameController.tilesLeft--;
                if(gameController.tilesLeft == 0)
                {
                    gameController.nextLevel();
                }

                Destroy(gameObject);
            }
        }

    }
}
