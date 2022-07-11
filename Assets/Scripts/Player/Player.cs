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
            Debug.Log("value: " + value);
            _money = value;
            Debug.Log("money: " + _money);
            OnMoneyChanged?.Invoke(_money);
        }
    }
}
