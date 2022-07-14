using UnityEngine;
using System.Collections.Generic;

namespace ShopSystem
{
    /// <summary>
    /// A class to control tabs
    /// </summary>
    public class TabController : MonoBehaviour
    {
        /// <summary>
        /// Tab list
        /// </summary>
        private List<Tab> _tabs;

        /// <summary>
        /// Default selected tab
        /// </summary>
        [SerializeField] private Tab _tabSelectedAsDefault;
        /// <summary>
        /// A parent object which tabs are child of
        /// </summary>
        [SerializeField] private Transform _tabContainer;

        private void Start()
        {
            InitializeTabs();

            _tabSelectedAsDefault.Select();
        }

        /// <summary>
        /// A method to add all tabs to the tab list
        /// </summary>
        private void InitializeTabs()
        {
            _tabs = new List<Tab>();

            foreach (Transform childTab in _tabContainer)
            {
                _tabs.Add(childTab.GetComponent<Tab>());
            }
        }

        /// <summary>
        /// A method to deselect all tabs
        /// </summary>
        public void DeselectTabs()
        {
            foreach (Tab tab in _tabs)
            {
                tab.Deselect();
            }
        }
    }

}