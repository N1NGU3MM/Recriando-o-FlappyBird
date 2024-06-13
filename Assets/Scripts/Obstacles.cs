using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacu : MonoBehaviour
{

    private float cooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        cooldown -= Time.deltaTime;
        if (cooldown <= 0f)
        {
            //  Game manege
            var gameManager = GameManager.Instance;

            if (gameManager.isGameOveer)
            {
                return;
            }


            cooldown = GameManager.Instance.obtaclesInterval;
            
            // Spawn ovstacles

           int prefabIndex = Random.Range(0, gameManager.prefabs.Count);
           GameObject prefab = gameManager.prefabs[ prefabIndex ];
           float x = gameManager.obstacleOffsetX;
           float y = Random.Range(gameManager.obstacleOffsetY.x, gameManager.obstacleOffsetY.y);
           float z = 0;

           Vector3 position = new Vector3(x, y, z);

           
           Instantiate(prefab, position, prefab.transform.rotation);
        }
    }
}
