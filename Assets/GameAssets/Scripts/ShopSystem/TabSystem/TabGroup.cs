using UnityEngine;
using System.Collections.Generic;

namespace ShopSystem
{
    public class TabGroup : MonoBehaviour
    {
        private List<Tab> _tabs;

        [SerializeField] private Tab _tabSelectedAsDefault;
        [SerializeField] private Transform _tabContainer;
        [SerializeField] private GameObject _productUIScrollAreaPrefab;
        [SerializeField] private Transform _productUIScrollAreaContainer;

        private void Start()
        {
            InitializeTabs();

            _tabSelectedAsDefault.Select();
        }

        private void InitializeTabs()
        {
            _tabs = new List<Tab>();

            foreach (Transform childTab in _tabContainer)
            {
                _tabs.Add(childTab.GetComponent<Tab>());
            }
        }

        public void ResetTabs()
        {
            foreach (Tab tab in _tabs)
            {
                tab.Deselect();
            }
        }
    }

}