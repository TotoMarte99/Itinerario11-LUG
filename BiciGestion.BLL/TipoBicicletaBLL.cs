using BiciGestion.DAL;
using BiciGestion.Entity;

namespace BiciGestion.BLL
{
    public class TipoBicicletaBLL
    {
        private TipoBicicletaDAL dal = new TipoBicicletaDAL();

        public List<TipoBicicleta> Listar()
        {
            try
            {
                return dal.Listar();
            }
            catch (Exception ex)
            {
                throw new BusinessException("Ocurrio un error al obtener los tipos de bicicleta.", ex);
            }
        }
    }
}
