using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionPracticas.Capa_de_negocio.Clases;

namespace GestionPracticas.Forms
{
    public partial class Asistencias : Form
    {

        public Main FormPadre;
        Capa_de_negocio.Asistencia AsisNegocio = new Capa_de_negocio.Asistencia();
        public Asistencias()
        {
            InitializeComponent();
            
        }
        
        public void SetnoPractica(String value)
        {
            txtNoPractica.Text = value;
            dataGridView1.DataSource = AsisNegocio.ListaAsistencia(value);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[0].Width = 0;
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 80;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Capa_de_negocio.Asistencia SolAsis = new Capa_de_negocio.Asistencia();
            string nopractica = txtNoPractica.Text;
            string noalumno = txtNoAlumno.Text;
            string nombre = txtNombre.Text;
            DateTime fechaasistencia = dateFecha.Value;
            DateTime horaasistencia = dateHora.Value;

            if (txtNoAlumno.TextLength < 1)
            {
                toolTip1.Show("Campo vacío.", txtNoAlumno, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
            else if (txtNombre.TextLength < 1)
            {
                toolTip1.Show("Campo vacío.", txtNombre, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
            else
            {
                Accion accion = SolAsis.Crear(nopractica, noalumno, nombre, fechaasistencia, horaasistencia);
                if (accion.Realizada)
                {
                    SetnoPractica(nopractica);
                    MessageBox.Show("Asistencia registrada con exito.");
                    txtNoAlumno.Text = "";
                    txtNombre.Text = "";
                }
                else
                {
                    MessageBox.Show("Error: " + accion.Msg);
                }
            }

            


            
        }

        private void txtNoAlumno_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada no es un número o la tecla Backspace.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número o la tecla Backspace, bloquea la entrada.
                e.Handled = true;
                toolTip1.Show("Solo se permiten números.", txtNoAlumno, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Capa_de_negocio.Asistencia SolAsis = new Capa_de_negocio.Asistencia();
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string idAsis = Convert.ToString(selectedRow.Cells[0].Value);

                var confirmResult = MessageBox.Show("¿Deseas borrar la asistencia seleccionada?",
                                    "Confirmar Borrado (id: "+ idAsis + ")!!",
                                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // If 'Yes', do something here.
                    Accion accion = SolAsis.Borrar(idAsis);
                    if (accion.Realizada)
                    {
                        SetnoPractica(txtNoPractica.Text);
                        MessageBox.Show("Asistencia borrada con exito.");
                        //txtNoAlumno.Text = "";
                        //txtNombre.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Error: " + accion.Msg);
                    }
                }
                else
                {
                    // If 'No', do something here.
                }
            }
            else
            {
                MessageBox.Show("Seleccione un valor de la tabla");
            }

           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNoAlumno_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BuscarAlumno();
        }
        public void BuscarAlumno()
        {
            Capa_de_negocio.Alumno alumnoNegocio = new Capa_de_negocio.Alumno();
            if (txtNoAlumno.TextLength < 1)
            {
                toolTip1.Show("Campo vacío.", txtNoAlumno, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
            else
            {
                string nocontrol = txtNoAlumno.Text;
                if (alumnoNegocio.ExisteAlumno(nocontrol))
                {
                    txtNombre.Text = alumnoNegocio.ConsultarNombre(nocontrol);
                }
                else
                {
                    MessageBox.Show("Alumno no encontrado");
                }
            }
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtNoAlumno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarAlumno();
            }
        }
    }
}
