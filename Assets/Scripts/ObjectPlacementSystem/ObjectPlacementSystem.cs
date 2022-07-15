using Utils;
using ShopSystem;
using GridSystem;
using UnityEngine;
using System;

public class ObjectPlacementSystem : MonoBehaviour
{
    private GameObject _currentlyHoldObject;

    [SerializeField] private PlayerShopController _playerShopController;
    [SerializeField] private GridXZ _grid;

    private int _holdObjectRotationDegree;

    private void Start()
    {
        _playerShopController.OnProductBought += PlayerShopController_OnProductBought;
    }

    private void PlayerShopController_OnProductBought(Product boughtProduct)
    {
        Vector3 mouseWorldPosition = Utility.GetMouseWorldPosition3D();
        _currentlyHoldObject = Instantiate(boughtProduct.Model, mouseWorldPosition, Quaternion.identity);
    }

    private void Update()
    {
        if (_currentlyHoldObject == null) return;

        Vector3 mouseWorldPosition = Utility.GetMouseWorldPosition3D();

        _currentlyHoldObject.transform.position = _grid.GetNodeCenter(mouseWorldPosition);

        if (Input.GetMouseButtonDown(0))
        {
            Node builtNode = _grid.GetNode(mouseWorldPosition);
            if (builtNode.IsUsable)
            {
                Vector3 clickedNodeCenter = _grid.GetNodeCenter(builtNode);
                Instantiate(_currentlyHoldObject, clickedNodeCenter, _currentlyHoldObject.transform.rotation);
                builtNode.SetUsable(false);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, GetTargetRotationDegree(), 0));
            _currentlyHoldObject.transform.rotation = targetRotation;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(_currentlyHoldObject);
        }
    }

    private int GetTargetRotationDegree()
    {
        int newRotationDegree = (_holdObjectRotationDegree + 90) % 360;
        _holdObjectRotationDegree += 90;
        return newRotationDegree;
    }
}
