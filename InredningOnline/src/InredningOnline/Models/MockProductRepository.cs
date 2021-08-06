using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InredningOnline
{
    class MockProductRepository : IProductRepository
    {
        // This collection is used by the unit tests.
        public IEnumerable<Product> AllProducts =>
            new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    ProductName = "Matta",
                    ProductNuberOfUnits = 1,
                    ProductUnit = "st",
                    ProductUnitPrice = 200,
                    ProductTotalPrice = 200,
                    ProductInfoLink = "",
                    ProjectId = 1
                },

                new Product
                {
                    ProductId = 2,
                    ProductName = "Gardintyg",
                    ProductNuberOfUnits = 10,
                    ProductUnit = "meter",
                    ProductUnitPrice = 20,
                    ProductTotalPrice = 200,
                    ProductInfoLink = "",
                    ProjectId = 1
                },

                new Product
                {
                    ProductId = 3,
                    ProductName = "Målarfärg",
                    ProductNuberOfUnits = 40,
                    ProductUnit = "liter",
                    ProductUnitPrice = 30,
                    ProductTotalPrice = 1200,
                    ProductInfoLink = "",
                    ProjectId = 2
                },

                new Product
                {
                    ProductId = 4,
                    ProductName = "Tapet",
                    ProductNuberOfUnits = 20,
                    ProductUnit = "rullar",
                    ProductUnitPrice = 50,
                    ProductTotalPrice = 1000,
                    ProductInfoLink = "",
                    ProjectId = 2
                }
            };

        public void DeleteProductInDataBase(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProductsInProject(int projectId)
        {
            throw new NotImplementedException();
        }

        public double GetProductTotalPrice(int productId)
        {
            // Retrieves the specific product from database.
            var productFromDb = AllProducts.FirstOrDefault(p => p.ProductId == productId);

            // Calculates the total price of the product and stores is in the field for total price.
            productFromDb.ProductTotalPrice = productFromDb.ProductUnitPrice * productFromDb.ProductNuberOfUnits;            

            return productFromDb.ProductTotalPrice;
        }       

        public void SaveProductToDataBase(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
