using System;

namespace ShopSystem
{
    /// <summary>
    /// An interface to represent Shop customer
    /// </summary>
    public interface IShopCustomer
    {
        /// <summary>
        /// An inventory of the customer
        /// </summary>
        IInventory Inventory { get; set; }
        /// <summary>
        /// Method to get coin amount
        /// </summary>
        /// <returns></returns>
        int GetCoinAmount();
        /// <summary>
        /// Method to set coin
        /// </summary>
        /// <param name="newAmount"></param>
        void SetCoinAmount(int newAmount);
        /// <summary>
        /// Method to handle bought product
        /// </summary>
        /// <param name="product"></param>
        void HandleBoughtProduct(Product product);
        /// <summary>
        /// Method to check if given product can be bought by customer
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        bool CanBuy(Product product);
        /// <summary>
        /// An event fired when coin amount changes
        /// </summary>
        event Action<int> OnCoinChanged;
    }

}