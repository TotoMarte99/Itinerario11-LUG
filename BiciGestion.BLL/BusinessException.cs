namespace BiciGestion.BLL
{
    // La uso para diferenciar los errores de reglas de negocio de los errores tecnicos
    public class BusinessException : Exception
    {
        public BusinessException(string mensaje) : base(mensaje)
        {
        }

        public BusinessException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
    }
}
