using System;
using UnityEngine;

public class BuyingWithMoneyCondition
{
    private int _areaPrice;

    public BuyingWithMoneyCondition(int areaPrice)
    {
        _areaPrice = areaPrice;
    }

    public bool IsAcceptable(int customerMoney)
    {
        if (_areaPrice <= customerMoney)
        {
            Debug.Log($"Area can be bought: area price: {_areaPrice}, customer money: {customerMoney}");
            return true;
        }

        Debug.Log($"Area can't be bought: area price: {_areaPrice}, customer money: {customerMoney}");
        return false;
    }
}

public class BuyableAreaHologram : MonoBehaviour
{
    private int _areaPrice = 25;
    public BuyingWithMoneyCondition _areaBuyCondition;

    public event Action<BuyableAreaHologram> OnAreaIsBuyable;

    private void Start()
    {
        _areaBuyCondition = new BuyingWithMoneyCondition(_areaPrice);
    }

    public void TryBuy()
    {
        if (_areaBuyCondition.IsAcceptable(GameManager.Instance.Player.Money))
        {
            QuestionDialogUI.Instance.AskQuestion($"Do you want to buy this area for {_areaPrice} ?", () =>
            {
                GameManager.Instance.Player.Money -= _areaPrice;
                OnAreaIsBuyable?.Invoke(this);
                Debug.Log("Here");
            },
            () => { }
            );
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
