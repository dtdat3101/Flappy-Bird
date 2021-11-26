using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameStart;
    public GameObject gameOver;
    public GameObject score;
    // Start is called before the first frame update
    public StatusGame statusGame;


    void Start()
    {
        statusGame = StatusGame.HELLO;
        Time.timeScale = 0;
    }

    private void Update()
    {
        if(statusGame == StatusGame.HELLO)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
                statusGame = StatusGame.START;
                score.SetActive(true);
                gameStart.SetActive(false);
            }
        }

    }
    public void GameOver()
    {
        statusGame = StatusGame.END;
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

}

public enum StatusGame
{
    NONE,
    HELLO,
    START,
    END
}
