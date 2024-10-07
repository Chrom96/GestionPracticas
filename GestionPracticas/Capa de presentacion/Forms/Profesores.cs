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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GestionPracticas.Capa_de_presentacion.Forms
{
    public partial class Profesores : Form
    {
        Capa_de_negocio.Profesor profeNegocio = new Capa_de_negocio.Profesor();
        public Profesores()
        {
            InitializeComponent();
            CargarComboBox();
            dataGridView1.DataSource = profeNegocio.BuscarProfesoresLista("");
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 90;
        }
        public void CargarComboBox()
        {
            Capa_de_negocio.Area areaNegocio = new Capa_de_negocio.Area();
            comboArea.DisplayMember = "Nombre"; // Propiedad para mostrar el texto
            comboArea.ValueMember = "idArea"; // Propiedad para almacenar el valor real
            comboArea.Items.Clear();

            ComboBuscarArea.DisplayMember = "Nombre"; // Propiedad para mostrar el texto
            ComboBuscarArea.ValueMember = "idArea"; // Propiedad para almacenar el valor real
            ComboBuscarArea.Items.Clear();
            Area filtroTodos = new Area();

            filtroTodos.Nombre = "Todas";
            filtroTodos.idArea = -1;

            ComboBuscarArea.Items.Add(filtroTodos);
            foreach (var area in areaNegocio.BuscarAreasLista())
            {
                comboArea.Items.Add(area);
                ComboBuscarArea.Items.Add(area);
            }
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            Capa_de_negocio.Clases.Area area = (Area)comboArea.SelectedItem;
            if (area != null)
            {
                string nombre = txtNombre.Text;
                if (txtNombre.TextLength < 1)
                {
                    toolTip1.Show("Campo vacío.", txtNombre, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
                }
                else
                {
                    Accion accion = profeNegocio.Crear(nombre, area.idArea);
                    if (accion.Realizada)
                    {
                        MessageBox.Show("Profesor registrado con exito.");
                        comboArea.Text = "";
                        txtNombre.Text = "";
                        comboArea.SelectedItem = null;
                        dataGridView1.DataSource = profeNegocio.BuscarProfesoresLista("");
                    }
                    else
                    {
                        MessageBox.Show(accion.Msg);
                    }
                }
            }
            else
            {
                toolTip1.Show("Selecciona un area.", comboArea, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }

            

            


        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = profeNegocio.BuscarProfesoresLista(txtBuscar.Text);
            AplicarFiltro();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay profesores seleccionables", "Error");
                return;
            }
            //tomar noControl del renglon seleccionado
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string cellValue = Convert.ToString(selectedRow.Cells["idProfesor"].Value);

            var confirmResult = MessageBox.Show("¿Deseas continuar y borrar el Profesor seleccionado?",
                                   "Confirmar Borrado",
                                   MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // If 'Yes', do something here.

                profeNegocio.Borrar(cellValue);
                dataGridView1.DataSource = profeNegocio.BuscarProfesoresLista("");
                MessageBox.Show("Profesor borrado con exito");
                txtBuscar.Text = "";
            }

        }

        private void ComboBuscarArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }
        public void AplicarFiltro()
        {
            dataGridView1.DataSource = profeNegocio.BuscarProfesoresLista(txtBuscar.Text);
            string nombreColumna = "Area";
            string nombreArea = ((Area)ComboBuscarArea.SelectedItem).Nombre;
            int valor = ((Area)ComboBuscarArea.SelectedItem).idArea;

            if (valor != -1)
                FiltrarPorColumna(nombreColumna, nombreArea);
            else
                dataGridView1.DataSource = profeNegocio.BuscarProfesoresLista(txtBuscar.Text);
        }
        private void FiltrarPorColumna(string nombreColumna, string valor)
        {
            // Obtiene el DataTable del origen de datos del DataGridView
            var dataTable = dataGridView1.DataSource as DataTable;
            if (dataTable != null)
            {
                // Crea una expresión de filtro
                string filtro = $"{nombreColumna} = '{valor}'";

                // Filtra las filas en el DataTable
                DataRow[] filasFiltradas = dataTable.Select(filtro);

                // Crea un nuevo DataTable para almacenar las filas filtradas
                DataTable dataTableFiltrado = dataTable.Clone();
                foreach (DataRow fila in filasFiltradas)
                {
                    dataTableFiltrado.ImportRow(fila);
                }

                // Asigna el DataTable filtrado al DataGridView
                dataGridView1.DataSource = dataTableFiltrado;
            }
        }

    }
}
