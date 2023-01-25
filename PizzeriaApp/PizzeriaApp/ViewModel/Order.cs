using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzeriaApp.ViewModel
{
    public class Order
    {
        [PrimaryKey,AutoIncrement] 
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }

    }
}
