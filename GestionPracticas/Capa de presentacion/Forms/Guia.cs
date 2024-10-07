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

namespace GestionPracticas.Forms
{
    public partial class Guia : Form
    {
        public Guia()
        {
            InitializeComponent();

            CargarComboBox();
        }
        Capa_de_negocio.Departamento depaNegocio = new Capa_de_negocio.Departamento();

        public Main FormPadre;
        public string departamento;
        public string nopractica;
        public string unidad;
        public string personaelabora;
        public string personarevisa;
        public string personaautoriza;
        public void CargarComboBox()
        {
            comboDepa.DisplayMember = "Nombre"; // Propiedad para mostrar el texto
            comboDepa.ValueMember = "idDepartamento"; // Propiedad para almacenar el valor real
            comboDepa.Items.Clear();
            foreach (var depa in depaNegocio.BuscarDepaListas())
            {
                comboDepa.Items.Add(depa);
            }

        }
        public void SetnoPractica(String value)
        {
            
            txtnoPractica.Text = value;
            txtnoPractica.Enabled = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Capa_de_negocio.Clases.Departamento depa = (Capa_de_negocio.Clases.Departamento)comboDepa.SelectedItem;

            nopractica = txtnoPractica.Text;
            unidad = txtnoUnidad.Text;
            personaelabora = txtPersonaElabora.Text;
            personarevisa = txtPersonaRevisa.Text;
            personaautoriza = txtPersonaAutoriza.Text;

            if (txtnoUnidad.TextLength < 1)
            {
                toolTip1.Show("Campo vacío.", txtnoUnidad, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }else if (depa == null)
            {
                toolTip1.Show("Selecciona un area.", comboDepa, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }else if (txtPersonaElabora.TextLength < 1)
            {
                toolTip1.Show("Campo vacío.", txtPersonaElabora, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }else if (txtPersonaRevisa.TextLength < 1)
            {
                toolTip1.Show("Campo vacío.", txtPersonaRevisa, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }else if (txtPersonaAutoriza.TextLength < 1)
            {
                toolTip1.Show("Campo vacío.", txtPersonaAutoriza, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
            else
            {
                departamento = depa.Nombre;
                //Pasar a la siguiente hoja
                Main test = FormPadre;
                Forms.Guia2 Frm = new Forms.Guia2();
                Frm.Guia1 = this;
                Frm.FormPadre = this.FormPadre;
                test.AgregarForm(Frm, "Guia 2/3");
            }

            
        }

        private void txtnoUnidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada no es un número o la tecla Backspace.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número o la tecla Backspace, bloquea la entrada.
                e.Handled = true;
                toolTip1.Show("Solo se permiten números.", txtnoUnidad, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
        }

        private void txtnoPractica_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
