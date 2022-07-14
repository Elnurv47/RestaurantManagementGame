using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ShopSystem
{
    /// <summary>
    /// A script to UI object as tab
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class Tab : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        /// <summary>
        /// A reference to TabController object
        /// </summary>
        private TabController _tabController;

        /// <summary>
        /// A reference to tab's background image
        /// </summary>
        private Image _background;

        /// <summary>
        /// A boolean to check if this tab is selected
        /// </summary>
        private bool _isSelected;

        /// <summary>
        /// A color used when this tab is in normal state
        /// </summary>
        [SerializeField] private Color _defaultColor;

        /// <summary>
        /// A color used when this tab is hovered over
        /// </summary>
        [SerializeField] private Color _tintColor;

        /// <summary>
        /// A color used when this tab is selected
        /// </summary>
        [SerializeField] private Color _selectedColor;

        /// <summary>
        /// A UI panel to display when this tab is selected
        /// </summary>
        [SerializeField] private GameObject _panelToDisplayWhenThisSelected;

        private void Awake()
        {
            _tabController = GetComponentInParent<TabController>();
            _background = GetComponent<Image>();
        }

        /// <summary>
        /// Method to select this tab
        /// </summary>
        public void Select()
        {
            _isSelected = true;
            _background.color = _selectedColor;
            _panelToDisplayWhenThisSelected.SetActive(true);
        }

        /// <summary>
        /// Method to deselect this tab
        /// </summary>
        public void Deselect()
        {
            _isSelected = false;
            _background.color = _defaultColor;
            _panelToDisplayWhenThisSelected.SetActive(false);
        }

        /// <summary>
        /// An event handler of the IPointerClickHandler interface
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerClick(PointerEventData eventData)
        {
            _tabController.DeselectTabs();
            _panelToDisplayWhenThisSelected.SetActive(true);
            _background.color = _selectedColor;
            _isSelected = true;
        }

        /// <summary>
        /// An event handler of the IPointerEnterHandler interface
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_isSelected) return;

            _background.color = _tintColor;
        }

        /// <summary>
        /// An event handler of the IPointerExitHandler interface
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerExit(PointerEventData eventData)
        {
            if (_isSelected) return;

            _background.color = _defaultColor;
        }
    }

}