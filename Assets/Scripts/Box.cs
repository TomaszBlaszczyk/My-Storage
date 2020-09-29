using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private PlayerGrabSystem playerGrabSystem;
    private Renderer boxRenderer;
    private float distance;
    private float pickUpDistance = 1.5f;
    private bool change = true;
    private char objectIndex;
    public char ObjectIndex { get { return objectIndex; } }
    private Color defaultColor;

    private float range = 5f;
    private Animator playerAnimator;
    private AudioSource pickUpSound;

    // Start is called before the first frame update
    void Start()
    {
        objectIndex = gameObject.name[4];
        playerGrabSystem = FindObjectOfType<PlayerGrabSystem>();
        boxRenderer = GetComponent<Renderer>();
        defaultColor = boxRenderer.material.color;
        playerAnimator = playerGrabSystem.gameObject.GetComponent<Animator>();
        pickUpSound = playerGrabSystem.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, playerGrabSystem.gameObject.transform.position);

        if(distance <= pickUpDistance && change == true && playerGrabSystem.HasObject == false)
        {
            StartCoroutine(ChangeColor());
        }
    }

    private void OnMouseDown()
    {
        if(playerGrabSystem.HasObject == false && distance <= pickUpDistance)
        {
            playerGrabSystem.gameObject.transform.LookAt(transform.position);
            playerAnimator.ResetTrigger("Idle");
            playerAnimator.ResetTrigger("Run");
            playerAnimator.SetTrigger("PickUp");
            pickUpSound.Play();
            gameObject.SetActive(false);
            playerGrabSystem.ObjectName = gameObject.name;
        }
        
        //Metoda odpowiedzialna za odkładanie skrzynek na inne skrzynki (Niepotrzebne)
        //if(playerGrabSystem.HasObject == true && distance <= pickUpDistance)
        //{          
        //    Raycast();
        //}
    }

    IEnumerator ChangeColor()
    {
        change = false;
        boxRenderer.material.color = Color.green;
        yield return new WaitForSeconds(0.5f);
        boxRenderer.material.color = defaultColor;    
        yield return new WaitForSeconds(0.5f);
        change = true;
    }

    private void Raycast()
    {
        Ray shotRay = new Ray(transform.position, -transform.up);
        RaycastHit shotInfo;

        if (Physics.Raycast(shotRay, out shotInfo, range))
        {
            GameObject target = shotInfo.collider.gameObject;

            Floor tile = target.GetComponent<Floor>();

            if (tile != null)
            {
                playerGrabSystem.gameObject.transform.LookAt(transform.position);
                playerAnimator.ResetTrigger("IdleWithBox");
                playerAnimator.ResetTrigger("RunWithBox");
                playerAnimator.SetTrigger("Drop");

                playerGrabSystem.DropObject();
                tile.SpawnObjectOnTile();
            }
        }
    }
}
