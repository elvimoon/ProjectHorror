using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempPlayerMovement : MonoBehaviour
{
    public float walkSpeed = 2.0f;
    public float runSpeed = 5.0f;

    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;

    private CharacterController charController;

    public Light FL1;
    public Light FL2;
    private bool flashlight = false;

    public float stamina = 20.0f;
    private bool isRunning;

    private void Start()
    { 
        FL1.intensity = 0.0f;
        FL2.intensity = 0.0f;
    }

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashlight)
            {
                FL1.intensity = 0.0f;
                FL2.intensity = 0.0f;
                flashlight = false;
            }
            else
            {
                FL1.intensity = 0.5f;
                FL2.intensity = 0.3f;
                flashlight = true;
            }
        }
    }

    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);
    }
}
