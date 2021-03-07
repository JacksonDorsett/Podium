using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class MouseHandler : MonoBehaviour
{
    // horizontal rotation speed
    // public float horizontalSpeed = 1f;
    // vertical rotation speed
    //public float verticalSpeed = 1f;
    // public float xRotation = 0.0f;
    //private float yRotation = 0.0f;
    //private Camera cam;
    public float walkingSpeed = 5.5f;
    public float runningSpeed = 8.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera cam;
    public float lookSpeed = 2.0f;
    public float lookXlimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {
        // We are grounded, so recalcultae move direction based on 2  axaes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        //Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        if(Input.GetButton("Jump") )//&& characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if(!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXlimit, lookXlimit);
            cam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);




        }
    }





}
 
