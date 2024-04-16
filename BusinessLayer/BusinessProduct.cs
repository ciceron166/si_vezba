using DataLayer;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessProduct : IBusinessProduct
    {
        private readonly IProductRepository _productRepository;

        public BusinessProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _productRepository.GetAll();
            if ( products.Count > 0)
            {
                return products;
            }
            return new List<Product>();

        }

        public List<Product> GetInterval(decimal price1, decimal price2)
        {
            return new List<Product>();
        }

        public bool Insert(Product product)
        {
            if (string.IsNullOrEmpty(product.Name) || string.IsNullOrEmpty(product.Description)
                || product.Price == 0)
                return false;
           return _productRepository.Insert(product);
        }
    }
}
