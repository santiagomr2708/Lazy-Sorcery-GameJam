using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform characterTransform;
    [SerializeField] private Camera cameraCharacter;

    private Vector3 movement;
    private float xRotation;

    private void Update()
    {
        CharacterMovement();
        CameraMovement();
    }

    void CharacterMovement()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        movement = transform.right * movX + transform.forward * movZ;
        characterController.SimpleMove(movement * movementSpeed);
    }

    void CameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        cameraCharacter.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        characterTransform.Rotate(Vector3.up * mouseX);
    }
}
