namespace BiciGestion.Entity
{
    public class Alquiler : EntidadBase
    {
        public int NumeroAlquiler { get; set; }

        public TipoBicicleta TipoBicicleta { get; set; } = new TipoBicicleta();
        public string DniCliente { get; set; } = string.Empty;
        public decimal ImporteTotal { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaAlquiler { get; set; }

        public override string ObtenerDescripcion()
        {
            return $"Alquiler #{NumeroAlquiler} - {TipoBicicleta.Descripcion} - DNI {DniCliente} - ${ImporteTotal:N2}";
        }
    }
}
