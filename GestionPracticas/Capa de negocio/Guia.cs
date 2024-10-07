using GestionPracticas.Capa_de_negocio.Clases;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Org.BouncyCastle.Utilities;

namespace GestionPracticas.Capa_de_negocio
{
    internal class Guia
    {
        Capa_de_datos.Guia GuiaDatos = new Capa_de_datos.Guia();
        Capa_de_datos.Solicitud SolDatos = new Capa_de_datos.Solicitud();
        public Accion Crear(string departamento, string nopractica, string unidad, string personaelabora,
            string personarevisa, string personaautoriza, string objetivo, string introduccion, string material,
            string condicionesseguridad, string peligros, string respuestacontingencia, string desarrolloexperimental,
            string cuestionario, string tiporesiduos, string tratamientoresiduos, string disposicionresiduos, string actividadescomplementarias, string bibliografia)
        {
            //Se crea informacion de la accion vacia
            var accion = new Clases.Accion()
            {
                Realizada = false,
                Msg = ""
            };


            var guia = new Clases.Guia()
            {
                Departamento = departamento,
                NoPractica = Convert.ToInt32(nopractica),
                Unidad = Convert.ToInt32(unidad),
                PersonaElabora = personaelabora,
                PersonaRevisa = personarevisa,
                PersonaAutoriza = personaautoriza,
                Objetivo = objetivo,
                Introduccion = introduccion,
                Material = material,
                CondicionesSeguridad = condicionesseguridad,
                Peligros = peligros,
                RespuestaContingencia = respuestacontingencia,
                DesarrolloExperimental = desarrolloexperimental,
                Cuestionario = cuestionario,
                TipoResiduos = tiporesiduos,
                TratamientoResiduos = tratamientoresiduos,
                DisposicionResiduos = disposicionresiduos,
                ActividadesComplementarias = actividadescomplementarias,
                Bibliografia = bibliografia
            };

            accion = GuiaDatos.InsertarSqlite(guia);
            return accion;
        }

        public string ConvertirDataGrid(DataGridView tablaMaterial)
        {

            string material = "";
            //Convertir informacion de tabla a una sola cadena de texto separada por simbolos | ~
            if (tablaMaterial.Rows.Count > 0)
            {
                foreach (DataGridViewRow renglon in tablaMaterial.Rows)
                {
                    material += renglon.Cells[0].Value;
                    //simbolo ~ para separar cantidad de la descripcion
                    material += "~";
                    material += renglon.Cells[1].Value;
                    //simbolo | para separar renglon
                    material += "|";
                }
            }
            return material;
        }


        public void ConvertRdlcToPdf1(string nopractica)
        {
            Clases.Solicitud sol = SolDatos.ConsultarSolicitud(Convert.ToInt32(nopractica));
            Clases.Guia guia = GuiaDatos.ConsultarGuia(Convert.ToInt32(nopractica));
            try
            {
            

            using (LocalReport localReport = new LocalReport())
            {
                localReport.ReportPath = Path.Combine("Reportes", "ReporteGuia1.rdlc");

                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("pDepartamento", guia.Departamento),
                    new ReportParameter("pAsignatura", sol.Materia),
                    new ReportParameter("pUnidad", guia.Unidad.ToString()),
                    new ReportParameter("pNoPractica", sol.noPractica.ToString()),
                    new ReportParameter("pNombrePractica", sol.NombrePractica),
                    new ReportParameter("pElabora", guia.PersonaElabora),
                    new ReportParameter("pRevisa", guia.PersonaRevisa),
                    new ReportParameter("pAutoriza", guia.PersonaAutoriza)
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
                File.WriteAllBytes(Path.Combine("temp", "guia1.pdf"), pdfBytes);
                //Process.Start(Path.Combine("temp", "ReporteAsistencia.pdf"));
            }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        public class TablaMaterial
        {
            public string Cantidad { get; set; }
            public string Descripcion { get; set; }
        }
        public void ConvertRdlcToPdf2(string nopractica)
        {
            Clases.Solicitud sol = SolDatos.ConsultarSolicitud(Convert.ToInt32(nopractica));
            Clases.Guia guia = GuiaDatos.ConsultarGuia(Convert.ToInt32(nopractica));
            try
            {
            

            using (LocalReport localReport = new LocalReport())
            {
                localReport.ReportPath = Path.Combine("Reportes", "ReporteGuia2.rdlc");
                ReportDataSource reportDataSource = new ReportDataSource("DataSetMaterial", CreateDataTableFromString(guia.Material));
                localReport.DataSources.Clear();
                localReport.DataSources.Add(reportDataSource);
                localReport.Refresh();

                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("pObjetivos", guia.Objetivo),
                     new ReportParameter("pIntroduccion", guia.Introduccion),
                      new ReportParameter("pCondiciones", guia.CondicionesSeguridad),
                       new ReportParameter("pPeligros", guia.Peligros),
                        new ReportParameter("pRespuesta", guia.RespuestaContingencia),
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
                File.WriteAllBytes(Path.Combine("temp", "guia2.pdf"), pdfBytes);
                //Process.Start(Path.Combine("temp", "ReporteAsistencia.pdf"));
            }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        public void ConvertRdlcToPdf3(string nopractica)
        {
            Clases.Solicitud sol = SolDatos.ConsultarSolicitud(Convert.ToInt32(nopractica));
            Clases.Guia guia = GuiaDatos.ConsultarGuia(Convert.ToInt32(nopractica));
            try
            {

            
            using (LocalReport localReport = new LocalReport())
            {
                localReport.ReportPath = Path.Combine("Reportes", "ReporteGuia3.rdlc");

                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("pDesarrollo", guia.DesarrolloExperimental),
                    new ReportParameter("pCuestionario", guia.Cuestionario),
                    new ReportParameter("pTipoResiduos", guia.TipoResiduos),
                    new ReportParameter("pTratamientoResiduos", guia.TratamientoResiduos),
                    new ReportParameter("pDisposicionResiduos", guia.DisposicionResiduos),
                    new ReportParameter("pActividades", guia.ActividadesComplementarias),
                    new ReportParameter("pBibliografia", guia.Bibliografia),

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
                File.WriteAllBytes(Path.Combine("temp", "guia3.pdf"), pdfBytes);
                //Process.Start(Path.Combine("temp", "ReporteAsistencia.pdf"));
            }
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }

        public void ConsultarYUnirDocumentos(string nopractica)
        {
            
            ConvertRdlcToPdf1(nopractica);
            ConvertRdlcToPdf2(nopractica);
            ConvertRdlcToPdf3(nopractica);

            string[] informes = { Path.Combine("temp", "guia1.pdf"), Path.Combine("temp", "guia2.pdf"), Path.Combine("temp", "guia3.pdf") };  // Lista de nombres de archivos de informe

            string archivoSalida = Path.Combine("temp", "ReporteGuia.pdf");
            try {
                using (FileStream fs = new FileStream(archivoSalida, FileMode.Create))
                {
                    Document document = new Document();
                    PdfCopy copy = new PdfCopy(document, fs);
                    document.Open();

                    foreach (string informe in informes)
                    {
                        using (PdfReader reader = new PdfReader(informe))
                        {
                            for (int i = 1; i <= reader.NumberOfPages; i++)
                            {
                                PdfImportedPage page = copy.GetImportedPage(reader, i);
                                copy.AddPage(page);
                            }
                        }
                    }

                    document.Close();
                }
                Process.Start(Path.Combine("temp", "ReporteGuia.pdf"));
            }
            catch(Exception E) { MessageBox.Show(E.Message);}
            

        }

        public DataTable CreateDataTableFromString(string data)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Cantidad", typeof(String));
            dataTable.Columns.Add("Descripcion", typeof(string));
            // Divide el string en filas utilizando el carácter "|".
            string[] rows = data.Split('|');

            if (rows.Length > 0)
            {
                // Divide la primera fila en columnas utilizando el carácter "~" para crear las columnas del DataTable.
                string[] columns = rows[0].Split('~');


                // Agrega las filas restantes al DataTable.
                for (int i = 0; i < rows.Length; i++)
                {
                    string[] rowValues = rows[i].Split('~');
                    if (rowValues.Length == columns.Length)
                    {
                        DataRow newRow = dataTable.NewRow();
                        for (int j = 0; j < columns.Length; j++)
                        {
                            newRow[j] = rowValues[j];
                        }
                        dataTable.Rows.Add(newRow);
                    }
                }
            }

            return dataTable;
        }

        public bool ExisteGuia(string noPractica){
            bool existe = false;
            Clases.Guia guiaaux = GuiaDatos.ConsultarGuia(Convert.ToInt32(noPractica));
            if (guiaaux != null)
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
            var guia = GuiaDatos.ConsultarGuia(Convert.ToInt32(noPractica));

            accion = GuiaDatos.BorrarSqlite(guia);
        }
    }
}
