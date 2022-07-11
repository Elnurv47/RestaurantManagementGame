using System;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    private Text _moneyText;

    [SerializeField] private Player _player;

    private void Awake()
    {
        _moneyText = GetComponent<Text>();
    }

    private void Start()
    {
        _player.OnMoneyChanged += Player_OnMoneyChanged;
    }

    private void Player_OnMoneyChanged(int money)
    {
        _moneyText.text = money.ToString();
    }
}
