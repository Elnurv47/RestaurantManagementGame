namespace ShopSystem
{
    /// <summary>
    /// An interface for the inventories to implement
    /// </summary>
    public interface IInventory
    {
        /// <summary>
        /// Method to add new item to the inventory
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item);
        /// <summary>
        /// Method to remove an item from the inventory
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem(Item item);
    }

}