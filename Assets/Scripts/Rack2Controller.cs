using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Rack2Controller : ActionsContainer
{
    public GameObject box_0;
    public GameObject box_1;
    public GameObject box_2;
    public GameObject box_3;
    public GameObject box_4;
    public GameObject box_5;
    public GameObject box_6;
    public GameObject box_7;
    public GameObject box_8;

    void Update()
    {
        if (Score == 9)
        {
            Score = 0;

            ready = true;

            fireworks.SetActive(true);

            rackAudio.Play();

            scoreBoard.Points += 3000;
        }
    }

    private void OnMouseDown()
    {
        if (BoxAwayAnimations())
        {
            switch (Score)
            {
                case 1:
                    box_1.SetActive(true);
                    Score++;
                    break;
                case 2:
                    box_2.SetActive(true);
                    Score++;
                    break;
                case 3:
                    box_3.SetActive(true);
                    Score++;
                    break;
                case 4:
                    box_4.SetActive(true);
                    Score++;
                    break;
                case 5:
                    box_5.SetActive(true);
                    Score++;
                    break;
                case 6:
                    box_6.SetActive(true);
                    Score++;
                    break;
                case 7:
                    box_7.SetActive(true);
                    Score++;
                    break;
                case 8:
                    box_8.SetActive(true);
                    Score++;
                    break;
            }
            spawnBoxes.BoxesToSpawn++;
        }
    }
}
