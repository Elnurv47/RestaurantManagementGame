using UnityEngine;
using System.Collections.Generic;

namespace ShopSystem
{
    /// <summary>
    /// A class used to represent product container in the scene
    /// </summary>
    public class ProductContainer : MonoBehaviour
    {
        /// <summary>
        /// Singleton Pattern
        /// </summary>
        public static ProductContainer Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// List of products to be filled in inspector
        /// </summary>
        public List<Product> Products;
    }

}