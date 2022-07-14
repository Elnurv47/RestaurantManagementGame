using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GridSystem
{
    public class Node : MonoBehaviour
    {
        private bool _isUsable;
        public bool IsUsable { get => _isUsable; }

        private GridIndex _gridIndex;
        public GridIndex GridIndex { get => _gridIndex; set => _gridIndex = value; }

        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void Start()
        {
            ToggleVisualBasedOnUsableness();
        }

        public void SetUsable(bool isUsable)
        {
            _isUsable = isUsable;
            ToggleVisualBasedOnUsableness();
        }

        private void ToggleVisualBasedOnUsableness()
        {
            _renderer.enabled = _isUsable;
        }

        public override string ToString()
        {
            return GridIndex.X + ", " + GridIndex.Z;
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}