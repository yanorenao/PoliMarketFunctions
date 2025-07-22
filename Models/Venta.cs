using System.Collections.Generic;

namespace PoliMarketFunctions.Models
{
    public class Venta
    {
        public int VentaId { get; set; }
        public int VendedorId { get; set; }
        public string Cliente { get; set; }
        public List<int> ProductosIds { get; set; }
    }
}