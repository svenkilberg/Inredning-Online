using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InredningOnline.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Product> AllProducts
        {
            get
            {
                return _appDbContext.Products;
            }
        }

        public IEnumerable<Product> GetAllProductsInProject(int projectId)
        {
            // Retrieves all products from database that have a specific project id.
            return _appDbContext.Products.Where(p => p.ProjectId == projectId);
        }

        public double GetProductTotalPrice(int productId)
        {
            // Retrieves the specific product from database.
            var productFromDb = _appDbContext.Products.FirstOrDefault(p => p.ProductId == productId);

            // Calculates the total price of the product and stores is in the field for total price.
            productFromDb.ProductTotalPrice = productFromDb.ProductUnitPrice * productFromDb.ProductNuberOfUnits;

            // Send the updated product back to database.
            SaveProductToDataBase(productFromDb);            

            return productFromDb.ProductTotalPrice;
        }

        public void SaveProductToDataBase(Product product)
        {
            // Save a specific product to data base.

            // Check to see if the id of the product passed to the method is allready in the data base.
            if (_appDbContext.Products.AsNoTracking().FirstOrDefault(p => p.ProductId == product.ProductId) != null)
            {
                _appDbContext.Update(product); // If the id is already present, update the existing product.
            }
            else
            {
                _appDbContext.Products.Add(product); // If id is not present, add the product as an new entry to database.
            }

            _appDbContext.SaveChanges(); // Store the changes to database.
        }

        public void DeleteProductInDataBase(int productId)
        {
            // Retrieve the product from database.
            var productInDatabase = _appDbContext.Products.FirstOrDefault(p => p.ProductId == productId);

            // Remove the product from database.
            _appDbContext.Products.Remove(productInDatabase);

            _appDbContext.SaveChanges(); // Store the changes to database.
        }
    }
}
