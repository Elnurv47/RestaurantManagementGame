using UnityEngine;
using System.Collections.Generic;

namespace ShopSystem
{
    public class ShopSystem : MonoBehaviour
    {
        /// <summary>
        /// Product list
        /// </summary>
        private List<Product> _products;
        /// <summary>
        /// Category list
        /// </summary>
        private List<Category> _categories;

        /// <summary>
        /// An interface instance to fetch products from given source
        /// </summary>
        private IProductFetcher _productFetcher;

        /// <summary>
        /// An interface instance to represent some object as shop customer
        /// </summary>

        private IShopCustomer _shopCustomer;

        /// <summary>
        /// A property accessor for _shopCustomer
        /// </summary>
        public IShopCustomer ShopCustomer { get => _shopCustomer; set => _shopCustomer = value; }

        /// <summary>
        /// A parent object which categories are child of
        /// </summary>
        [SerializeField] private Transform _categoryContainer;

        private void Awake()
        {
            _products = new List<Product>();
            _categories = new List<Category>();
        }

        private void Start()
        {
            FetchCategoriesFromScene();
            List<Product> products = FetchAllProducts();
            products.ForEach(product => AddProduct(product));
        }

        public void OnToggleShopUIButtonClicked()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        public void ToggleShopUI(bool active)
        {
            gameObject.SetActive(active);
        }

        /// <summary>
        /// A method to fetch all products
        /// </summary>
        /// <returns></returns>
        private List<Product> FetchAllProducts()
        {
            _productFetcher = new ProductFetcherFromContainerObject(ProductContainer.Instance);

            List<Product> products = _productFetcher.Fetch();
            return products;
        }

        /// <summary>
        /// A method to fetch all current categories from the scene
        /// </summary>
        private void FetchCategoriesFromScene()
        {
            foreach (Transform childCategory in _categoryContainer)
            {
                CategoryUI categoryUI = childCategory.GetComponent<CategoryUI>();
                Category category = categoryUI.Category;
                _categories.Add(category);
            }
        }

        /// <summary>
        /// Method to add a new product to Shop system
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            _products.Add(product);

            Category appropriateCategory = FindAppropriateCategory(product);

            appropriateCategory.Add(product);
        }

        /// <summary>
        /// Method to find appropriate category for the product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        private Category FindAppropriateCategory(Product product)
        {
            return _categories.Find(
                category => category.Type == product.Category.Type
            );
        }
    }
}
