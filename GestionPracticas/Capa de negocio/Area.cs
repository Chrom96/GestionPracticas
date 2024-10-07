using GestionPracticas.Capa_de_negocio.Clases;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPracticas.Capa_de_negocio
{
    internal class Area
    {

        //Crea nuevo objeto y lo rellena con la informacion de la capa 1 para enviarlo a la capa de datos
        Capa_de_datos.Area areaDatos= new Capa_de_datos.Area();
        public Accion Crear(String nombre)
        {
            //Se crea informacion de la accion vacia
            var accion = new Accion()
            {
                Realizada = false,
                Msg = ""
            };

            // convertir a string de regreso 12:00 am
            // date.ToString("hh:mm tt", CultureInfo.CurrentCulture);

            var area = new Clases.Area()
            {
                Nombre = nombre,
            };
            if (areaDatos.ConsultarPorNombre(nombre) != null)
            {
                accion.Realizada = false;
                accion.Msg = "Ya existe un area con este nombre";
                return accion;
            }
            accion = areaDatos.InsertarSqlite(area);
            return accion;
        }


        public bool ExisteArea(string id)
        {
            bool existe = false;
            Clases.Area areaAux = areaDatos.ConsultarArea(Convert.ToInt32(id));
            if (areaAux != null)
            {
                existe = true;
            }
            return existe;
        }

        public void Borrar(string id)
        {
            //Se crea informacion de la accion vacia
            var accion = new Clases.Accion()
            {
                Realizada = false,
                Msg = ""
            };
            var area = areaDatos.ConsultarArea(Convert.ToInt32(id));

            accion = areaDatos.BorrarSqlite(area);
        }

        public List<Clases.Area> BuscarAreasLista()
        {
            List<Clases.Area> ListaArea = new List<Clases.Area>();

            foreach (var area in areaDatos.ConsultarAreas())
            {
                ListaArea.Add(area);
            }

            return ListaArea;
        }

  

    }

}

