﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
