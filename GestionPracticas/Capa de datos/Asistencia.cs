using GestionPracticas.Capa_de_negocio.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPracticas.Capa_de_datos
{
    internal class Asistencia
    {
        //Se instancia la clase de conexion
        SqliteDB ConexionDB = new SqliteDB();

        public Accion InsertarSqlite(Capa_de_negocio.Clases.Asistencia asis)
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
                ConexionDB.ConexionDB().Insert(asis);

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
        public Accion BorrarSqlite(Capa_de_negocio.Clases.Asistencia asis)
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
                ConexionDB.ConexionDB().Delete(asis);

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
        public List<Capa_de_negocio.Clases.Solicitud> ConsultarSolicitudes()
        {
            var query = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Solicitud>();
            List<Capa_de_negocio.Clases.Solicitud> result = query.ToList();
            return result;
        }
        public List<Capa_de_negocio.Clases.Asistencia> ConsultarAsistencias(int noPractica)
        {
            var query = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Asistencia>().Where(v => v.NoPractica == noPractica);
            List<Capa_de_negocio.Clases.Asistencia> result = query.ToList();
            return result;
        }

    }
}
