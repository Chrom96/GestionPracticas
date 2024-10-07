using GestionPracticas.Capa_de_negocio.Clases;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SQLite.SQLite3;

namespace GestionPracticas.Capa_de_negocio
{
    internal class Asistencia
    {
        Capa_de_datos.Asistencia AsisDatos= new Capa_de_datos.Asistencia();
        Capa_de_datos.Solicitud SolDatos = new Capa_de_datos.Solicitud();

        public Accion Crear(string nopractica, string noalumno, string nombre, DateTime fechaasistencia, DateTime horaasistencia)
        {
            //Se crea informacion de la accion vacia
            var accion = new Clases.Accion()
            {
                Realizada = false,
                Msg = ""
            };

            var asistencia = new Clases.Asistencia()
            {
                NoPractica = Convert.ToInt32(nopractica),
                NoAlumno = Convert.ToInt32(noalumno),
                NombreAlumno = nombre,
                FechaAsistencia = fechaasistencia,
                HoraAsistencia = horaasistencia
            };

            accion = AsisDatos.InsertarSqlite(asistencia);
            return accion;
        }

        //OBJETO PARA RELLENAR DATAGRIDVIEW
       public class TablaPracticas
        {
           public int noPractica { get; set; }
           public string NombrePractica { get; set; }
           public string Maestro { get; set; }
           public string Area { get; set; }
        }


        public List<TablaPracticas> ListaSolicitudes()
        {
            Capa_de_datos.Profesor profeDatos = new Capa_de_datos.Profesor();
            Capa_de_datos.Area areaDatos = new Capa_de_datos.Area();

            List<TablaPracticas> listaPracticas = new List<TablaPracticas>();

            foreach (var soli in AsisDatos.ConsultarSolicitudes())
            {
                var practica = new TablaPracticas()
                {
                    noPractica = soli.noPractica,
                    NombrePractica = soli.NombrePractica,
                    Maestro = profeDatos.ConsultarProfe(soli.idProfesor).Nombre,
                    Area = areaDatos.ConsultarArea(soli.idArea).Nombre
                };
                listaPracticas.Add(practica);
            }

            return listaPracticas;
        }

        //OBJETO PARA RELLENAR DATAGRIDVIEW
        public class TablaAsistencias
        {
            public int ID { get; set; }
            public int NoControl { get; set; }
            public string Nombre { get; set; }
            public string Fecha { get; set; }
            public string Hora { get; set; }
        }
        public List<TablaAsistencias> ListaAsistencia(string noPractica)
        {
            List<TablaAsistencias> listaAsistencias = new List<TablaAsistencias>();
            
            foreach (var asis in AsisDatos.ConsultarAsistencias(Convert.ToInt32(noPractica)))
            {
                var asistencia = new TablaAsistencias()
                {
                    ID = asis.idAsistencia,
                    NoControl = asis.NoAlumno,
                    Nombre = asis.NombreAlumno,
                    Fecha = asis.FechaAsistencia.ToString("dd/MM/yyyy"),
                    Hora = asis.HoraAsistencia.ToString("hh:mm tt")
                };
                listaAsistencias.Add(asistencia);
            }

            return listaAsistencias;
        }

        public Accion Borrar(string noAsis)
        {
            //Se crea informacion de la accion vacia
            var accion = new Clases.Accion()
            {
                Realizada = false,
                Msg = ""
            };
            var asistencia = new Clases.Asistencia()
            {
                idAsistencia = Convert.ToInt32(noAsis),
            };

            accion = AsisDatos.BorrarSqlite(asistencia);
            return accion;
        }

        public class TablaAsistenciasHoja
        {
            public string Nombre { get; set; }
            public int NoControl { get; set; }
            
            public string Fecha { get; set; }
            public string Firma { get; set; }
        }
        public void ConvertRdlcToPdf(string nopractica)
        {
            Clases.Solicitud sol = SolDatos.ConsultarSolicitud(Convert.ToInt32(nopractica));
            try { 
           
            // Convierte la lista en un DataTable
            DataTable table = new DataTable();

            // Agrega columnas al DataTable para cada propiedad de la clase Item
            table.Columns.Add("Nombre", typeof(String));
            table.Columns.Add("NoControl", typeof(string));
            table.Columns.Add("Fecha", typeof(string));
            table.Columns.Add("Firma", typeof(string));

            // Llena el DataTable con los datos de la lista
            foreach (var asis in AsisDatos.ConsultarAsistencias(Convert.ToInt32(nopractica)))
            {
                table.Rows.Add(asis.NombreAlumno, asis.NoAlumno, (asis.FechaAsistencia.ToString("dd/MM/yyyy")+" " + asis.HoraAsistencia.ToString("hh:mm tt")),  "");
            }
                Capa_de_datos.Profesor profeDatos = new Capa_de_datos.Profesor();
                Capa_de_datos.Area areaDatos = new Capa_de_datos.Area();

                using (LocalReport localReport = new LocalReport())
            {
                localReport.ReportPath = Path.Combine("Reportes", "ReporteAsistencia.rdlc");
                ReportDataSource reportDataSource = new ReportDataSource("DataSetAsistencias", table);
                localReport.DataSources.Clear();
                localReport.DataSources.Add(reportDataSource);
                localReport.Refresh();

               


                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("pNombrePractica", sol.NombrePractica),
                    new ReportParameter("pMateria", sol.Materia),
                    new ReportParameter("pCarrera", areaDatos.ConsultarArea(sol.idArea).Nombre),
                    new ReportParameter("pGrupo", sol.Grupo),
                    new ReportParameter("pDocente", profeDatos.ConsultarProfe(sol.idProfesor).Nombre),
                    new ReportParameter("pNoPractica", sol.noPractica.ToString()),
                };
                // Asignar parámetros al informe
                if (parameters != null)
                {
                    localReport.SetParameters(parameters);
                }
                

                
                string mimeType;
                string encoding;
                string fileNameExtension;
                string[] streams;
                Warning[] warnings;
                /*var deviceInfo = @"<DeviceInfo>
<EmbedFonts>None</EmbedFonts>
</DeviceInfo>";*/
                string deviceInfo = @"
<DeviceInfo>
<EmbedFonts>None</EmbedFonts>
<OutputFormat>PDF</OutputFormat>
  <PageWidth>8.5in</PageWidth>      <!-- Ancho de página carta -->
  <PageHeight>11in</PageHeight>    <!-- Alto de página carta -->
  <MarginTop>0.25in</MarginTop>    <!-- Márgen superior -->
  <MarginLeft>0.25in</MarginLeft>  <!-- Márgen izquierdo -->
  <MarginRight>0.15in</MarginRight>  <!-- Márgen derecho -->
  <MarginBottom>0.25in</MarginBottom>  <!-- Márgen inferior -->
<ConsumeContainerWhitespace>True</ConsumeContainerWhitespace>  <!-- Evitar espacio en blanco -->

</DeviceInfo>";

                byte[] pdfBytes = localReport.Render("PDF", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

                // Guardar el PDF en el archivo especificado
                File.WriteAllBytes(Path.Combine("temp", "ReporteAsistencia.pdf"), pdfBytes);
                Process.Start(Path.Combine("temp", "ReporteAsistencia.pdf"));
            }

            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

    }
}
