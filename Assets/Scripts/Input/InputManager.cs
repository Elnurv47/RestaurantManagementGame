using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static float HorizontalInput { get => Input.GetAxis("Horizontal"); }
    public static float VerticalInput { get => Input.GetAxis("Vertical"); }
}
