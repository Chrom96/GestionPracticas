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
using GestionPracticas.Capa_de_negocio.Clases;

namespace GestionPracticas.Forms
{
    public partial class Solicitud : Form
    {
        public Solicitud()
        {
            InitializeComponent();
            CargarComboBox();
        }


        Capa_de_negocio.Area areaNegocio = new Capa_de_negocio.Area();
        Capa_de_negocio.Laboratorio laboNegocio = new Capa_de_negocio.Laboratorio();
        Capa_de_negocio.Profesor profeNegocio = new Capa_de_negocio.Profesor();
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

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        ///Envia la informacion a la capa 2 para crear registro
        private void button1_Click(object sender, EventArgs e)
        {
            Capa_de_negocio.Clases.Area area = (Area)comboArea.SelectedItem;
            Capa_de_negocio.Clases.Laboratorio labo = (Laboratorio)comboLabo.SelectedItem;
            Capa_de_negocio.Clases.Profesor profe = (Profesor)comboProfe.SelectedItem;

            Capa_de_negocio.Solicitud SolNegocio = new Capa_de_negocio.Solicitud();
            DateTime FechaRealizacion = fechaRealizacion.Value;
            DateTime FechaSolicitud = fechaSolicitud.Value;
            DateTime hora = dateHora.Value;
            string nopractica = "";
            string nombrepractica = txtNombrePractica.Text;
            string materia = txtMateria.Text;
            string grupo = txtGrupo.Text;
            string noalumnos = txtNoAlumnos.Text;
            if (txtNombrePractica.TextLength<1) {
                toolTipError.Show("Campo vacío.", txtNombrePractica, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
            else if (txtMateria.TextLength<1)
            {
                toolTipError.Show("Campo vacío.", txtMateria, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
            else if (area == null)
            {
                toolTipError.Show("Selecciona un area.", comboArea, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
            else if (txtGrupo.TextLength < 1)
            {
                toolTipError.Show("Campo vacío.", txtGrupo, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
            else if (txtNoAlumnos.TextLength < 1)
            {
                toolTipError.Show("Campo vacío.", txtNoAlumnos, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
            else if (labo == null)
            {
                toolTipError.Show("Selecciona un laboratorio.", comboLabo, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
             else if (profe == null)
            {
                toolTipError.Show("Campo vacío.", comboProfe, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
            else
            {
                Accion accion = SolNegocio.Crear(FechaSolicitud, FechaRealizacion, hora, nopractica, nombrepractica, materia, area.idArea, grupo, noalumnos, labo.idLaboratorio, profe.idProfesor);
                if (accion.Realizada)
                {
                    MessageBox.Show("Solicitud registrada con exito.");
                    //txtNoPractica.Text = "";
                    txtNombrePractica.Text = "";
                    txtMateria.Text = "";
                    comboArea.Text = "";
                    comboArea.SelectedItem = null;
                    txtGrupo.Text = "";
                    txtNoAlumnos.Text = "";
                    comboLabo.Text = "";
                    comboLabo.SelectedItem = null;
                    comboProfe.Text = "";
                    comboProfe.SelectedItem = null;
                    comboProfe.Enabled = false;
                    //btnCheck.Enabled = true;
                    //btnRegistrar.Enabled = false;
                    //txtNoPractica.Enabled = true;
                }
            }

            

        }


        private void txtNoAlumnos_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada no es un número o la tecla Backspace.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número o la tecla Backspace, bloquea la entrada.
                e.Handled = true;
                toolTip1.Show("Solo se permiten números.", txtNoAlumnos, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
        }

        /*
        private void button2_Click(object sender, EventArgs e)
        {
            
            string nopractica = txtNoPractica.Text;
            Capa_de_negocio.Solicitud SolNegocio = new Capa_de_negocio.Solicitud();
            if (txtNoPractica.TextLength<1)
            {
                MessageBox.Show("Escribe un No. de practica");
            }
            else
            {
                if (SolNegocio.ExisteSolicitud(nopractica))
                {
                    var confirmResult = MessageBox.Show("Ya existe solicitud con el No. de Practica ¿Deseas borrarla?",
                                        "Ya existe una solicitud registrada!!",
                                        MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        // If 'Yes', do something here.

                        SolNegocio.Borrar(nopractica);
                        txtNoPractica.Enabled = false;
                        btnRegistrar.Enabled = true;
                        btnCheck.Enabled = false;

                    }
                    else
                    {
                        //

                    }
                }
                else
                {
                    txtNoPractica.Enabled = false;
                    btnRegistrar.Enabled = true;
                    btnCheck.Enabled = false;
                }
            }
            
        }
        */
        private void comboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            Capa_de_negocio.Clases.Area area = (Area)comboArea.SelectedItem;
            if (area != null)
            {
                comboProfe.Text = "";
                comboProfe.SelectedItem = null;
                comboProfe.Enabled = true;
                CargarComboProfe(area.idArea);
            }
        }

        public void CargarComboProfe(int area)
        {
            comboProfe.DisplayMember = "Nombre"; // Propiedad para mostrar el texto
            comboProfe.ValueMember = "idProfesor"; // Propiedad para almacenar el valor real
            comboProfe.Items.Clear();
            foreach (var profe in profeNegocio.BuscarProfesoresArea(area))
            {
                comboProfe.Items.Add(profe);
            }

        }

        private void txtNombrePractica_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
