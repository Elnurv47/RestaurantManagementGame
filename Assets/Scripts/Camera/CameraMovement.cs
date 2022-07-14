using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private int _cameraSpeed;

    private void Update()
    {
        float horizontalInput = InputManager.HorizontalInput;
        float verticalInput = InputManager.VerticalInput;

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

        transform.Translate(movement * Time.deltaTime * _cameraSpeed, Space.World);
    }
}
