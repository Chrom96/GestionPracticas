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
    internal class Solicitud
    {
        //Se instancia la clase de conexion
        SqliteDB ConexionDB = new SqliteDB();

        //Toma el objeto de la capa 2 y lo registra en SQLite
        public Accion InsertarSqlite(Capa_de_negocio.Clases.Solicitud sol)
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
                ConexionDB.ConexionDB().Insert(sol);

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

        public Capa_de_negocio.Clases.Solicitud ConsultarSolicitud(int nopractica)
        {
            Capa_de_negocio.Clases.Solicitud sol = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Solicitud>().Where(x => x.noPractica == nopractica).FirstOrDefault();
            return sol;
        }

        public Accion BorrarSqlite(Capa_de_negocio.Clases.Solicitud solicitud)
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
                ConexionDB.ConexionDB().Delete(solicitud);
                BorrarEnCadena(solicitud);
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

        public void BorrarEnCadena(Capa_de_negocio.Clases.Solicitud solicitud)
        {
            var registrosAEliminarAsistencia = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Asistencia>().Where(x => x.NoPractica == solicitud.noPractica).ToList();
            if (registrosAEliminarAsistencia.Count > 0)
            {
                foreach (var registro in registrosAEliminarAsistencia)
                {
                    ConexionDB.ConexionDB().Delete(registro);
                }
            }
            var registrosAEliminarGuia = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Guia>().Where(x => x.NoPractica == solicitud.noPractica).ToList();
            if (registrosAEliminarGuia.Count > 0)
            {
                foreach (var registro in registrosAEliminarGuia)
                {
                    ConexionDB.ConexionDB().Delete(registro);
                }
            }
        }

        public List<Capa_de_negocio.Clases.Solicitud> ConsultarSolicitudesFiltradas(string TextoABuscar)
        {
            var query = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Solicitud>().Where(x => x.NombrePractica.ToLower().Contains(TextoABuscar.ToLower())).ToList(); ;
            List<Capa_de_negocio.Clases.Solicitud> result = query.ToList();
            return result;
        }
    }
}
