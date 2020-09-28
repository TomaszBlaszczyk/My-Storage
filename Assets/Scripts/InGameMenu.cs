using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public Canvas menu;
    public Canvas mainCanvas;
    public Canvas gameOverCanvas;
    private ScoreBoard scoreBoard;

    public Text time;
    public Text score;

    public Text totalTime;
    public Text totalScore;

    public bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        menu.enabled = false;
        gameOverCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Escape();
        }

        time.text = scoreBoard.time.text;
        score.text = scoreBoard.score.text;
    }

    private void Escape()
    {
        if (paused == true)
        {
            menu.enabled = false;
            mainCanvas.enabled = true;
            Time.timeScale = 1;
            paused = false;   
        }
        else
        {
            menu.enabled = true;
            mainCanvas.enabled = false;
            Time.timeScale = 0;
            paused = true;
        }
    }

    public void ResumeButton()
    {
        Escape();
    }

    public void PlayAgainButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverCanvas.enabled = true;
        totalScore.text = scoreBoard.score.text;

        if (PlayerPrefs.GetInt("Challenge Type") == 1)
        {
            totalTime.text = PlayerPrefs.GetInt("Time").ToString() + " minutes";
        }
        else
        {
            totalTime.text = scoreBoard.time.text + " minutes";
        }
    }
}
