using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private PlayerGrabSystem playerGrabSystem;
    private SpawnBoxes spawnBoxes;
    private Renderer tileRenderer;

    private Vector3 spawnPosition;
    private bool change = true;

    private float distance;
    private float dropDistance = 1.5f;
    private float range = 0.1f;

    private char boxIndex = ' ';
    public char BoxIndex { get { return boxIndex; } set { boxIndex = value; } }

    public GameObject target;
    public Animator playerAnimator;

    public AudioSource dropAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerGrabSystem = FindObjectOfType<PlayerGrabSystem>();
        tileRenderer = GetComponent<Renderer>();
        spawnBoxes = FindObjectOfType<SpawnBoxes>();
        //playerAnimator = FindObjectOfType<Animator>();

        spawnPosition = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, playerGrabSystem.gameObject.transform.position);

        if (playerGrabSystem.HasObject == true && change == true && distance <= dropDistance)
        {
            StartCoroutine(ChangeColor());
        }

        if(playerGrabSystem.HasObject == false)
        {
            tileRenderer.material.color = Color.white;
        }

        Raycast();
    }

    private void OnMouseDown()
    {      
        if(playerGrabSystem.HasObject == true && distance <= dropDistance)
        {
            playerGrabSystem.gameObject.transform.LookAt(transform.position);
            playerAnimator.ResetTrigger("IdleWithBox");
            playerAnimator.ResetTrigger("RunWithBox");
            playerAnimator.SetTrigger("Drop");
            dropAudio.Play();
            playerGrabSystem.DropObject();
            SpawnObjectOnTile();
        }     
    }

    IEnumerator ChangeColor()
    {
        change = false;
        tileRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        tileRenderer.material.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        change = true;
    }

    public void SpawnObjectOnTile()
    {
        switch (playerGrabSystem.ObjectIndex)
        {
            case '0':
                Instantiate(spawnBoxes.box_0, spawnPosition, transform.rotation);
                break;
            case '1':
                Instantiate(spawnBoxes.box_1, spawnPosition, transform.rotation);
                break;
            case '2':
                Instantiate(spawnBoxes.box_2, spawnPosition, transform.rotation);
                break;
            case '3':
                Instantiate(spawnBoxes.box_3, spawnPosition, transform.rotation);
                break;
            case '4':
                Instantiate(spawnBoxes.box_4, spawnPosition, transform.rotation);
                break;
            case '5':
                Instantiate(spawnBoxes.box_5, spawnPosition, transform.rotation);
                break;
            case '6':
                Instantiate(spawnBoxes.box_6, spawnPosition, transform.rotation);
                break;
            case '7':
                Instantiate(spawnBoxes.box_7, spawnPosition, transform.rotation);
                break;
            case '8':
                Instantiate(spawnBoxes.box_8, spawnPosition, transform.rotation);
                break;
            case '9':
                Instantiate(spawnBoxes.box_9, spawnPosition, transform.rotation);
                break;
        }
    }

    private void Raycast()
    {
        Ray shotRay = new Ray(transform.position, transform.up);
        RaycastHit shotInfo;

        if (Physics.Raycast(shotRay, out shotInfo, range))
        {
            target = shotInfo.collider.gameObject;

            Box box = target.GetComponent<Box>();

            if (box != null)
            {
                boxIndex = box.ObjectIndex;
            }
        }
        else
        {
            boxIndex = ' ';
        }
    }
}
