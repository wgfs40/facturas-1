namespace Entidades
{
    public class facturadetalle
    {
        public int ID { get; set; }
        public int PRODUCTOID { get; set; }
        public int FACTURAID { get; set; }
        public int CANTIDAD { get; set; }
        public float PRECIO { get; set; }
        public EstadoEntidad EstadoDetalle { get; set; }
        public producto Producto { get; set; }

        public facturadetalle() => EstadoDetalle = EstadoEntidad.Sin_Cambio;
    }
}
