using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text time;
    public Text score;

    private string s_minutes;
    private string s_seconds;

    private int minutes = 0;
    private int seconds = 0;

    private int points = 0;
    public int Points { get { return points; } set { points = value; } }

    private bool next = true;

    public Animator doorLeft;
    public Animator doorRight;

    private int typeOfChallenge = 0;

    private SpawnBoxes spawnBoxes;
    private InGameMenu inGameMenu;

    // Start is called before the first frame update
    void Start()
    {
        time.text = "";
        score.text = "";
        typeOfChallenge = PlayerPrefs.GetInt("Challenge Type");
        spawnBoxes = FindObjectOfType<SpawnBoxes>();
        inGameMenu = FindObjectOfType<InGameMenu>();

        if(PlayerPrefs.GetInt("Challenge Type") == 1)
        {
            minutes = PlayerPrefs.GetInt("Time");
            seconds = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(next && PlayerPrefs.GetInt("Challenge Type") != 1)
        {
            StartCoroutine(TimeCounter());
        }
        else if(next && PlayerPrefs.GetInt("Challenge Type") == 1)
        {
            StartCoroutine(TimeCounterType1());
        }

        score.text = Points.ToString();

        if(Points >= PlayerPrefs.GetInt("Points") && typeOfChallenge == 3) //Próg zaliczenia poziomu (Typ 3)
        {
            doorLeft.enabled = true;
            doorRight.enabled = true;
            spawnBoxes.gameFinished = true;
            score.text = PlayerPrefs.GetInt("Points").ToString();
        }

        if(typeOfChallenge == 1 && minutes == -1)        //Próg zaliczenia poziomu (Typ 1)
        {
            inGameMenu.GameOver();
            minutes = PlayerPrefs.GetInt("Time");
            time.text = "";
        }
    }

    IEnumerator TimeCounter()
    {
        next = false;
        seconds++;
        yield return new WaitForSeconds(1f);

        if (seconds == 60)
        {
            seconds = 0;
            minutes++;
        }

        if (minutes < 10)
        {
            s_minutes = "0" + minutes + ":";
        }
        else
        {
            s_minutes = minutes + ":";
        }

        if (seconds < 10)
        {
            s_seconds = "0" + seconds;
        }
        else
        {
            s_seconds = seconds.ToString();
        }

        time.text = s_minutes + s_seconds;

        next = true;
    }

    IEnumerator TimeCounterType1()
    {
        next = false;
        seconds--;
        yield return new WaitForSeconds(1f);

        if (seconds == 0)
        {
            seconds = 59;
            minutes--;
        }

        if (minutes < 10)
        {
            s_minutes = "0" + minutes + ":";
        }
        else
        {
            s_minutes = minutes + ":";
        }

        if (seconds < 10)
        {
            s_seconds = "0" + seconds;
        }
        else
        {
            s_seconds = seconds.ToString();
        }

        time.text = s_minutes + s_seconds;

        next = true;
    }
}
