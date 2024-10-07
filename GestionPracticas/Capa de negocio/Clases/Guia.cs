using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPracticas.Capa_de_negocio.Clases
{
    internal class Guia
    {
        [PrimaryKey, AutoIncrement]
        public int idGuia { get; set; }
        public string Departamento { get; set; }
        public int NoPractica { get; set; }
        public int Unidad { get; set; }
        public string PersonaElabora { get; set; }
        public string PersonaRevisa { get; set; }
        public string PersonaAutoriza { get; set; }
        public string Objetivo { get; set; }
        public string Introduccion { get; set; }
        public string Material { get; set; }
        public string CondicionesSeguridad { get; set; }
        public string Peligros { get; set; }
        public string RespuestaContingencia { get; set; }
        public string DesarrolloExperimental { get; set; }
        public string Cuestionario { get; set; }
        public string TipoResiduos { get; set; }
        public string TratamientoResiduos { get; set; }
        public string DisposicionResiduos { get; set; }
        public string ActividadesComplementarias { get; set; }
        public string Bibliografia { get; set; }

    }
}
