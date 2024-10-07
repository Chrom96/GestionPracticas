using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPracticas.Capa_de_negocio.Clases
{
    public class Asistencia
    {

        [PrimaryKey, AutoIncrement]
        public int idAsistencia { get; set; }
        public int NoPractica { get; set; }
        public int NoAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public DateTime FechaAsistencia { get; set; }
        public DateTime HoraAsistencia { get; set; }

    }
}
