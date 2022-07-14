using System;
using UnityEngine;

namespace ShopSystem
{
    /// <summary>
    /// A class to represent product's category
    /// </summary>
    [Serializable]
    public class Category
    {
        /// <summary>
        /// An enum object to display category's type
        /// </summary>
        [SerializeField] private CategoryType _type;

        /// <summary>
        /// A property accessor for type
        /// </summary>
        public CategoryType Type { get => _type; }

        /// <summary>
        /// An event to fire when new product is added to this category
        /// </summary>
        public event Action<Product> OnProductAdded;

        /// <summary>
        /// A method to add a new product to this category
        /// </summary>
        /// <param name="product"></param>
        public void Add(Product product)
        {
            OnProductAdded?.Invoke(product);
        }
    }

}