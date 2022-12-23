namespace CRUD1.Models
{
    public class ModelOrden
    {
        public int ordenID { get; set; }

        public int productoID { get; set; }

        public int clientes_ID { get; set; }

        public DateTime fecha_generacion { get; set; }

        public DateTime fecha_entrega { get; set; }

        public int empleadosID { get; set; }


    }
}
