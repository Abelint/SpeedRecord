﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRecord
{
    public class TestJSON
    {
        public string Name {  get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Price {  get; set; }
        public string[] Sizes {  get; set; }
    }
}
