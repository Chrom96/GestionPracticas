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
using static GestionPracticas.Capa_de_negocio.Asistencia;

namespace GestionPracticas.Capa_de_negocio
{
    internal class Solicitud
    {

        //Crea nuevo objeto y lo rellena con la informacion de la capa 1 para enviarlo a la capa de datos
        Capa_de_datos.Solicitud SolDatos= new Capa_de_datos.Solicitud();
        public Accion Crear(DateTime fechasolicitud, DateTime fecharealizacion, DateTime hora, string nopractica, string nombrepractica,
            string materia, int idarea, string grupo, string noalumnos, int idlaboratorio, int iddocente)
        {
            //Se crea informacion de la accion vacia
            var accion = new Accion()
            {
                Realizada = false,
                Msg = ""
            };

            // convertir a string de regreso 12:00 am
            // date.ToString("hh:mm tt", CultureInfo.CurrentCulture);

            var solicitud = new Clases.Solicitud()
            {
                FechaSolicitud = fechasolicitud,
                FechaRealizacion = fecharealizacion,
                Hora = hora,
                //noPractica = Convert.ToInt32(nopractica),
                NombrePractica = nombrepractica,
                Materia = materia,
                idArea = idarea,
                Grupo = grupo,
                noAlumnos = Convert.ToInt32(noalumnos),
                idLaboratorio = idlaboratorio,
                idProfesor = iddocente
            };

            accion = SolDatos.InsertarSqlite(solicitud);
            return accion;
        }


        public void ConvertRdlcToPdf(string nopractica)
        {
            Clases.Solicitud sol = SolDatos.ConsultarSolicitud(Convert.ToInt32(nopractica));
            Capa_de_datos.Profesor profeDatos = new Capa_de_datos.Profesor();
            Capa_de_datos.Area areaDatos = new Capa_de_datos.Area();
            Capa_de_datos.Laboratorio laboDatos = new Capa_de_datos.Laboratorio();
            try
            {

            
            using (LocalReport localReport = new LocalReport())
            {
                localReport.ReportPath = Path.Combine("Reportes", "ReporteSolicitud.rdlc");
                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("pFechaSolicitud", sol.FechaSolicitud.ToString("dd/MM/yyyy")),
                    new ReportParameter("pFechaRealizacion", sol.FechaRealizacion.ToString("dd/MM/yyyy")),
                    new ReportParameter("pHora", sol.Hora.ToString("hh:mm tt")),
                    new ReportParameter("pNombrePractica", sol.NombrePractica),
                    new ReportParameter("pMateria", sol.Materia),
                    new ReportParameter("pCarrera", areaDatos.ConsultarArea(sol.idArea).Nombre),
                    new ReportParameter("pGrupo", sol.Grupo),
                    new ReportParameter("pLaboratorio", laboDatos.ConsultarLaboratorio(sol.idLaboratorio).Nombre),
                    new ReportParameter("pDocente", profeDatos.ConsultarProfe(sol.idProfesor).Nombre),
                    new ReportParameter("pNoAlumnos", sol.noAlumnos.ToString()),
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
                File.WriteAllBytes(Path.Combine("temp", "ReporteSolicitud.pdf"), pdfBytes);
                Process.Start(Path.Combine("temp", "ReporteSolicitud.pdf"));
            }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }


        public bool ExisteSolicitud(string noPractica)
        {
            bool existe = false;
            Clases.Solicitud solAux = SolDatos.ConsultarSolicitud(Convert.ToInt32(noPractica));
            if (solAux != null)
            {
                existe = true;
            }
            return existe;
        }

        public void Borrar(string noPractica)
        {
            //Se crea informacion de la accion vacia
            var accion = new Clases.Accion()
            {
                Realizada = false,
                Msg = ""
            };
            var sol = SolDatos.ConsultarSolicitud(Convert.ToInt32(noPractica));

            accion = SolDatos.BorrarSqlite(sol);
        }

        public List<TablaPracticas> BuscarSolicitudesLista(string TextoABuscar)
        {
            List<TablaPracticas> listaPracticas = new List<TablaPracticas>();
            Capa_de_datos.Profesor profeDatos = new Capa_de_datos.Profesor();
            foreach (var soli in SolDatos.ConsultarSolicitudesFiltradas(TextoABuscar))
            {
                var practica = new TablaPracticas()
                {
                    noPractica = soli.noPractica,
                    NombrePractica = soli.NombrePractica,
                    Maestro = profeDatos.ConsultarProfe(soli.idProfesor).Nombre,
                };
                listaPracticas.Add(practica);
            }

            return listaPracticas;
        }

        public void CrearDirectorio()
        {
            string nombreDirectorio = "temp"; // Nombre del directorio a crear

            string rutaDirectorio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nombreDirectorio);

            if (!Directory.Exists(rutaDirectorio))
            {
                Directory.CreateDirectory(rutaDirectorio);
                Console.WriteLine("Directorio creado correctamente.");
            }


        }

    }

}

