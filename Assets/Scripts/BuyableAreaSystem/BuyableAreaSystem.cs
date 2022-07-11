using GridSystem;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class BuyableAreaSystem : MonoBehaviour
{
    [SerializeField] private float _areaXZScale;
    [SerializeField] private float _areaYScale;
    [SerializeField] private Area _areaPrefab;
    [SerializeField] private Transform _areaParentTransform;
    [SerializeField] private BuyableAreaHologram _buyableAreaHologramPrefab;
    [SerializeField] private GridXZ _gridXZ;

    private List<Area> _areasBoughtInBuyingProcess;

    private void Start()
    {
        Area boughtArea = Instantiate(_areaPrefab, _gridXZ.GetGridCenterPosition(), Quaternion.identity, _areaParentTransform);
        boughtArea.Scale(new Vector3(_areaXZScale, _areaYScale, _areaXZScale));
        boughtArea.Init(_gridXZ);

        _areasBoughtInBuyingProcess = new List<Area>();

        _areasBoughtInBuyingProcess.Add(boughtArea);

        SpawnBuyableAreaHologramsAround(boughtArea);

        InputManager.OnKeyPressed += InputManager_OnKeyPressed;

        _gridXZ.OnGridActivated += GridXZ_OnGridActivated;
        _gridXZ.OnGridDeactivated += GridXZ_OnGridDeactivated;
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        if (EventSystem.current.IsPointerOverGameObject()) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out RaycastHit hitInfo)) return;

        if (hitInfo.collider.GetComponent<BuyableAreaHologram>() == null) return;

        BuyableAreaHologram clickedBuyableAreaHologram = hitInfo.collider.GetComponent<BuyableAreaHologram>();

        clickedBuyableAreaHologram.TryBuy();
    }

    public void BuyArea(BuyableAreaHologram buyableAreaHologram)
    {
        Area boughtArea = Instantiate(_areaPrefab, buyableAreaHologram.transform.position, Quaternion.identity, _areaParentTransform);
        boughtArea.Scale(new Vector3(_areaXZScale, _areaYScale, _areaXZScale));
        boughtArea.Init(_gridXZ);

        _areasBoughtInBuyingProcess.Add(boughtArea);

        buyableAreaHologram.OnAreaIsBuyable -= SpawnedBuyableAreaHologram_OnAreaIsBuyable;
        buyableAreaHologram.DestroySelf();

        SpawnBuyableAreaHologramsAround(boughtArea);
    }

    private void SpawnBuyableAreaHologramsAround(Area boughtArea)
    {
        Vector3 boughtAreaCenter = boughtArea.transform.position;
        Vector3 forward = boughtAreaCenter + Vector3.forward * _areaXZScale;

        if (!PositionOccupied(forward))
        {
            SpawnBuyableAreaHologram(forward);
        }

        Vector3 right = boughtAreaCenter + Vector3.right * _areaXZScale;

        if (!PositionOccupied(right))
        {
            SpawnBuyableAreaHologram(right);
        }

        Vector3 back = boughtAreaCenter + Vector3.back * _areaXZScale;

        if (!PositionOccupied(back))
        {
            SpawnBuyableAreaHologram(back);
        }

        Vector3 left = boughtAreaCenter + Vector3.left * _areaXZScale;

        if (!PositionOccupied(left))
        {
            SpawnBuyableAreaHologram(left);
        }
    }

    private bool PositionOccupied(Vector3 center)
    {
        Vector3 halfExtents = new Vector3(_areaXZScale - 0.1f, _areaYScale - 0.1f, _areaXZScale - 0.1f) / 2;
        Collider[] colliders = Physics.OverlapBox(center, halfExtents);
        colliders = colliders.Where(collider => collider.GetComponent<Area>() != null).ToArray();
        return colliders.Length > 0;
    }

    private void SpawnBuyableAreaHologram(Vector3 position)
    {
        BuyableAreaHologram spawnedBuyableAreaHologram = Instantiate(_buyableAreaHologramPrefab, position, Quaternion.identity, _areaParentTransform);
        spawnedBuyableAreaHologram.OnAreaIsBuyable += SpawnedBuyableAreaHologram_OnAreaIsBuyable;
    }

    private void SpawnedBuyableAreaHologram_OnAreaIsBuyable(BuyableAreaHologram buyableAreaHologram)
    {
        BuyArea(buyableAreaHologram);
    }

    private void InputManager_OnKeyPressed(KeyCode keyCode)
    {
        if (keyCode == KeyCode.E)
        {
            _areaParentTransform.gameObject.SetActive(!_areaParentTransform.gameObject.activeSelf);
        }
    }

    private void GridXZ_OnGridActivated()
    {
        foreach (Area boughtArea in _areasBoughtInBuyingProcess)
        {
            boughtArea.Init(_gridXZ);
        }
    }

    private void GridXZ_OnGridDeactivated()
    {
        _areasBoughtInBuyingProcess.Clear();
    }
}
