using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _money;
    public Action<int> OnMoneyChanged;

    private void Start()
    {
        OnMoneyChanged?.Invoke(_money);
    }

    public int Money 
    { 
        get => _money; 
        set
        {
            _money = value;
            OnMoneyChanged?.Invoke(_money);
        }
    }
}
