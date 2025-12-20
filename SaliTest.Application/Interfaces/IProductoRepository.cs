using SaliTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaliTest.Application.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllProductosAsync();
    }
}
