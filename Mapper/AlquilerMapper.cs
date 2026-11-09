using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BiciGestion.Entity;

namespace Mapper
{
    public static class AlquilerMapper
    {
        public static Alquiler ToEntity(DataRow row) => new Alquiler
        {
            NumeroAlquiler = Convert.ToInt32(row["NumeroAlquiler"]),
            TipoBicicleta = new TipoBicicleta
            {
                IdTipoBicicleta = Convert.ToInt32(row["IdTipoBicicleta"]),
                Descripcion = row["TipoBicicletaDescripcion"].ToString() ?? string.Empty
            },
            DniCliente = row["DniCliente"].ToString() ?? string.Empty,
            ImporteTotal = Convert.ToDecimal(row["ImporteTotal"]),
            FechaRegistro = Convert.ToDateTime(row["FechaRegistro"]),
            FechaAlquiler = Convert.ToDateTime(row["FechaAlquiler"])
        };

        public static List<Alquiler> ToList(DataTable table) => table.Rows.Cast<DataRow>().Select(ToEntity).ToList();

    }
}
