using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickPlayerController : MonoBehaviour
{
    protected Joystick joystick;
    protected JoystickJumpController jumpButton;
    protected JoystickCatchController catchButton;
    private Transform player;
    private InGameMenu inGameMenu;
    private PlayerGrabSystem playerGrabSystem;

    private Animator playerAnimator;

    private bool canJump = true;
    protected bool jump;
    private float h1;
    private float v1;

    public bool speedBonus = false;
    public bool changeDirection = false;

    // Start is called before the first frame update
    void Start()
    {
        inGameMenu = FindObjectOfType<InGameMenu>();
        joystick = FindObjectOfType<Joystick>();
        jumpButton = FindObjectOfType<JoystickJumpController>();
        catchButton = FindObjectOfType<JoystickCatchController>();
        playerGrabSystem = GetComponent<PlayerGrabSystem>();
        player = GetComponent<Transform>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inGameMenu.paused == false)
        {
            var rigidbody = GetComponent<Rigidbody>();

            if(!speedBonus && !changeDirection) //Normalna prędkość
            {
                rigidbody.velocity = new Vector3(joystick.Horizontal * 5f + Input.GetAxis("Horizontal") * 5f,
                                                 rigidbody.velocity.y,
                                                 joystick.Vertical * 5f + Input.GetAxis("Vertical") * 5f);
            }

            if(speedBonus) //Spowolnienie (bonus)
            {
                Debug.LogWarning("Dostałem spowolnienie!");
                rigidbody.velocity = new Vector3(joystick.Horizontal * 1.5f + Input.GetAxis("Horizontal"),
                                                 rigidbody.velocity.y,
                                                 joystick.Vertical * 1.5f + Input.GetAxis("Vertical"));
            }
            
            if(changeDirection) //Zamiana kierunków przy sterowaniu
            {
                rigidbody.velocity = new Vector3(-joystick.Horizontal * 5f + Input.GetAxis("Horizontal") * 5f,
                                                 rigidbody.velocity.y,
                                                 -joystick.Vertical * 5f + Input.GetAxis("Vertical") * 5f);
            }

            //Twist();

            if (rigidbody.velocity.x != 0 || rigidbody.velocity.x != 0)
            {         
                if (playerGrabSystem.HasObject)
                {
                    playerAnimator.ResetTrigger("IdleWithBox");
                    playerAnimator.SetTrigger("RunWithBox");
                }    
                else
                {
                    playerAnimator.ResetTrigger("Idle");
                    playerAnimator.SetTrigger("Run");
                }
            }
            else
            {
                if(playerGrabSystem.HasObject == false)
                {
                    playerAnimator.ResetTrigger("Run");
                    playerAnimator.SetTrigger("Idle");
                }
                else
                {
                    playerAnimator.ResetTrigger("RunWithBox");
                    playerAnimator.SetTrigger("IdleWithBox");
                }                
            }

            if (!jump && jumpButton.Pressed && canJump == true && !playerGrabSystem.HasObject)
            {
                jump = true;
                canJump = false;
                playerAnimator.ResetTrigger("Run");
                playerAnimator.ResetTrigger("Idle");
                playerAnimator.SetTrigger("JumpUp");
                rigidbody.velocity += Vector3.up * 5f;
                StartCoroutine(WaitUntilJump());
            }

            if (jump && !jumpButton.Pressed)
            {
                jump = false;
            }

            if (player.rotation.x != 0 ||
                player.rotation.z != 0)
            {
                float currentRotation_Y = player.rotation.y;
                float currentRotation_W = player.rotation.w;

                player.rotation = new Quaternion(0f, currentRotation_Y, 0f, currentRotation_W);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                playerAnimator.SetTrigger("Happy");
            }
        }
    }

    private void Twist()
    {
        h1 = Input.GetAxis("Horizontal"); // set as your inputs 
        v1 = Input.GetAxis("Vertical");
        if (h1 == 0f && v1 == 0f)
        { // this statement allows it to recenter once the inputs are at zero 
            Vector3 curRot = player.localEulerAngles; // the object you are rotating
            Vector3 homeRot;
            if (curRot.y > 180f)
            { // this section determines the direction it returns home 
                //Debug.Log(curRot.y);
                homeRot = new Vector3(0f, 359.999f, 0f); //it doesnt return to perfect zero 
            }
            else
            {                                                                      // otherwise it rotates wrong direction 
                homeRot = Vector3.zero;
            }
            player.localEulerAngles = Vector3.Slerp(curRot, homeRot, Time.deltaTime * 2);
        }
        else
        {
            player.localEulerAngles = new Vector3(0f, Mathf.Atan2(h1, v1) * 180 / Mathf.PI, 0f); // this does the actual rotaion according to inputs
        }
    }

    IEnumerator WaitUntilJump()
    {
        yield return new WaitForSecondsRealtime(1f);
        canJump = true;
    }
}
