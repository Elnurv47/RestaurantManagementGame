using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static float HorizontalInput { get => Input.GetAxis("Horizontal"); }
    public static float VerticalInput { get => Input.GetAxis("Vertical"); }

    public static event Action<KeyCode> OnKeyPressed;

    private void Update()
    {
        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                OnKeyPressed?.Invoke(keyCode);
            }
        }
    }
}
