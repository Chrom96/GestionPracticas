using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPracticas.Capa_de_negocio.Clases
{
    internal class Departamento
    {
            [PrimaryKey, AutoIncrement]
            public int idDepartamento { get; set; }
            public String Nombre { get; set; }
    }
}
