using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InredningOnline
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
        IEnumerable<Product> GetAllProductsInProject(int projectId);

        double GetProductTotalPrice(int productId);
        void SaveProductToDataBase(Product product);

        void DeleteProductInDataBase(int productId);
    }
}
