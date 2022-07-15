using System;
using UnityEngine;

namespace ShopSystem
{
    /// <summary>
    /// A script to represent Player as Shop customer
    /// </summary>
    public class PlayerShopController : MonoBehaviour, IShopCustomer
    {
        /// <summary>
        /// Player's coin
        /// </summary>
        [SerializeField] private int _coinAmount = 200;

        /// <summary>
        /// A reference to the Shop system
        /// </summary>
        [SerializeField] private ShopSystem _shopSystem;

        /// <summary>
        /// A reference to the user inventory (get and set to be filled by user)
        /// </summary>
        public IInventory Inventory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// An event fired when coin amount changes
        /// </summary>
        public event Action<int> OnCoinChanged;

        public event Action<Product> OnProductBought;


        private void Awake()
        {
            _shopSystem.ShopCustomer = this;
        }

        /// <summary>
        /// Method to set coin
        /// </summary>
        /// <param name="newAmount"></param>
        public int GetCoinAmount()
        {
            return _coinAmount;
        }

        /// <summary>
        /// Method to set coin
        /// </summary>
        /// <param name="newAmount"></param>
        public void SetCoinAmount(int newAmount)
        {
            _coinAmount = newAmount;
            OnCoinChanged?.Invoke(_coinAmount);
        }

        /// <summary>
        /// Method to handle bought product
        /// </summary>
        /// <param name="product"></param>
        public void HandleBoughtProduct(Product product)
        {
            /*_coinAmount -= product.Price;
            OnCoinChanged?.Invoke(_coinAmount);
            Inventory.AddItem(new Item(1, product.ItemData));*/

            _coinAmount -= product.Price;
            OnCoinChanged?.Invoke(_coinAmount);
            OnProductBought?.Invoke(product);
        }

        /// <summary>
        /// Method to check if given product can be bought by customer
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool CanBuy(Product product)
        {
            return _coinAmount >= product.Price;
        }
    }
}
