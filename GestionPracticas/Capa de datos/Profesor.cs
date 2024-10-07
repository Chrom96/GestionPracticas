using GestionPracticas.Capa_de_negocio.Clases;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPracticas.Capa_de_datos
{
    internal class Profesor
    {
        //Se instancia la clase de conexion
        SqliteDB ConexionDB = new SqliteDB();

        //Toma el objeto de la capa 2 y lo registra en SQLite
        public Accion InsertarSqlite(Capa_de_negocio.Clases.Profesor profe)
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
                ConexionDB.ConexionDB().Insert(profe);

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

        public Capa_de_negocio.Clases.Profesor ConsultarProfe(int id)
        {
            Capa_de_negocio.Clases.Profesor profe = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Profesor>().Where(x => x.idProfesor == id).FirstOrDefault();
            return profe;
        }
        public Capa_de_negocio.Clases.Profesor ConsultarProfeNombre(string nombre)
        {
            Capa_de_negocio.Clases.Profesor profe = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Profesor>().Where(x => x.Nombre.ToLower().Equals(nombre.ToLower())).FirstOrDefault();
            return profe;
        }
        public Accion BorrarSqlite(Capa_de_negocio.Clases.Profesor profe)
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
                ConexionDB.ConexionDB().Delete(profe);
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


        public DataTable ConsultarProfesoresFitlrado(string TextoABuscar)
        {
            var query = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Profesor>().Join(ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Area>(),
                                  profe => profe.idArea,
            area => area.idArea,
                                  (profe, area) => new { Profe = profe, NombreArea = area.Nombre })
                .Where(x => x.Profe.Nombre.ToLower().Contains(TextoABuscar.ToLower()));

            DataTable result = new DataTable();
            result.Columns.Add("idProfesor");
            result.Columns.Add("Nombre");
            result.Columns.Add("Area");

            // Llenar la tabla con los resultados de la consulta
            foreach (var item in query)
            {
                result.Rows.Add(item.Profe.idProfesor, item.Profe.Nombre, item.NombreArea);
            }

            return result;
        }
        public static DataTable ConvertirADataTable(IEnumerable<object> listaObjetos)
        {
            DataTable resultado = new DataTable();

            if (listaObjetos.Any())
            {
                PropertyInfo[] propiedades = listaObjetos.First().GetType().GetProperties();

                // Agregar columnas a la tabla basadas en las propiedades del primer objeto en la lista
                foreach (var propiedad in propiedades)
                {
                    resultado.Columns.Add(propiedad.Name, Nullable.GetUnderlyingType(propiedad.PropertyType) ?? propiedad.PropertyType);
                }

                // Llenar la tabla con los valores de las propiedades de cada objeto en la lista
                foreach (var item in listaObjetos)
                {
                    DataRow fila = resultado.NewRow();
                    foreach (var propiedad in propiedades)
                    {
                        fila[propiedad.Name] = propiedad.GetValue(item);
                    }
                    resultado.Rows.Add(fila);
                }
            }

            return resultado;
        }
        public List<Capa_de_negocio.Clases.Profesor> ConsultarProfesoresArea(int idarea)
        {
            var query = ConexionDB.ConexionDB().Table<Capa_de_negocio.Clases.Profesor>().Where(x => x.idArea == idarea).ToList(); ;
            List<Capa_de_negocio.Clases.Profesor> result = query.ToList();
            return result;
        }
    }
}
