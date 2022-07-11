using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColorOnHover : MonoBehaviour
{
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Renderer _renderer;

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        _renderer.material.color = _hoverColor;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _defaultColor;
    }
}
