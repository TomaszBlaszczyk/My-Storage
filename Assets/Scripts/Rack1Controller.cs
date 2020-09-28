using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Rack1Controller : MonoBehaviour
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

    private int score = 1;
    private float distance;
    private float useRackDistance = 1.5f;

    private PlayerGrabSystem playerGrabSystem;
    private Renderer rack1Renderer;
    private bool change = true;

    private ScoreBoard scoreBoard;
    private bool ready;
    public Animator playerAnimator;
    public GameObject fireworks;

    public AudioSource rackAudio;
    public AudioSource dropOnRackAudio;
    private SpawnBoxes spawnBoxes;

    // Start is called before the first frame update
    void Start()
    {
        playerGrabSystem = FindObjectOfType<PlayerGrabSystem>();
        rack1Renderer = GetComponent<Renderer>();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        spawnBoxes = FindObjectOfType<SpawnBoxes>();
        fireworks.SetActive(false);
        GetRandomBoxType();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, playerGrabSystem.gameObject.transform.position);

        if(playerGrabSystem.HasObject == true && playerGrabSystem.ObjectIndex == currentIndex && 
            distance <= useRackDistance && change == true && ready == false)
        {
            StartCoroutine(ChangeColor());
        }

        if (score == 3)
        {
            score = 1;
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
        if (playerGrabSystem.HasObject == true && playerGrabSystem.ObjectIndex == currentIndex && 
            distance <= useRackDistance && ready == false)
        {
            playerGrabSystem.gameObject.transform.LookAt(transform.position);
            playerAnimator.ResetTrigger("IdleWithBox");
            playerAnimator.ResetTrigger("RunWithBox");
            playerAnimator.SetTrigger("DropRack");
            dropOnRackAudio.Play();
            playerGrabSystem.DropObject();

            switch (currentType)
            {
                case 0:
                    switch (score)
                    {
                        case 1:
                            box0_1.SetActive(true);
                            score++;
                            break;
                        case 2:
                            box0_2.SetActive(true);
                            score++;
                            break;
                    }
                    break;
                case 1:
                    switch (score)
                    {
                        case 1:
                            box1_1.SetActive(true);
                            score++;
                            break;
                        case 2:
                            box1_2.SetActive(true);
                            score++;
                            break;
                    }
                    break;
                case 2:
                    switch (score)
                    {
                        case 1:
                            box2_1.SetActive(true);
                            score++;
                            break;
                        case 2:
                            box2_2.SetActive(true);
                            score++;
                            break;
                    }
                    break;
                case 3:
                    switch (score)
                    {
                        case 1:
                            box3_1.SetActive(true);
                            score++;
                            break;
                        case 2:
                            box3_2.SetActive(true);
                            score++;
                            break;
                    }
                    break;
                case 5:
                    switch (score)
                    {
                        case 1:
                            box5_1.SetActive(true);
                            score++;
                            break;
                        case 2:
                            box5_2.SetActive(true);
                            score++;
                            break;
                    }
                    break;
                case 6:
                    switch (score)
                    {
                        case 1:
                            box6_1.SetActive(true);
                            score++;
                            break;
                        case 2:
                            box6_2.SetActive(true);
                            score++;
                            break;
                    }
                    break;
                case 7:
                    switch (score)
                    {
                        case 1:
                            box7_1.SetActive(true);
                            score++;
                            break;
                        case 2:
                            box7_2.SetActive(true);
                            score++;
                            break;
                    }
                    break;
                case 8:
                    switch (score)
                    {
                        case 1:
                            box8_1.SetActive(true);
                            score++;
                            break;
                        case 2:
                            box8_2.SetActive(true);
                            score++;
                            break;
                    }
                    break;
            }

            spawnBoxes.BoxesToSpawn++;
        }
    }

    private void GetRandomBoxType()
    {
        currentType = Random.Range(0, 9);

        if(currentType == 4)
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

    IEnumerator ChangeColor()
    {
        change = false;
        rack1Renderer.material.color = Color.cyan;
        yield return new WaitForSeconds(0.5f);
        rack1Renderer.material.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        change = true;
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
