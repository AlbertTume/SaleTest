using System;
using System.Collections.Generic;
using System.Text;

namespace SaliTest.Application.DTOs
{
    public class ProductoDto
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;
        public decimal Description { get; set; }
        public int Quantity { get; set; }
    }
}
