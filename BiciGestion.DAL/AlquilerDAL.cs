using System.Configuration;
using System.Data;
using BiciGestion.Entity;
using Mapper;
using Microsoft.Data.SqlClient;

namespace BiciGestion.DAL
{
    public class AlquilerDAL
    {
        private string cadena = ConfigurationManager.ConnectionStrings["BiciGestionDB"].ConnectionString;

        public int Insertar(Alquiler alquiler)
        {
            string sql = @"INSERT INTO ALQUILER (ID_TIPO_BICICLETA, DNI_CLIENTE, IMPORTE_TOTAL, FECHA_REGISTRO, FECHA_ALQUILER)
                           VALUES (@idTipo, @dni, @importe, @fechaReg, @fechaAlq);
                           SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection cn = new SqlConnection(cadena))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add("@idTipo", SqlDbType.Int).Value = alquiler.TipoBicicleta.IdTipoBicicleta;
                cmd.Parameters.Add("@dni", SqlDbType.VarChar, 20).Value = alquiler.DniCliente;
                cmd.Parameters.Add("@importe", SqlDbType.Decimal).Value = alquiler.ImporteTotal;
                cmd.Parameters.Add("@fechaReg", SqlDbType.DateTime).Value = alquiler.FechaRegistro;
                cmd.Parameters.Add("@fechaAlq", SqlDbType.DateTime).Value = alquiler.FechaAlquiler;

                cn.Open();
                object id = cmd.ExecuteScalar();
                return id == null ? 0 : Convert.ToInt32(id);
            }
        }

        public List<Alquiler> Listar()
        {
            string sql = @"SELECT a.NUMERO_ALQUILER   AS NumeroAlquiler,
                                  a.ID_TIPO_BICICLETA AS IdTipoBicicleta,
                                  t.DESCRIPCION       AS TipoBicicletaDescripcion,
                                  a.DNI_CLIENTE       AS DniCliente,
                                  a.IMPORTE_TOTAL     AS ImporteTotal,
                                  a.FECHA_REGISTRO    AS FechaRegistro,
                                  a.FECHA_ALQUILER    AS FechaAlquiler
                           FROM ALQUILER a
                           INNER JOIN TIPO_BICICLETA t ON t.ID_TIPO_BICICLETA = a.ID_TIPO_BICICLETA
                           ORDER BY a.NUMERO_ALQUILER";

            DataTable tabla = new DataTable();

            using (SqlConnection cn = new SqlConnection(cadena))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(tabla);
            }

            return 
                
                AlquilerMapper.ToList(tabla);
        }

        public Alquiler GetById(int numeroAlquiler)
        {
            string sql = @"SELECT a.NUMERO_ALQUILER   AS NumeroAlquiler,
                                  a.ID_TIPO_BICICLETA AS IdTipoBicicleta,
                                  t.DESCRIPCION       AS TipoBicicletaDescripcion,
                                  a.DNI_CLIENTE       AS DniCliente,
                                  a.IMPORTE_TOTAL     AS ImporteTotal,
                                  a.FECHA_REGISTRO    AS FechaRegistro,
                                  a.FECHA_ALQUILER    AS FechaAlquiler
                           FROM ALQUILER a
                           INNER JOIN TIPO_BICICLETA t ON t.ID_TIPO_BICICLETA = a.ID_TIPO_BICICLETA
                           WHERE a.NUMERO_ALQUILER = @numero";

            DataTable tabla = new DataTable();

            using (SqlConnection cn = new SqlConnection(cadena))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@numero", SqlDbType.Int).Value = numeroAlquiler;
                da.Fill(tabla);
            }

            if (tabla.Rows.Count == 0)
                return null;

            return AlquilerMapper.ToEntity(tabla.Rows[0]);
        }

        public void Modificar(Alquiler alquiler)
        {
            string sql = @"UPDATE ALQUILER
                           SET IMPORTE_TOTAL = @importe, FECHA_ALQUILER = @fechaAlq
                           WHERE NUMERO_ALQUILER = @numero";

            using (SqlConnection cn = new SqlConnection(cadena))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add("@importe", SqlDbType.Decimal).Value = alquiler.ImporteTotal;
                cmd.Parameters.Add("@fechaAlq", SqlDbType.DateTime).Value = alquiler.FechaAlquiler;
                cmd.Parameters.Add("@numero", SqlDbType.Int).Value = alquiler.NumeroAlquiler;

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int numeroAlquiler)
        {
            string sql = "DELETE FROM ALQUILER WHERE NUMERO_ALQUILER = @numero";

            using (SqlConnection cn = new SqlConnection(cadena))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add("@numero", SqlDbType.Int).Value = numeroAlquiler;

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
