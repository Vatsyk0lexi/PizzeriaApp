using PizzeriaApp.ViewModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaApp.Services
{
    public class ProductService
    {
        
        public async Task<bool> AddProduct(Product product) { return true; }
        public async Task<Product> GetProductAsync(string productName) { return null; }
        public async Task<IEnumerable< Product>> GetProductsAsync() { return null; }
        public async Task<bool> UpdateProductAsync(Product product) { return true; }
        public async Task<bool> DeleteProductAsync(Product product) { return true; }
    }
}
