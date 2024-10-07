using GestionPracticas.Capa_de_negocio.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPracticas.Capa_de_presentacion.Forms
{
    public partial class Alumnos : Form
    {
        Capa_de_negocio.Alumno alumnoNegocio = new Capa_de_negocio.Alumno();
        public Alumnos()
        {
            InitializeComponent();
            dataGridView1.DataSource = alumnoNegocio.BuscarAlumnosTable("");
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 260;
            dataGridView1.Columns[2].Width = 80;
            CargarComboBox();
        }

        public void CargarComboBox()
        {
            Capa_de_negocio.Area areaNegocio = new Capa_de_negocio.Area();
            comboArea.DisplayMember = "Nombre"; // Propiedad para mostrar el texto
            comboArea.ValueMember = "idArea"; // Propiedad para almacenar el valor real
            comboArea.Items.Clear();
            foreach (var area in areaNegocio.BuscarAreasLista())
            {
                comboArea.Items.Add(area);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Capa_de_negocio.Clases.Area area = (Area)comboArea.SelectedItem;
            

                string nocontrol = txtNoControl.Text;
            string nombre = txtNombre.Text;

            if (txtNoControl.TextLength < 1)
            {
                toolTip1.Show("Campo vacío.", txtNoControl, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
            else if (txtNombre.TextLength < 1)
            {
                toolTip1.Show("Campo vacío.", txtNombre, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
            else
            {
                if (area == null)
                {
                    toolTip1.Show("Selecciona un area.", comboArea, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
                    return;
                }

                if (alumnoNegocio.ExisteAlumno(nocontrol))
                {
                    MessageBox.Show("Ya existe un alumno con este noControl");
                    return;
                }
                Accion accion = alumnoNegocio.Crear(nocontrol, nombre, area.idArea);
                if (accion.Realizada)
                {
                    MessageBox.Show("Alumno registrado con exito.");
                    txtNoControl.Text = "";
                    txtNombre.Text = "";
                    dataGridView1.DataSource = alumnoNegocio.BuscarAlumnosTable("");
                }
                else
                {
                    MessageBox.Show(accion.Msg);
                }
            }


        }

        private void txtNoControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada no es un número o la tecla Backspace.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número o la tecla Backspace, bloquea la entrada.
                e.Handled = true;
                toolTip1.Show("Solo se permiten números.", txtNoControl, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Capa_de_negocio.Alumno alumnoNegocio = new Capa_de_negocio.Alumno();
            dataGridView1.DataSource = alumnoNegocio.BuscarAlumnosTable(txtBuscar.Text);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay alumnos seleccionables", "Error");
                return;
            }
            //tomar noControl del renglon seleccionado

            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string cellValue = Convert.ToString(selectedRow.Cells["NoControl"].Value);

            var confirmResult = MessageBox.Show("¿Deseas continuar y borrar el Alumno seleccionado?",
                                   "Confirmar Borrado",
                                   MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // If 'Yes', do something here.
                
                alumnoNegocio.Borrar(cellValue);
                dataGridView1.DataSource = alumnoNegocio.BuscarAlumnosTable("");
                MessageBox.Show("Alumno borrado con exito");
                txtBuscar.Text = "";
            }


        }

        private void txtNoControl_TextChanged(object sender, EventArgs e)
        {
            if (alumnoNegocio.ExisteAlumno(txtNoControl.Text)) 
            {
                lblValidacion.Text = "X";
                
                lblValidacion.ForeColor = Color.Red;
            }
            else
            {
                lblValidacion.Text = "✔";
                lblValidacion.ForeColor = Color.LimeGreen;
            }
        }
    }
}
