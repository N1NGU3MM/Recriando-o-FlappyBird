using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    //  Game manege
        var gameManager = GameManager.Instance;
        if (gameManager.isGameOveer)
        {
            return;
        }    

        float x = GameManager.Instance.obtaclesSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);
        if (transform.position.x <= -GameManager.Instance.obstacleOffsetX)
        {
            Destroy(gameObject);
        }
    }
}