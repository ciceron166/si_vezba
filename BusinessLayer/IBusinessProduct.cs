using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBusinessProduct
    {
        bool Insert(Product product);
        Task<List<Product>> GetAll();
        List<Product>GetInterval(decimal price1, decimal price2);
    }
}
