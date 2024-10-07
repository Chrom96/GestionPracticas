using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPracticas.Forms_1_
{
    public partial class GenerarReportes : Form
    {
        Capa_de_negocio.Asistencia AsisNegocio = new Capa_de_negocio.Asistencia();
        Capa_de_negocio.Solicitud SolNegocio = new Capa_de_negocio.Solicitud();
        Capa_de_negocio.Guia GuiaNegocio = new Capa_de_negocio.Guia();
        public GenerarReportes()
        {
            InitializeComponent();
            dataGridView1.DataSource = AsisNegocio.ListaSolicitudes();
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[2].Width = 100;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                //tomar noPractica del renglon seleccionado
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string NoPractica = Convert.ToString(selectedRow.Cells["noPractica"].Value);


                if (radioSolicitud.Checked)
                {
                    SolNegocio.ConvertRdlcToPdf(NoPractica);
                }
                if (radioAsistencias.Checked)
                {
                    AsisNegocio.ConvertRdlcToPdf(NoPractica);
                }
                if (radioGuia.Checked)
                {
                    if (!GuiaNegocio.ExisteGuia(NoPractica))
                    {
                        MessageBox.Show("No existe una guia registrada");
                    }
                    else
                    {
                        GuiaNegocio.ConsultarYUnirDocumentos(NoPractica);
                    }
                    
                }

            }
            else
            {
                MessageBox.Show("Seleccione un valor de la tabla");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Capa_de_negocio.Solicitud SolNegocio = new Capa_de_negocio.Solicitud();
            dataGridView1.DataSource = SolNegocio.BuscarSolicitudesLista(txtBuscar.Text);
        }
    }
}
