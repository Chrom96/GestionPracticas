using GestionPracticas.Capa_de_negocio.Clases;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPracticas.Capa_de_datos
{
    internal class Alumno
    {
        //Se instancia la clase de conexion
        SqliteDB ConexionDB = new SqliteDB();

        //Toma el objeto de la capa 2 y lo registra en SQLite
        public Capa_de_negocio.Clases.Accion InsertarSqlite(Capa_de_negocio.Clases.Alumno Alumno)
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
                ConexionDB.ConexionDB().Insert(Alumno);

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

        public Capa_de_negocio.Clases.Alumno ConsultarAlumno(int nocontrol)
        {
            Capa_de_negocio.Clases.Alumno alumno = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Alumno>().Where(x => x.NoControl == nocontrol).FirstOrDefault();
            return alumno;
        }



        public Capa_de_negocio.Clases.Accion BorrarSqlite(Capa_de_negocio.Clases.Alumno alumno)
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
                ConexionDB.ConexionDB().Delete(alumno);
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


        public List<Capa_de_negocio.Clases.Alumno> ConsultarAlumnosFitlrado (string TextoABuscar)
        {
            var query = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Alumno>().Where(x => x.Nombre.ToLower().Contains(TextoABuscar.ToLower())).ToList(); ;
            List<Capa_de_negocio.Clases.Alumno> result = query.ToList();
            return result;
        }

        public DataTable ConsultarAlumnosFitlradoTable(string TextoABuscar)
        {
            var query = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Alumno>().Join(ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Area>(),
                                  alu => alu.idArea,
            area => area.idArea,
                                  (alu, area) => new { Alumno = alu, NombreArea = area.Nombre })
                .Where(x => x.Alumno.Nombre.ToLower().Contains(TextoABuscar.ToLower()));

            DataTable result = new DataTable();
            result.Columns.Add("NoControl");
            result.Columns.Add("Nombre");
            result.Columns.Add("Area");

            // Llenar la tabla con los resultados de la consulta
            foreach (var item in query)
            {
                result.Rows.Add(item.Alumno.NoControl, item.Alumno.Nombre, item.NombreArea);
            }

            return result;
        }

    }
}
