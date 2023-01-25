using PizzeriaApp.ViewModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaApp.Services
{
    public class DataBase
    {
        private readonly SQLiteAsyncConnection _database;
        public DataBase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Product>().Wait();
            _database.CreateTableAsync<Order>().Wait();
            _database.CreateTableAsync<OrderDetails>().Wait();
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            return await _database.Table<Product>().ToListAsync();
        }

        public async Task<Product> GetProductAsync(int ProductId)
        {
            return await _database.Table<Product>().Where(x => x.Id == ProductId).FirstOrDefaultAsync();
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            if (product.Id > 0)
            {
               await _database.UpdateAsync(product);
            }
            else
            {
                 await _database.InsertAsync(product);
            }
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteProductAsync(int ProductId)
        {
            await _database.DeleteAsync<Product>(ProductId);
            return await Task.FromResult(true);
        }
        public async Task<List<OrderDetails>> GetOrderDetailsAsync()
        {
            return await _database.Table<OrderDetails>().ToListAsync();
        }
        public async Task<List<OrderDetails>> GetOrderDetailsByProductIdAsync(int ProductId)
        {
            return await _database.Table<OrderDetails>()
                .Where(x => x.ProductId == ProductId).ToListAsync();
        }

    }
}
