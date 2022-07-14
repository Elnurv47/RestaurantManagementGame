using System.Collections.Generic;

namespace ShopSystem
{
    /// <summary>
    /// An interface to represent product fetchers
    /// </summary>
    public interface IProductFetcher
    {
        /// <summary>
        /// Method to fetch product
        /// </summary>
        /// <returns></returns>
        List<Product> Fetch();
    }

}