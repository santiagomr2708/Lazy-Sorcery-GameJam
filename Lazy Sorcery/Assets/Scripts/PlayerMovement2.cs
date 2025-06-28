using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float movementSpeed = 6f;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float jumpHeight = 2f;

    [Header("Componentes")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform characterTransform;
    [SerializeField] private Camera cameraCharacter;

    [Header("Gravedad")]
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.3f;
    [SerializeField] private LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;
    private float xRotation;

    void OnEnable()
    {
        // Cuando el componente se activa: bloquea y oculta el cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnDisable()
    {
        // Cuando el componente se desactiva: libera y muestra el cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Alternamos entre bloqueado+oculto y libre+visible
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        GroundCheck();
        CharacterMovement();
        CameraMovement();
    }

    void GroundCheck()
    {
       
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
    }

    void CharacterMovement()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        Vector3 move = characterTransform.right * movX + characterTransform.forward * movZ;
        move.y = 0f;

        characterController.Move(move * movementSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void CameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraCharacter.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        characterTransform.Rotate(Vector3.up * mouseX);
    }
}

