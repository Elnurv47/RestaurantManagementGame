using UnityEngine;
using UnityEngine.UI;

namespace ShopSystem
{
    /// <summary>
    /// A class to represent UI part of the Product object
    /// </summary>
    public class ProductUI : MonoBehaviour
    {
        /// <summary>
        /// A reference to product object
        /// </summary>
        private Product _product;

        /// <summary>
        /// A reference to current shop customer
        /// </summary>
        private IShopCustomer _shopCustomer;

        /// <summary>
        /// A reference to shop system
        /// </summary>
        private ShopSystem _shopSystem;

        /// <summary>
        /// A text object to display header
        /// </summary>
        [SerializeField] private Text _headerText;

        /// <summary>
        /// An image object to display image of the product
        /// </summary>
        [SerializeField] private Image _image;

        /// <summary>
        /// A text object to display price of the product
        /// </summary>
        [SerializeField] private Text _priceText;

        /// <summary>
        /// A button to buy the product
        /// </summary>
        [SerializeField] private Button _buyButton;

        private void Start()
        {
            _shopSystem = GetComponentInParent<ShopSystem>();
            _shopCustomer = _shopSystem.ShopCustomer;
            _shopCustomer.OnCoinChanged += ShopCustomer_OnCoinChanged;
        }

        /// <summary>
        /// A method to handle ShopCustomer_OnCoinChanged event
        /// </summary>
        /// <param name="coinAmount"></param>
        private void ShopCustomer_OnCoinChanged(int coinAmount)
        {
            _buyButton.interactable = _shopCustomer.CanBuy(_product);
        }

        /// <summary>
        /// A method to set the product for this UI
        /// </summary>
        /// <param name="product"></param>
        public void SetProduct(Product product)
        {
            _product = product;
            UpdateUI();
        }

        /// <summary>
        /// A method to update UI
        /// </summary>
        private void UpdateUI()
        {
            _headerText.text = _product.ItemData.Name;
            _image.sprite = _product.ItemData.Sprite;
            _priceText.text = _product.Price.ToString();
        }

        /// <summary>
        /// A method which is called when buy button is clicked
        /// </summary>
        public void OnBuyButtonClicked()
        {
            _shopCustomer.HandleBoughtProduct(_product);
            _shopSystem.ToggleShopUI(false);
        }
    }

}