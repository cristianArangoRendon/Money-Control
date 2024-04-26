using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl.Core.DTOs.Incomin
{
    public class CreateIncomeDTO
    {
        
        public string description { get; set; }
        public decimal amount { get; set; }
        public int idUser { get; set; }
        public int idFrequency { get; set; }
        
    }
}
