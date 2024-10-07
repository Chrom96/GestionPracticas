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
    internal class Laboratorio
    {

        //Crea nuevo objeto y lo rellena con la informacion de la capa 1 para enviarlo a la capa de datos
        Capa_de_datos.Laboratorio laboDatos= new Capa_de_datos.Laboratorio();
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

            var labo = new Clases.Laboratorio()
            {
                Nombre = nombre,
            };
            if (laboDatos.ConsultarPorNombre(nombre) != null)
            {
                accion.Realizada = false;
                accion.Msg = "Ya existe un laboratorio con este nombre";
                return accion;
            }
            accion = laboDatos.InsertarSqlite(labo);
            return accion;
        }


        public bool ExisteLaboratorio(string id)
        {
            bool existe = false;
            Clases.Laboratorio laboAux = laboDatos.ConsultarLaboratorio(Convert.ToInt32(id));
            if (laboAux != null)
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
            var labo = laboDatos.ConsultarLaboratorio(Convert.ToInt32(id));

            accion = laboDatos.BorrarSqlite(labo);
        }

        public List<Clases.Laboratorio> BuscarLaboratoriosLista()
        {
            List<Clases.Laboratorio> ListaLabo = new List<Clases.Laboratorio>();

            foreach (var labo in laboDatos.ConsultarLaboratorios())
            {
                ListaLabo.Add(labo);
            }

            return ListaLabo;
        }

  

    }

}

