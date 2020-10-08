using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rack1Controller : ActionsContainer
{
    public GameObject box0_0;
    public GameObject box0_1;
    public GameObject box0_2;

    public GameObject box1_0;
    public GameObject box1_1;
    public GameObject box1_2;

    public GameObject box2_0;
    public GameObject box2_1;
    public GameObject box2_2;

    public GameObject box3_0;
    public GameObject box3_1;
    public GameObject box3_2;

    public GameObject box5_0;
    public GameObject box5_1;
    public GameObject box5_2;

    public GameObject box6_0;
    public GameObject box6_1;
    public GameObject box6_2;

    public GameObject box7_0;
    public GameObject box7_1;
    public GameObject box7_2;

    public GameObject box8_0;
    public GameObject box8_1;
    public GameObject box8_2;

    private int currentType;
    private char currentIndex;

    void Start()
    {
        GetRandomBoxType();
    }

    void Update()
    {
        if (Score == 3)
        {
            Score = 1;
            ready = true;

            rackAudio.Play();

            scoreBoard.Points += 500;
            fireworks.SetActive(true);

            StartCoroutine(WaitBeforeChangeType());

            DisableAll();

            ready = false;
            GetRandomBoxType();
        }
    }

    private void OnMouseDown()
    {
        if (BoxAwayAnimations())
        {
            switch (currentType)
            {
                case 0:
                    switch (Score)
                    {
                        case 1:
                            box0_1.SetActive(true);
                            Score++;
                            break;
                        case 2:
                            box0_2.SetActive(true);
                            Score++;
                            break;
                    }
                    break;
                case 1:
                    switch (Score)
                    {
                        case 1:
                            box1_1.SetActive(true);
                            Score++;
                            break;
                        case 2:
                            box1_2.SetActive(true);
                            Score++;
                            break;
                    }
                    break;
                case 2:
                    switch (Score)
                    {
                        case 1:
                            box2_1.SetActive(true);
                            Score++;
                            break;
                        case 2:
                            box2_2.SetActive(true);
                            Score++;
                            break;
                    }
                    break;
                case 3:
                    switch (Score)
                    {
                        case 1:
                            box3_1.SetActive(true);
                            Score++;
                            break;
                        case 2:
                            box3_2.SetActive(true);
                            Score++;
                            break;
                    }
                    break;
                case 5:
                    switch (Score)
                    {
                        case 1:
                            box5_1.SetActive(true);
                            Score++;
                            break;
                        case 2:
                            box5_2.SetActive(true);
                            Score++;
                            break;
                    }
                    break;
                case 6:
                    switch (Score)
                    {
                        case 1:
                            box6_1.SetActive(true);
                            Score++;
                            break;
                        case 2:
                            box6_2.SetActive(true);
                            Score++;
                            break;
                    }
                    break;
                case 7:
                    switch (Score)
                    {
                        case 1:
                            box7_1.SetActive(true);
                            Score++;
                            break;
                        case 2:
                            box7_2.SetActive(true);
                            Score++;
                            break;
                    }
                    break;
                case 8:
                    switch (Score)
                    {
                        case 1:
                            box8_1.SetActive(true);
                            Score++;
                            break;
                        case 2:
                            box8_2.SetActive(true);
                            Score++;
                            break;
                    }
                    break;
            }
            spawnBoxes.BoxesToSpawn++;
        }
    }


    //tylko w rack1
    private void GetRandomBoxType()
    {
        currentType = UnityEngine.Random.Range(0, 9);

        if (currentType == 4)
        {
            currentType = 5;
        }

        switch (currentType)
        {
            case 0:
                box0_0.SetActive(true);
                currentIndex = '0';
                break;
            case 1:
                box1_0.SetActive(true);
                currentIndex = '1';
                break;
            case 2:
                box2_0.SetActive(true);
                currentIndex = '2';
                break;
            case 3:
                box3_0.SetActive(true);
                currentIndex = '3';
                break;
            case 5:
                box5_0.SetActive(true);
                currentIndex = '5';
                break;
            case 6:
                box6_0.SetActive(true);
                currentIndex = '6';
                break;
            case 7:
                box7_0.SetActive(true);
                currentIndex = '7';
                break;
            case 8:
                box8_0.SetActive(true);
                currentIndex = '8';
                break;
        }
    }

    IEnumerator WaitBeforeChangeType()
    {
        yield return new WaitForSecondsRealtime(3f);
    }

    private void DisableAll()
    {
        box0_0.SetActive(false);
        box0_1.SetActive(false);
        box0_2.SetActive(false);

        box1_0.SetActive(false);
        box1_1.SetActive(false);
        box1_2.SetActive(false);

        box2_0.SetActive(false);
        box2_1.SetActive(false);
        box2_2.SetActive(false);

        box3_0.SetActive(false);
        box3_1.SetActive(false);
        box3_2.SetActive(false);

        box5_0.SetActive(false);
        box5_1.SetActive(false);
        box5_2.SetActive(false);

        box6_0.SetActive(false);
        box6_1.SetActive(false);
        box6_2.SetActive(false);

        box7_0.SetActive(false);
        box7_1.SetActive(false);
        box7_2.SetActive(false);

        box8_0.SetActive(false);
        box8_1.SetActive(false);
        box8_2.SetActive(false);

    }
}
