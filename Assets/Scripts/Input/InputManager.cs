using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
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
