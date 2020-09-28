using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Rack2Controller : MonoBehaviour
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

    private int score = 1;
    private float distance;
    private float useRackDistance = 1.5f;

    private PlayerGrabSystem playerGrabSystem;
    private Renderer rack2Renderer;
    private bool change = true;
    private bool ready;

    private ScoreBoard scoreBoard;
    public Animator playerAnimator;
    public GameObject fireworks;

    public AudioSource rackAudio;
    public AudioSource dropOnRackAudio;
    private SpawnBoxes spawnBoxes;

    // Start is called before the first frame update
    void Start()
    {
        playerGrabSystem = FindObjectOfType<PlayerGrabSystem>();
        rack2Renderer = GetComponent<Renderer>();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        spawnBoxes = FindObjectOfType<SpawnBoxes>();
        fireworks.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, playerGrabSystem.gameObject.transform.position);

        if(playerGrabSystem.HasObject == true && playerGrabSystem.ObjectIndex == '9' && 
            distance <= useRackDistance && change == true && ready == false)
        {
            StartCoroutine(ChangeColor());
        }

        if (score == 9)
        {
            score = 0;

            ready = true;

            fireworks.SetActive(true);

            rackAudio.Play();

            scoreBoard.Points += 3000;
        }
    }

    private void OnMouseDown()
    {
        if (playerGrabSystem.HasObject == true && playerGrabSystem.ObjectIndex == '9' && 
            distance <= useRackDistance && ready == false)
        {
            playerGrabSystem.gameObject.transform.LookAt(transform.position);
            playerAnimator.ResetTrigger("IdleWithBox");
            playerAnimator.ResetTrigger("RunWithBox");
            playerAnimator.SetTrigger("DropRack");
            dropOnRackAudio.Play();
            playerGrabSystem.DropObject();

            switch (score)
            {
                case 1:
                    box_1.SetActive(true);
                    score++;
                    break;
                case 2:
                    box_2.SetActive(true);
                    score++;
                    break;
                case 3:
                    box_3.SetActive(true);
                    score++;
                    break;
                case 4:
                    box_4.SetActive(true);
                    score++;
                    break;
                case 5:
                    box_5.SetActive(true);
                    score++;
                    break;
                case 6:
                    box_6.SetActive(true);
                    score++;
                    break;
                case 7:
                    box_7.SetActive(true);
                    score++;
                    break;
                case 8:
                    box_8.SetActive(true);
                    score++;
                    break;
            }

            spawnBoxes.BoxesToSpawn++;
        }
    }

    IEnumerator ChangeColor()
    {
        change = false;
        rack2Renderer.material.color = Color.blue;
        yield return new WaitForSeconds(0.5f);
        rack2Renderer.material.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        change = true;
    }
}
