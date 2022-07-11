using GridSystem;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private GridXZ grid;

    private void Start()
    {
        InputManager.OnKeyPressed += InputManager_OnKeyPressed;
    }

    private void InputManager_OnKeyPressed(KeyCode keyCode)
    {
        if (keyCode == KeyCode.E)
        {
            grid.SetActive(!grid.ActiveSelf);
        }
    }
}
