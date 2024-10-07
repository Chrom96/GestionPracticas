using GestionPracticas.Capa_de_negocio.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPracticas.Capa_de_datos
{
    internal class Guia
    {
        //Se instancia la clase de conexion
        SqliteDB ConexionDB = new SqliteDB();

        public Accion InsertarSqlite(Capa_de_negocio.Clases.Guia guia)
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
                ConexionDB.ConexionDB().Insert(guia);

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


        public Capa_de_negocio.Clases.Guia ConsultarGuia(int nopractica)
        {
            Capa_de_negocio.Clases.Guia guia = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Guia>().Where(x => x.NoPractica == nopractica).FirstOrDefault();
            return guia;
        }
        public Accion BorrarSqlite(Capa_de_negocio.Clases.Guia guia)
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
                ConexionDB.ConexionDB().Delete(guia);

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
    }
}
