using System;
using UnityEngine;

namespace ShopSystem
{
    /// <summary>
    /// An Item class to be used in inventory system
    /// </summary>
    [Serializable]
    public class Item
    {
        /// <summary>
        /// Item's amount
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Item's data
        /// </summary>
        [SerializeField] private ItemData _data;

        /// <summary>
        /// A property accessor for data
        /// </summary>
        public ItemData Data { get => _data; private set => _data = value; }

        /// <summary>
        /// A constructor to create a new object with amount and data
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="data"></param>
        public Item(int amount, ItemData data)
        {
            Amount = amount;
            Data = data;
        }

        /// <summary>
        /// A copy constructor to create a new item object by copying given one
        /// </summary>
        /// <param name="copy"></param>
        public Item(Item copy)
        {
            Amount = copy.Amount;
            Data = copy.Data;
        }

        /// <summary>
        /// A property to get item's sprite
        /// </summary>
        public Sprite Sprite { get => Data.Sprite; }

        /// <summary>
        /// A property to get item's type
        /// </summary>
        public ItemType Type { get => Data.Type; }

        /// <summary>
        /// Overriden ToString() method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Amount}x {Data.Name}";
        }
    }

}