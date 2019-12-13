using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    public AudioSource flashSource;
    public AudioSource walkSource;
    public AudioSource runSource;

    public float walkSpeed = 6.0f;
    public float runSpeed = 12.0f;

    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;

    private CharacterController charController;

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;

    private bool isJumping;

    public Light FL1;
    public Light FL2;
    private bool flashlight = false;

    public Slider staminaBar;

    public float stamina = 20.0f;
    private bool isRunning;

    private void Start()
    {
        staminaBar.maxValue = 20.0f;
        FL1.intensity = 0.0f;
        FL2.intensity = 0.0f;
        Time.timeScale = 1.0f;
    }

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            runSource.Play();
            walkSource.Pause();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            runSource.Pause();
        }


        if (Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.LeftShift))
        {
            walkSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.W) && !Input.GetKeyDown(KeyCode.LeftShift))
        {
            walkSource.Pause();
        }

        PlayerMovement();

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashlight)
            {
                flashSource.Play();
                FL1.intensity = 0.0f;
                FL2.intensity = 0.0f;
                flashlight = false;
            }
            else
            {
                flashSource.Play();
                FL1.intensity = 1.0f;
                FL2.intensity = 0.5f;
                flashlight = true;
            }
        }
    }

    private void PlayerMovement()
    {

        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0.0f)
        {
            movementSpeed = runSpeed;
        }
        else
        {
            movementSpeed = walkSpeed;
        }

        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        if (stamina < 20.0f && !isRunning)
        {
            new WaitForSeconds(0.10f);
            stamina += 0.10f;
        } else if (stamina > 0.0f && isRunning)
        {
            new WaitForSeconds(0.10f);
            stamina -= 0.10f;
        }

        staminaBar.value = stamina;

        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);

        JumpInput();
    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;
        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
        
    }
}

