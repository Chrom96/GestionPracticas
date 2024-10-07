using GestionPracticas.Capa_de_negocio.Clases;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GestionPracticas.Capa_de_negocio.Asistencia;

namespace GestionPracticas.Capa_de_negocio
{
    internal class Alumno
    {

        //Crea nuevo objeto y lo rellena con la informacion de la capa 1 para enviarlo a la capa de datos
        Capa_de_datos.Alumno alumnoDatos= new Capa_de_datos.Alumno();
        public Accion Crear(string nocontrol, String nombre, int idarea)
        {
            //Se crea informacion de la accion vacia
            var accion = new Accion()
            {
                Realizada = false,
                Msg = ""
            };

            // convertir a string de regreso 12:00 am
            // date.ToString("hh:mm tt", CultureInfo.CurrentCulture);

            var alumno = new Clases.Alumno()
            {
                Nombre = nombre,
                NoControl = Convert.ToInt32(nocontrol),
                idArea = idarea
            };

            if (alumnoDatos.ConsultarAlumno(Convert.ToInt32(nocontrol)) != null)
            {
                accion.Realizada = false;
                accion.Msg = "noControl no es valido";
                return accion;
            }

            accion = alumnoDatos.InsertarSqlite(alumno);
            return accion;
        }


        public bool ExisteAlumno(string nocontrol)
        {
            bool existe = false;
            int noControl = 0;
            if(!int.TryParse(nocontrol,out noControl)){
                return true;
            }
            Clases.Alumno alumnoAux = alumnoDatos.ConsultarAlumno(noControl);
            if (alumnoAux != null)
            {
                existe = true;
            }
            return existe;
        }
        public string ConsultarNombre(string nocontrol)
        {
            string Nombre = "";
            Clases.Alumno alumnoAux = alumnoDatos.ConsultarAlumno(Convert.ToInt32(nocontrol));
            if (alumnoAux != null)
            {
                Nombre = alumnoAux.Nombre;
            }
            return Nombre;
        }

        public void Borrar(string nocontrol)
        {
            //Se crea informacion de la accion vacia
            var accion = new Clases.Accion()
            {
                Realizada = false,
                Msg = ""
            };
            var alumno = alumnoDatos.ConsultarAlumno(Convert.ToInt32(nocontrol));

            accion = alumnoDatos.BorrarSqlite(alumno);
        }
        public DataTable BuscarAlumnosTable(string TextoABuscar)
        {
            return alumnoDatos.ConsultarAlumnosFitlradoTable(TextoABuscar);
        }
        public List<Clases.Alumno> BuscarAlumnosLista(string TextoABuscar)
        {
            List<Clases.Alumno> ListaAlumnos = new List<Clases.Alumno>();

            foreach (var alumno in alumnoDatos.ConsultarAlumnosFitlrado(TextoABuscar))
            {
                ListaAlumnos.Add(alumno);
            }

            return ListaAlumnos;
        }

  

    }

}

