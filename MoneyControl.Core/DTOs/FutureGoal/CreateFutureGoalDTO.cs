﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl.Core.DTOs.FutureGoal
{
    public class CreateFutureGoalDTO
    {
        public string description { get; set; }
        public decimal approximateValue { get; set; }
        public int daysToPurchase { get; set; }
        public int idUser { get; set; }
    }
}
