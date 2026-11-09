using System.Transactions;
using BiciGestion.DAL;
using BiciGestion.Entity;

namespace BiciGestion.BLL
{
    public class AlquilerBLL
    {
        private AlquilerDAL dal = new AlquilerDAL();
        private List<Alquiler> borrador = new List<Alquiler>();

        public int Registrar(Alquiler alquiler)
        {
            ValidarAlquiler(alquiler);

            alquiler.FechaRegistro = DateTime.Now;

            try
            {
                return dal.Insertar(alquiler);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Ocurrio un error al registrar el alquiler.", ex);
            }
        }

        public void AgregarAlBorrador(Alquiler alquiler)
        {
            ValidarAlquiler(alquiler);

            alquiler.FechaRegistro = DateTime.Now;
            borrador.Add(alquiler);
        }

        public void QuitarDelBorrador(Alquiler alquiler)
        {
            borrador.Remove(alquiler);
        }

        public void LimpiarBorrador()
        {
            borrador.Clear();
        }

        public List<Alquiler> VerBorrador()
        {
            return new List<Alquiler>(borrador);
        }

        public void ConfirmarBorrador()
        {
            if (borrador.Count == 0)
                throw new BusinessException("El borrador no tiene alquileres para confirmar.");

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (Alquiler alquiler in borrador)
                        dal.Insertar(alquiler);

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new BusinessException("Ocurrio un error al confirmar el borrador. No se guardo ningun alquiler.", ex);
            }

            borrador.Clear();
        }

        public List<Alquiler> Listar()
        {
            try
            {
                return dal.Listar();
            }
            catch (Exception ex)
            {
                throw new BusinessException("Ocurrio un error al obtener los alquileres.", ex);
            }
        }

        public Alquiler GetById(int numeroAlquiler)
        {
            ValidarId(numeroAlquiler);

            try
            {
                return dal.GetById(numeroAlquiler);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Ocurrio un error al consultar el alquiler.", ex);
            }
        }

        public void Modificar(int numeroAlquiler, decimal nuevoImporte, DateTime nuevaFechaAlquiler)
        {
            ValidarId(numeroAlquiler);

            Alquiler existente = ObtenerExistente(numeroAlquiler);

            ValidarImporte(nuevoImporte);
            ValidarFechaAlquiler(nuevaFechaAlquiler);

            existente.ImporteTotal = nuevoImporte;
            existente.FechaAlquiler = nuevaFechaAlquiler;

            try
            {
                dal.Modificar(existente);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Ocurrio un error al modificar el alquiler.", ex);
            }
        }

        public void Eliminar(int numeroAlquiler)
        {
            ValidarId(numeroAlquiler);

            ObtenerExistente(numeroAlquiler);

            try
            {
                dal.Eliminar(numeroAlquiler);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Ocurrio un error al eliminar el alquiler.", ex);
            }
        }

        private void ValidarAlquiler(Alquiler alquiler)
        {
            if (alquiler == null)
                throw new BusinessException("El alquiler no puede ser nulo.");

            ValidarTipoBicicleta(alquiler.TipoBicicleta.IdTipoBicicleta);
            ValidarDni(alquiler.DniCliente);
            ValidarImporte(alquiler.ImporteTotal);
            ValidarFechaAlquiler(alquiler.FechaAlquiler);
        }

        private Alquiler ObtenerExistente(int numeroAlquiler)
        {
            Alquiler existente = dal.GetById(numeroAlquiler);

            if (existente == null)
                throw new BusinessException("No existe un alquiler con el ID " + numeroAlquiler + ".");

            return existente;
        }

        private void ValidarId(int id)
        {
            if (id <= 0)
                throw new BusinessException("El ID ingresado debe ser un numero entero mayor a cero.");
        }

        private void ValidarDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new BusinessException("El DNI del cliente no puede estar vacio.");

            if (dni.Trim().Length <= 5)
                throw new BusinessException("El DNI del cliente debe tener mas de 5 caracteres.");
        }

        private void ValidarImporte(decimal importe)
        {
            if (importe <= 0)
                throw new BusinessException("El importe total debe ser mayor a cero.");
        }

        private void ValidarFechaAlquiler(DateTime fechaAlquiler)
        {
            if (fechaAlquiler.Date < DateTime.Now.Date)
                throw new BusinessException("La fecha del alquiler no puede ser menor a la fecha actual.");
        }

        private void ValidarTipoBicicleta(int idTipoBicicleta)
        {
            if (idTipoBicicleta <= 0)
                throw new BusinessException("Debe seleccionar un tipo de bicicleta.");
        }
    }
}
