using System.Collections.Generic;

namespace ShopSystem
{
    /// <summary>
    /// A class which is to fetch all products from ProductContainer typed object in the scene
    /// </summary>
    public class ProductFetcherFromContainerObject : IProductFetcher
    {
        /// <summary>
        /// A reference to ProductContainer in the scene
        /// </summary>
        private ProductContainer _productContainer;

        /// <summary>
        /// A constructor to set ProductContainer object
        /// </summary>
        /// <param name="productContainer"></param>
        public ProductFetcherFromContainerObject(ProductContainer productContainer)
        {
            _productContainer = productContainer;
        }

        /// <summary>
        /// A method to fetch all products from references container object
        /// </summary>
        /// <returns></returns>
        public List<Product> Fetch()
        {
            return _productContainer.Products;
        }
    }

}