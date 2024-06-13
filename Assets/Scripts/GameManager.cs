using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set;}

    public List<GameObject> prefabs;
    public float obtaclesInterval = 1;
    public float obtaclesSpeed = 10;

    public float obstacleOffsetX = 0;

    public Vector2 obstacleOffsetY = new Vector2(0, 0);

    [HideInInspector]
    public int score;
    
    public bool isGameOveer = false;


    void Awake ()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public bool isGameActive()
    {
        return !isGameOveer;
    }
    public bool isGameOver()
    {
        return isGameOveer;
    }
    public void EndGame()
    {
        // End Game
        isGameOveer = true;

        // Reload Sene
        StartCoroutine(ReloadScene(2));
        

    }

    private IEnumerator ReloadScene(float delay)
    {
        // sait
        yield return new WaitForSeconds(delay);
       
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Reload... ");
    }
}
