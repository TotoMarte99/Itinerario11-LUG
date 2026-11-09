namespace BiciGestion.Entity
{
    public class TipoBicicleta : EntidadBase
    {
        public int IdTipoBicicleta { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public override string ObtenerDescripcion()
        {
            return Descripcion;
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
