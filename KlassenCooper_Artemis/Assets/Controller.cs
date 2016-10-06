using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{

    #region Public Variables

    [Header("Components")]
    public Animator anim;
    public Rigidbody rbody;
    public Camera cam;

    [Header("Statistics")]
    [Range(0, 300)]
    public float health = 300;
    [Space]
    public bool canMove = true;
    public bool canJump = true;
    [Space]
    public float speed = 1;
    public float jumpHeight = 0;
    public float airSpeed = 1;

    [SerializeField]
    private float actualSpeed;

    public float controllerGravity = 0.1f;

    [Header("Abilties")]
    public Ability ability1;
    public Ability ability2;
    public Ability ability3;
    public Ability ability4;
    public Ability ability5;

    #endregion

    #region Private Variables

    //Inputs
    private float inputHorizontal;
    private float inputVertical;

    private bool input1;
    private bool input2;
    private bool input3;
    private bool input4;
    private bool input5;

    //Movement
    private float jumpValue = 0;
    private bool isGrounded = true;

#endregion

    void GroundCheck()
    {
        RaycastHit hit;
        float distance = 1f;
        Vector3 dir = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //Send bool to the animator
        anim.SetBool("isGrounded", isGrounded);
    }

    void Start()
    {

        //Get Components
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();

    }
	
	void Update()
    {

        //Note: It is very costly to Raycast every single frame, try and find another way.
        GroundCheck();

        if (isGrounded)
        {

            //Set speed to on ground Speed
            actualSpeed = speed;
            

            if ((Input.GetButton("Jump")) && canJump)
            {

                Jump();

            }
        }
        else if(isGrounded == false)
        {

            //Switch to in air movement speed
            actualSpeed = airSpeed;

            //Apply gravity to the character
            jumpValue = jumpValue - controllerGravity;

            if (jumpValue <= -controllerGravity)
            {
                jumpValue = -controllerGravity;
            }

        }

        //If the player moves then the character will rotate towards camera
        if (inputHorizontal != 0 || inputVertical != 0)
        {

            ControllerRotateToCamera();

        }

        //Set the floats to the current horizontal and vertical axes
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        //Send those values to the axes in the Animator
        anim.SetFloat("Horizontal", inputHorizontal);
        anim.SetFloat("Vertical", inputVertical);

        Move();

        //Set bools for the ability inputs
        input1 = Input.GetButtonDown("Fire1");
        input2 = Input.GetButtonDown("Fire2");
        input3 = Input.GetButtonDown("Fire3");
        input4 = Input.GetButtonDown("Fire4");
        input5 = Input.GetButtonDown("Fire5");

        //Complete action for every ability input
        if (input1)
        {
            ability1.UseAbility();
        }
        else if (input2)
        {
            ability2.UseAbility();
        }
        else if (input3)
        {
            ability3.UseAbility();
        }
        else if (input4)
        {
            ability4.UseAbility();
        }
        else if (input5)
        {
            ability5.UseAbility();
        }

    }

    void Jump()
    {
        jumpValue += jumpHeight;
    }

    void Move()
    {
        //Get horizontal and vertical movement and compile the variable
        float moveX = inputHorizontal * actualSpeed * Time.deltaTime;
        float moveY = jumpValue * Time.deltaTime;
        float moveZ = inputVertical * actualSpeed * Time.deltaTime;

        //Make the movement back into one Vector
        var movement = new Vector3(moveX, moveY, moveZ);

        //Get the Local Camera vector and translate it into a World Vector
        movement = cam.transform.TransformVector(movement);

        if (canMove)
        {

            transform.position += movement;

        }
    }

    void ControllerRotateToCamera()
    {
        var characterRotation = cam.transform.rotation;

        characterRotation.x = 0;
        characterRotation.z = 0;

        transform.rotation = characterRotation;
    }

}
