using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BiciGestion.Entity;

namespace Mapper
{
    public static class TipoBicicletaMapper
    {
        public static TipoBicicleta ToEntity(DataRow row) => new TipoBicicleta
        {
            IdTipoBicicleta = Convert.ToInt32(row["IdTipoBicicleta"]),
            Descripcion = row["Descripcion"].ToString() ?? string.Empty
        };

        public static List<TipoBicicleta> ToList(DataTable table) => table.Rows.Cast<DataRow>().Select(ToEntity).ToList();
    }
}
