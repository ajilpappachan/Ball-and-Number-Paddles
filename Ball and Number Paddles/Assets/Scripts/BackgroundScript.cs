using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    float speed = 0.5f;
    bool movingLeft;
    // Start is called before the first frame update
    void Start()
    {
        movingLeft = randomBool();
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.x <= -2.5f)
        {
            movingLeft = false;
        }
        else if (transform.position.x >= 2.5f)
        {
            movingLeft = true;
        }

        if(movingLeft)
        {
            transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f);
        }
        else
        {
            transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
        }
    }

    bool randomBool()
    {
        if (Random.value >= 0.5)
        {
            return true;
        }
        return false;
    }
}
