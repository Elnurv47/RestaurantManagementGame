using GridSystem;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private GridXZ grid;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            grid.SetActive(!grid.ActiveSelf);
        }
    }
}
