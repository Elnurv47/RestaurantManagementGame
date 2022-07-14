using System;
using UnityEngine;

namespace ShopSystem
{
    /// <summary>
    /// A class represent the product
    /// </summary>
    [Serializable]
    public class Product
    {
        /// <summary>
        /// Price of the product
        /// </summary>
        [SerializeField] private int _price;
        public int Price { get => _price; }

        /// <summary>
        /// A data of the product
        /// </summary>
        [SerializeField] private ItemData _data;
        public ItemData ItemData { get => _data; }

        /// <summary>
        /// A category of the product
        /// </summary>
        [SerializeField] private Category _category;
        public Category Category { get => _category; }
    }

}