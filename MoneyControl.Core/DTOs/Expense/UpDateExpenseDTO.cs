using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl.Core.DTOs.Expense
{
    public class UpDateExpenseDTO
    {
        public int id { get; set; }
        public string description { get; set; }
        public decimal amount { get; set; }
        public int idFrequency { get; set; }
        public int idUser { get; set; }
    }
}
