using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPracticas.Capa_de_negocio.Clases
{
    public class Solicitud
    {

        [PrimaryKey, AutoIncrement]
        public int noPractica { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaRealizacion { get; set; }
        public DateTime Hora { get; set; }
        
        public string NombrePractica{ get; set; }
        public string Materia { get; set; }
        public int idArea{ get; set; }
        public string Grupo { get; set; }
        public int noAlumnos { get; set; }
        public int idLaboratorio { get; set; }
        public int idProfesor { get; set; }

    }
}
