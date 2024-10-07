using GestionPracticas.Capa_de_negocio.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPracticas.Capa_de_negocio
{
    internal class Departamento
    {
        //Crea nuevo objeto y lo rellena con la informacion de la capa 1 para enviarlo a la capa de datos
        Capa_de_datos.Departamento depaDatos = new Capa_de_datos.Departamento();
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

            var depa = new Clases.Departamento()
            {
                Nombre = nombre,
            };
            if (depaDatos.ConsultarPorNombre(nombre) != null)
            {
                accion.Realizada = false;
                accion.Msg = "Ya existe un departamento con este nombre";
                return accion;
            }
            accion = depaDatos.InsertarSqlite(depa);
            return accion;
        }


        public bool ExisteDepa(string id)
        {
            bool existe = false;
            Clases.Departamento depaAux = depaDatos.ConsultarDepa(Convert.ToInt32(id));
            if (depaAux != null)
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
            var depa = depaDatos.ConsultarDepa(Convert.ToInt32(id));

            accion = depaDatos.BorrarSqlite(depa);
        }

        public List<Clases.Departamento> BuscarDepaListas()
        {
            List<Clases.Departamento> ListaDepa = new List<Clases.Departamento>();

            foreach (var depa in depaDatos.ConsultaDepartamentos())
            {
                ListaDepa.Add(depa);
            }

            return ListaDepa;
        }


    }
}
