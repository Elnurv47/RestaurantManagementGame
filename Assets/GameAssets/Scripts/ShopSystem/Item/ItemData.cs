using System;
using UnityEngine;

namespace ShopSystem
{
    [Serializable]
    public struct ItemData
    {
        /// <summary>
        /// An Id of the Item
        /// </summary>
        [SerializeField] private int _id;
        public int Id { get => _id; set => _id = value; }

        /// <summary>
        /// A name of the item
        /// </summary>
        [SerializeField] private string _name;
        public string Name { get => _name; set => _name = value; }

        /// <summary>
        /// A description of the item
        /// </summary>
        [SerializeField] private string _description;
        public string Description { get => _description; set => _description = value; }

        /// <summary>
        /// A sprite of the item
        /// </summary>
        [SerializeField] private Sprite _sprite;
        public Sprite Sprite { get => _sprite; set => _sprite = value; }

        /// <summary>
        /// A type of the item
        /// </summary>
        [SerializeField] private ItemType _type;
        public ItemType Type { get => _type; set => _type = value; }

        /// <summary>
        /// A constructor to create a new item data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="sprite"></param>
        /// <param name="type"></param>
        public ItemData(int id, string name, string description, Sprite sprite, ItemType type)
        {
            _id = id;
            _name = name;
            _description = description;
            _sprite = sprite;
            _type = type;
        }

        /// <summary>
        /// A static property to create a new ItemData object with default values
        /// </summary>
        public static ItemData Empty { get; } = new ItemData(0, "", "", null, ItemType.Empty);
    }

}