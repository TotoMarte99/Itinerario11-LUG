using System.Configuration;
using System.Data;
using BiciGestion.Entity;
using Mapper;
using Microsoft.Data.SqlClient;

namespace BiciGestion.DAL
{
    public class TipoBicicletaDAL
    {
        private string cadena = ConfigurationManager.ConnectionStrings["BiciGestionDB"].ConnectionString;

        public List<TipoBicicleta> Listar()
        {
            string sql = @"SELECT ID_TIPO_BICICLETA AS IdTipoBicicleta,
                                  DESCRIPCION       AS Descripcion
                           FROM TIPO_BICICLETA
                           ORDER BY DESCRIPCION";

            DataTable tabla = new DataTable();

            using (SqlConnection cn = new SqlConnection(cadena))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(tabla);
            }

            return TipoBicicletaMapper.ToList(tabla);
        }
    }
}
