using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsContainer : MonoBehaviour
{
    private int score = 1;
    public int Score { get { return score; } set { score = value; } }
    private float distance;
    private float useRackDistance = 1.5f;

    private PlayerGrabSystem playerGrabSystem;
    private Renderer objectRenderer; //rack2 rack1 renderer to samo inne nazewnictwo
    private bool change = true;
    public bool ready;

    [HideInInspector]
    public ScoreBoard scoreBoard;
    public Animator playerAnimator;
    public GameObject fireworks;

    public AudioSource rackAudio;
    public AudioSource dropOnRackAudio;
    [HideInInspector]
    public SpawnBoxes spawnBoxes;

    void Start()
    {
        playerGrabSystem = FindObjectOfType<PlayerGrabSystem>();
        objectRenderer = GetComponent<Renderer>();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        spawnBoxes = FindObjectOfType<SpawnBoxes>();
        fireworks.SetActive(false);
    }
    void Update()
    {
        distance = Vector3.Distance(transform.position, playerGrabSystem.gameObject.transform.position);

        if (playerGrabSystem.HasObject == true && playerGrabSystem.ObjectIndex == '9' &&
            distance <= useRackDistance && change == true && ready == false)
        {
            StartCoroutine(ChangeColor());
        }
    }

    public bool BoxAwayAnimations()
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
            return true;
        }
        return false;
    }

    protected IEnumerator ChangeColor()
    {
        change = false;
        objectRenderer.material.color = Color.cyan;
        yield return new WaitForSeconds(0.5f);
        objectRenderer.material.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        change = true;
    }

}