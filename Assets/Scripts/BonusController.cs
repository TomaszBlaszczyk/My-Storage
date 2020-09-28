using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusController : MonoBehaviour
{
    private PlayerGrabSystem playerGrabSystem;
    private JoystickPlayerController joystickPlayerController;
    private SpawnBoxes spawnBoxes;
    public GameObject activeBonus;
    public Animator playerAnimator;
    private ScoreBoard scoreBoard;
    private Box[] boxesOnScene;

    private float bonusTime = 5f;
    private bool bonusDone = false;
    private int bonus_index;

    public Image bonusIcon;
    public Sprite box_0;
    public Sprite box_1;
    public Sprite box_2;
    public Sprite box_3;
    public Sprite box_4;
    public Sprite box_5;
    public Sprite box_6;
    public Sprite box_7;
    public Sprite box_8;
    public Sprite box_9;

    public Sprite bonus_0;
    public Sprite bonus_1;
    public Sprite bonus_2;
    public Sprite bonus_4;
    public Sprite bonus_5;
    public Sprite bonus_6;

    public GameObject smoke;
    public AudioSource bonusAudio;

    // Start is called before the first frame update
    void Start()
    {
        activeBonus.SetActive(false);
        playerGrabSystem = FindObjectOfType<PlayerGrabSystem>();
        joystickPlayerController = FindObjectOfType<JoystickPlayerController>();
        spawnBoxes = FindObjectOfType<SpawnBoxes>();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        bonusIcon.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerGrabSystem.ObjectIndex == '7' && playerGrabSystem.ObjectName != null)
        {
            activeBonus.SetActive(true);
        }
        else
        {
            activeBonus.SetActive(false);
        }
    }

    public void ActiveBonus()
    {
        playerAnimator.ResetTrigger("IdleWithBox");
        playerAnimator.ResetTrigger("RunWithBox");
        playerAnimator.SetTrigger("Drop");
        playerGrabSystem.DropObject();

        bonusAudio.Play();

        bonus_index = UnityEngine.Random.Range(0, 7);
        Debug.LogWarning("Bonus index: " + bonus_index);

        if(scoreBoard.Points == 0 && bonus_index == 6)
        {
            bonus_index = UnityEngine.Random.Range(0, 6);
        }

        bonusIcon.enabled = true;
        spawnBoxes.BoxesToSpawn += 1;

        switch (bonus_index)
        {
            case 0:
                //Przyspieszenie czasu spawnowania skrzynek na 5 sekund
                bonusIcon.sprite = bonus_0;
                spawnBoxes.TimeToWait = 0.3f;
                StartCoroutine(WaitBonusTime());
                break;
            case 1:
                //Spowolnienie postaci na 5 sekund
                bonusIcon.sprite = bonus_1;
                joystickPlayerController.speedBonus = true;
                StartCoroutine(WaitBonusTime());
                break;
            case 2:
                //Zamiana kierunków przy sterowaniu na 5 sekund
                bonusIcon.sprite = bonus_2;
                joystickPlayerController.changeDirection = true;
                StartCoroutine(WaitBonusTime());
                break;
            case 3:
                //Usunięcie wybranego typu skrzynek z mapy
                
                int selectedBox = UnityEngine.Random.Range(0, 10);

                boxesOnScene = FindObjectsOfType<Box>();     

                switch (selectedBox)
                {
                    case 0:
                        bonusIcon.sprite = box_0;
                        break;
                    case 1:
                        bonusIcon.sprite = box_1;
                        break;
                    case 2:
                        bonusIcon.sprite = box_2;
                        break;
                    case 3:
                        bonusIcon.sprite = box_3;
                        break;
                    case 4:
                        bonusIcon.sprite = box_4;
                        break;
                    case 5:
                        bonusIcon.sprite = box_5;
                        break;
                    case 6:
                        bonusIcon.sprite = box_6;
                        break;
                    case 7:
                        bonusIcon.sprite = box_7;
                        break;
                    case 8:
                        bonusIcon.sprite = box_8;
                        break;
                    case 9:
                        bonusIcon.sprite = box_9;
                        break;
                }

                foreach (var box in boxesOnScene)
                {
                    Debug.Log("Jestem w Foreach! Obiekt o indeksie: " + box.ObjectIndex);
                    Debug.Log("SelectedBox: " + selectedBox);
                    if(box.ObjectIndex.ToString() == selectedBox.ToString())
                    {
                        spawnBoxes.BoxesToSpawn++;
                        Destroy(box.gameObject);
                    }
                }

                StartCoroutine(WaitBonusTime());
                break;
            case 4:
                //Ograniczenie widzenia na 5 sekund
                bonusIcon.sprite = bonus_4;
                Instantiate(smoke, new Vector3(6.3f, 0.2f, 15.5f), Quaternion.identity);
                StartCoroutine(WaitBonusTime());
                break;            
            case 5:
                //Plus 100 pkt
                bonusIcon.sprite = bonus_5;
                scoreBoard.Points += 100;
                StartCoroutine(WaitBonusTime());
                break;
            case 6:
                //Minus 100 pkt
                bonusIcon.sprite = bonus_6;
                scoreBoard.Points -= 100;
                StartCoroutine(WaitBonusTime());
                break;
        }

    }

    IEnumerator WaitBonusTime()
    {
        yield return new WaitForSecondsRealtime(bonusTime);

        bonusIcon.enabled = false;

        if (bonus_index == 0)
        {
            spawnBoxes.TimeToWait = 5f;
        }
        else if(bonus_index == 1)
        {
            joystickPlayerController.speedBonus = false;
        }
        else if(bonus_index == 2)
        {
            joystickPlayerController.changeDirection = false;
        }
    }
}
