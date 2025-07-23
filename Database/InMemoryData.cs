using PoliMarketFunctions.Models;
using System.Collections.Generic;

namespace PoliMarketFunctions.Database
{
    public static class InMemoryData
    {
        public static List<Vendedor> Vendedores { get; set; } = new List<Vendedor>()
        {
            new Vendedor { Id = 1, Nombre = "Ana Gómez", Autorizado = false },
            new Vendedor { Id = 2, Nombre = "Carlos Ruiz", Autorizado = true },
            new Vendedor { Id = 3, Nombre = "Luisa Fernandez", Autorizado = true },
            new Vendedor { Id = 4, Nombre = "Pedro Martinez", Autorizado = false },
            new Vendedor { Id = 5, Nombre = "Sofia Castro", Autorizado = true }
        };

        public static List<Producto> Productos { get; set; } = new List<Producto>()
        {
            new Producto { Id = 101, Nombre = "Laptop Pro", Descripcion = "Laptop de 15 pulgadas, 16GB RAM, 512GB SSD.", Precio = 4500000m, CantidadEnStock = 15 },
            new Producto { Id = 102, Nombre = "Mouse Inalámbrico", Descripcion = "Mouse ergonómico con 6 botones programables.", Precio = 150000m, CantidadEnStock = 50 },
            new Producto { Id = 103, Nombre = "Teclado Mecánico RGB", Descripcion = "Teclado con switches rojos y retroiluminación personalizable.", Precio = 350000m, CantidadEnStock = 25 },
            new Producto { Id = 104, Nombre = "Monitor Curvo 27 pulgadas", Descripcion = "Monitor QHD 144Hz ideal para gaming y diseño.", Precio = 1800000m, CantidadEnStock = 10 },
            new Producto { Id = 105, Nombre = "Webcam HD 1080p", Descripcion = "Webcam con micrófono incorporado y corrección de luz.", Precio = 250000m, CantidadEnStock = 30 },
            new Producto { Id = 106, Nombre = "Silla Gamer Ergonómica", Descripcion = "Silla con soporte lumbar y reposabrazos 4D.", Precio = 950000m, CantidadEnStock = 0 },
            new Producto { Id = 107, Nombre = "Audífonos con Micrófono", Descripcion = "Audífonos circumaurales con cancelación de ruido.", Precio = 450000m, CantidadEnStock = 45 },
            new Producto { Id = 108, Nombre = "Disco Duro SSD 1TB", Descripcion = "Unidad de estado sólido con velocidades de lectura/escritura de hasta 550 MB/s.", Precio = 480000m, CantidadEnStock = 22 }
        };

        public static List<Cliente> Clientes { get; set; } = new List<Cliente>()
        {
            new Cliente { Id = 201, Nombre = "Javier Solis", Empresa = "Constructora El Futuro", Email = "javier.solis@constructora.com" },
            new Cliente { Id = 202, Nombre = "Mariana Correa", Empresa = "Diseños Creativos SAS", Email = "mariana.c@disenos.co" },
            new Cliente { Id = 203, Nombre = "Andrés Bustamante", Empresa = "Soluciones TI", Email = "andres.b@solucionesti.net" }
        };

        public static List<Proveedor> Proveedores { get; set; } = new List<Proveedor>()
        {
            new Proveedor { Id = 301, NombreEmpresa = "TecnoImportaciones SAS", Contacto = "Ricardo Montes" },
            new Proveedor { Id = 302, NombreEmpresa = "Global Supplies", Contacto = "Laura Velez" },
            new Proveedor { Id = 303, NombreEmpresa = "OfficeTech Colombia", Contacto = "David Osorio" }
        };
    }
}