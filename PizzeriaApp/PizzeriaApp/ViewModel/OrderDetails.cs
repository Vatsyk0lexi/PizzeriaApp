using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzeriaApp.ViewModel
{
    public class OrderDetails
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int OrderId { get; set; }
        [Indexed]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
