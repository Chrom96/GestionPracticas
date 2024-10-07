using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPracticas.Forms
{
    public partial class ListaPracticas : Form
    {
        Capa_de_negocio.Asistencia AsisNegocio = new Capa_de_negocio.Asistencia();
        public Main FormPadre;
        public string BtnTxt;
        public int destino;
        public ListaPracticas()
        {
            InitializeComponent();
            dataGridView1.DataSource = AsisNegocio.ListaSolicitudes();
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[2].Width = 100;
        }
        public void SetBtnText(String value)
        {
            button1.Text = value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                //tomar noPractica del renglon seleccionado
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["noPractica"].Value);

                if (destino == 1)
                {
                    //abrir otra ventana
                    Main frmPadre = FormPadre;
                    Forms.Asistencias Frm = new Forms.Asistencias();
                    Frm.FormPadre = this.FormPadre;
                    Frm.SetnoPractica(cellValue);
                    frmPadre.AgregarForm(Frm, "Registro Asistencias");
                }
                else if (destino == 2)
                {
                    VerificarExistencia(cellValue);

                }
                else if (destino == 3)
                {
                    Capa_de_negocio.Solicitud SolNegocio = new Capa_de_negocio.Solicitud();
                    if (SolNegocio.ExisteSolicitud(cellValue))
                    {
                        var confirmResult = MessageBox.Show("¿Deseas borrar la solicitud seleccionada? Esto borrara sus asistencias y guia",
                                            "Borrar solicitud ("+cellValue+")!!",
                                            MessageBoxButtons.YesNo);
                        if (confirmResult == DialogResult.Yes)
                        {
                            // If 'Yes', do something here.

                            SolNegocio.Borrar(cellValue);
                            dataGridView1.DataSource = AsisNegocio.ListaSolicitudes();
                        }
                        else
                        {
                            //

                        }
                    }

                }

            }
            else
            {
                MessageBox.Show("Seleccione una lista de la tabla");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        public void VerificarExistencia(String value)
        {
            Capa_de_negocio.Guia GuiaNegocio = new Capa_de_negocio.Guia();
            if (GuiaNegocio.ExisteGuia(value))
            {
                var confirmResult = MessageBox.Show("¿Deseas continuar y borrar la Guia registrada?",
                                    "Ya existe una guia registrada!!",
                                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // If 'Yes', do something here.

                    GuiaNegocio.Borrar(value);
                    //abrir otra ventana
                    Main frmPadre = FormPadre;
                    Forms.Guia Frm = new Forms.Guia();
                    Frm.FormPadre = this.FormPadre;
                    Frm.SetnoPractica(value);
                    frmPadre.AgregarForm(Frm, "Guia 1/3");
                }
                else
                {
                    //

                }
            }
            else
            {
                //abrir otra ventana
                Main frmPadre = FormPadre;
                Forms.Guia Frm = new Forms.Guia();
                Frm.FormPadre = this.FormPadre;
                Frm.SetnoPractica(value);
                frmPadre.AgregarForm(Frm, "Guia 1/3");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            Capa_de_negocio.Solicitud SolNegocio = new Capa_de_negocio.Solicitud();
            dataGridView1.DataSource = SolNegocio.BuscarSolicitudesLista(txtBuscar.Text);
        }
    }
}
