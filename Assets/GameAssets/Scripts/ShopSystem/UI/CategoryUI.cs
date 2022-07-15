using UnityEngine;

namespace ShopSystem
{
    /// <summary>
    /// Script which is to represent UI actions of the categories
    /// </summary>
    public class CategoryUI : MonoBehaviour
    {
        /// <summary>
        /// A parent element which this category's items will be child of
        /// </summary>
        private Transform _productUIContainer;

        /// <summary>
        /// Reference to Category object which is controlling logic behind UI
        /// </summary>
        [SerializeField] private Category _category;
        /// <summary>
        /// ProductUI prefab
        /// </summary>
        [SerializeField] private GameObject _productUIPrefab;
        /// <summary>
        /// to represent product UI area object
        /// </summary>
        [SerializeField] private Transform _productUIArea;

        /// <summary>
        /// A property accessor for category object
        /// </summary>
        public Category Category { get => _category; }

        private void Awake()
        {
            _category.OnProductAdded += OnProductAdded;
        }

        private void Start()
        {
            _productUIContainer = _productUIArea.Find("ProductUIContainer");
        }

        /// <summary>
        /// An event handler which is run when new product is added to this category
        /// </summary>
        /// <param name="product"></param>
        private void OnProductAdded(Product product)
        {
            Add(product);
        }

        /// <summary>
        /// A method for handling adding of the product
        /// </summary>
        /// <param name="product"></param>
        public void Add(Product product)
        {
            GameObject spawnedproductUIObject = Instantiate(_productUIPrefab, _productUIContainer);

            ProductUI spawnedProductUI = spawnedproductUIObject.GetComponent<ProductUI>();

            spawnedProductUI.SetProduct(product);
        }
    }

}