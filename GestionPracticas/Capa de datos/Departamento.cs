using GestionPracticas.Capa_de_negocio.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPracticas.Capa_de_datos
{
    internal class Departamento
    {
        //Se instancia la clase de conexion
        SqliteDB ConexionDB = new SqliteDB();

        //Toma el objeto de la capa 2 y lo registra en SQLite
        public Accion InsertarSqlite(Capa_de_negocio.Clases.Departamento depa)
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
                ConexionDB.ConexionDB().Insert(depa);

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

        public Capa_de_negocio.Clases.Departamento ConsultarDepa(int id)
        {
            Capa_de_negocio.Clases.Departamento depa = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Departamento>().Where(x => x.idDepartamento == id).FirstOrDefault();
            return depa;
        }
        public Capa_de_negocio.Clases.Departamento ConsultarPorNombre(string nombre)
        {
            Capa_de_negocio.Clases.Departamento depa = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Departamento>().Where(x => x.Nombre.ToLower().Equals(nombre.ToLower())).FirstOrDefault();
            return depa;
        }
        public Accion BorrarSqlite(Capa_de_negocio.Clases.Departamento depa)
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
                ConexionDB.ConexionDB().Delete(depa);
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


        public List<Capa_de_negocio.Clases.Departamento> ConsultaDepartamentos()
        {
            var query = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Departamento>().Where(x => x.Nombre.ToLower().Contains("")).ToList(); ;
            List<Capa_de_negocio.Clases.Departamento> result = query.ToList();
            return result;
        }
    }
}
