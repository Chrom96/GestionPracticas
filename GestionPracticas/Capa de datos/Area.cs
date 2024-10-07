using GestionPracticas.Capa_de_negocio.Clases;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPracticas.Capa_de_datos
{
    internal class Area
    {
        //Se instancia la clase de conexion
        SqliteDB ConexionDB = new SqliteDB();

        //Toma el objeto de la capa 2 y lo registra en SQLite
        public Accion InsertarSqlite(Capa_de_negocio.Clases.Area area)
        {

            //Se crea informacion de la accion vacia
            var accion = new Accion()
            {
                Realizada = false,
                Msg = ""
            };
            try
            {
                //Insert Sqlite
                ConexionDB.ConexionDB().Insert(area);

                //Se coloca estado a la accion en curso
                accion.Realizada = true;
            }
            catch (Exception e)
            {
                //  Block of code to handle errors
                //Se coloca estado a la accion en curso
                accion.Realizada = false;
                accion.Msg = e.Message;
            }

            

            return accion;
        }

        public Capa_de_negocio.Clases.Area ConsultarArea(int id)
        {
            Capa_de_negocio.Clases.Area area = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Area>().Where(x => x.idArea == id).FirstOrDefault();
            return area;
        }

        public Accion BorrarSqlite(Capa_de_negocio.Clases.Area area)
        {

            //Se crea informacion de la accion vacia
            var accion = new Accion()
            {
                Realizada = false,
                Msg = ""
            };
            try
            {
                //Insert Sqlite
                ConexionDB.ConexionDB().Delete(area);
                //Se coloca estado a la accion en curso
                accion.Realizada = true;
            }
            catch (Exception e)
            {
                //  Block of code to handle errors
                //Se coloca estado a la accion en curso
                accion.Realizada = false;
                accion.Msg = e.Message;
            }



            return accion;
        }

        public Capa_de_negocio.Clases.Area ConsultarPorNombre(string nombre)
        {
            Capa_de_negocio.Clases.Area area = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Area>().Where(x => x.Nombre.ToLower().Equals(nombre.ToLower())).FirstOrDefault();
            return area;
        }
        public List<Capa_de_negocio.Clases.Area> ConsultarAreas ()
        {
            var query = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Area>().Where(x => x.Nombre.ToLower().Contains("")).ToList(); ;
            List<Capa_de_negocio.Clases.Area> result = query.ToList();
            return result;
        }
    }
}
