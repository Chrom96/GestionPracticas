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
    public partial class Extras : Form
    {
        
        public Extras()
        {
            InitializeComponent();
            CargarComboBox();
        }
        Capa_de_negocio.Area areaNegocio = new Capa_de_negocio.Area();
        Capa_de_negocio.Laboratorio laboNegocio = new Capa_de_negocio.Laboratorio();
        Capa_de_negocio.Departamento depaNegocio = new Capa_de_negocio.Departamento();
        public void MostrarArea()
        {
            pnlArea.Visible = true;
        }
        public void MostrarDepartamento()
        {
            pnlDepartamento.Visible = true;
        }
        public void MostrarLaboratorio()
        {
            pnlLaboratorio.Visible = true;
        }
        public void CargarComboBox()
        {
            comboArea.DisplayMember = "Nombre"; // Propiedad para mostrar el texto
            comboArea.ValueMember = "idArea"; // Propiedad para almacenar el valor real
            comboArea.Items.Clear();
            foreach (var area in areaNegocio.BuscarAreasLista())
            {
                comboArea.Items.Add(area);
            }

            comboLabo.DisplayMember = "Nombre"; // Propiedad para mostrar el texto
            comboLabo.ValueMember = "idLaboratorio"; // Propiedad para almacenar el valor real
            comboLabo.Items.Clear();
            foreach (var labo in laboNegocio.BuscarLaboratoriosLista())
            {
                comboLabo.Items.Add(labo);
            }
            comboDepa.DisplayMember = "Nombre"; // Propiedad para mostrar el texto
            comboDepa.ValueMember = "idDepartamento"; // Propiedad para almacenar el valor real
            comboDepa.Items.Clear();
            foreach (var depa in depaNegocio.BuscarDepaListas())
            {
                comboDepa.Items.Add(depa);
            }
        }
        
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            string nombre = txtArea.Text;

            if (txtArea.TextLength < 1)
            {
                toolTip1.Show("Campo vacío.", txtArea, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
            else
            {
                Accion accion = areaNegocio.Crear(nombre);
                if (accion.Realizada)
                {
                    MessageBox.Show("Area registrado con exito.");
                    txtArea.Text = "";
                    CargarComboBox();
                }
                else
                {
                    MessageBox.Show(accion.Msg);
                }
            }


        }

        private void btnBorrarArea_Click(object sender, EventArgs e)
        {
            Capa_de_negocio.Clases.Area area = (Area) comboArea.SelectedItem;
            if (area != null)
            {
                areaNegocio.Borrar(area.idArea.ToString()) ;
                MessageBox.Show("Area borrada con exito");
                comboArea.Text = "";
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("Selecciona un area para borrar");
            }
            
        }

        private void btnRegistrarLabo_Click(object sender, EventArgs e)
        {

            string nombre = txtLabo.Text;

            if (txtLabo.TextLength < 1)
            {
                toolTip1.Show("Campo vacío.", txtLabo, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
            else
            {
                Accion accion = laboNegocio.Crear(nombre);
                if (accion.Realizada)
                {
                    MessageBox.Show("Laboratorio registrado con exito.");
                    txtLabo.Text = "";
                    CargarComboBox();
                }
                else
                {
                    MessageBox.Show(accion.Msg);
                }
            }

        }

        private void btnBorrarLabo_Click(object sender, EventArgs e)
        {
            Capa_de_negocio.Clases.Laboratorio labo = (Laboratorio)comboLabo.SelectedItem;
            if (labo != null)
            {
                laboNegocio.Borrar(labo.idLaboratorio.ToString());
                MessageBox.Show("Laboratorio borrado con exito");
                comboLabo.Text = "";
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("Selecciona un laboratorio para borrar");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = txtDepa.Text;

            if (txtDepa.TextLength < 1)
            {
                toolTip1.Show("Campo vacío.", txtDepa, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
            else
            {
                Accion accion = depaNegocio.Crear(nombre);
                if (accion.Realizada)
                {
                    MessageBox.Show("Departamento registrado con exito.");
                    txtDepa.Text = "";
                    CargarComboBox();
                }
                else
                {
                    MessageBox.Show(accion.Msg);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Capa_de_negocio.Clases.Departamento depa = (Departamento)comboDepa.SelectedItem;
            if (depa != null)
            {
                depaNegocio.Borrar(depa.idDepartamento.ToString());
                MessageBox.Show("Departamento borrado con exito");
                comboLabo.Text = "";
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("Selecciona un Departamento para borrar");
            }
        }
    }
}
