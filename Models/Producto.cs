namespace PoliMarketFunctions.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; } // Nuevo
        public decimal Precio { get; set; }      // Nuevo
        public int CantidadEnStock { get; set; }
    }
}