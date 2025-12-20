using System;
using System.Collections.Generic;
using System.Text;

namespace SaliTest.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
