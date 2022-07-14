using ShopSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private PlayerShopController _player;
    public PlayerShopController Player { get => _player; }
}
