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
    internal class Profesor
    {

        //Crea nuevo objeto y lo rellena con la informacion de la capa 1 para enviarlo a la capa de datos
        Capa_de_datos.Profesor profDatos= new Capa_de_datos.Profesor();
        public Accion Crear(String nombre, int idarea)
        {
            //Se crea informacion de la accion vacia
            var accion = new Accion()
            {
                Realizada = false,
                Msg = ""
            };

            // convertir a string de regreso 12:00 am
            // date.ToString("hh:mm tt", CultureInfo.CurrentCulture);

            var profe = new Clases.Profesor()
            {
                Nombre = nombre,
                idArea = idarea,
            };
            if (profDatos.ConsultarProfeNombre(nombre) != null)
            {
                accion.Realizada = false;
                accion.Msg = "Ya existe un docente con este nombre";
                return accion;
            }
            accion = profDatos.InsertarSqlite(profe);
            return accion;
        }


        public bool ExisteProfesor(string idProfe)
        {
            bool existe = false;
            Clases.Profesor profAux = profDatos.ConsultarProfe(Convert.ToInt32(idProfe));
            if (profAux != null)
            {
                existe = true;
            }
            return existe;
        }

        public void Borrar(string idProfe)
        {
            //Se crea informacion de la accion vacia
            var accion = new Clases.Accion()
            {
                Realizada = false,
                Msg = ""
            };
            var profe = profDatos.ConsultarProfe(Convert.ToInt32(idProfe));

            accion = profDatos.BorrarSqlite(profe);
        }
        public DataTable BuscarProfesoresLista(string TextoABuscar)
        {
            return profDatos.ConsultarProfesoresFitlrado(TextoABuscar);
        }
        /*
        public List<Clases.Profesor> BuscarProfesoresLista(string TextoABuscar)
        {
            List<Clases.Profesor> ListaPRofes = new List<Clases.Profesor>();

            foreach (var profe in profDatos.ConsultarProfesoresFitlrado(TextoABuscar))
            {
                ListaPRofes.Add(profe);
            }

            return ListaPRofes;
        }
        */
        public List<Clases.Profesor> BuscarProfesoresArea(int idarea)
        {
            List<Clases.Profesor> ListaPRofes = new List<Clases.Profesor>();

            foreach (var profe in profDatos.ConsultarProfesoresArea(idarea))
            {
                ListaPRofes.Add(profe);
            }

            return ListaPRofes;
        }


    }

}

