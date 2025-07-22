using PoliMarketFunctions.Models;
using System.Collections.Generic;

namespace PoliMarketFunctions.Database
{
    public static class InMemoryData
    {
        public static List<Vendedor> Vendedores { get; set; } = new List<Vendedor>()
        {
            new Vendedor { Id = 1, Nombre = "Ana Gómez", Autorizado = false },
            new Vendedor { Id = 2, Nombre = "Carlos Ruiz", Autorizado = true }
        };

        public static List<Producto> Productos { get; set; } = new List<Producto>()
        {
            new Producto { Id = 101, Nombre = "Laptop Pro", CantidadEnStock = 15 },
            new Producto { Id = 102, Nombre = "Mouse Inalámbrico", CantidadEnStock = 50 }
        };
    }
}