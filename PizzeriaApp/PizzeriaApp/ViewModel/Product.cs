using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzeriaApp.ViewModel
{
    public class Product
    {
        [PrimaryKey,AutoIncrement] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
