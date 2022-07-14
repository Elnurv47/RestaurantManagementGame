using UnityEngine;
using UnityEngine.UI;

namespace ShopSystem
{
    /// <summary>
    /// A class to display coin amount in the UI
    /// </summary>
    public class CoinText : MonoBehaviour
    {
        /// <summary>
        /// A reference to the Text object
        /// </summary>
        private Text _coinText;

        /// <summary>
        /// A reference to the PlayerShopController object
        /// </summary>
        [SerializeField] private PlayerShopController _player;

        private void Awake()
        {
            _coinText = GetComponent<Text>();
            _player.OnCoinChanged += Player_OnCoinChanged;
        }

        private void OnEnable()
        {
            _player.OnCoinChanged += Player_OnCoinChanged;
        }

        private void OnDisable()
        {
            _player.OnCoinChanged -= Player_OnCoinChanged;
        }

        /// <summary>
        /// An event handler which is run when coin amount changes
        /// </summary>
        /// <param name="cointAmount"></param>
        private void Player_OnCoinChanged(int cointAmount)
        {
            _coinText.text = cointAmount.ToString();
        }
    }

}