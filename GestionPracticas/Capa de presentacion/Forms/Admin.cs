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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            txtPass.PasswordChar = '*';
        }
        public Main FormPadre;
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPass.TextLength < 1)
            {
                toolTip1.Show("Campo vacío.", txtPass, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
            else
            {
                string pass = txtPass.Text;
                if (txtPass.Text == "tec.huatabampo")
                {
                    if (FormPadre.admin == 0)
                    {
                        MessageBox.Show("Opciones avanzadas habilitadas");
                        FormPadre.MostrarOpciones();
                    }
                    else
                    {
                        MessageBox.Show("Opciones avanzadas deshabilitadas");
                        FormPadre.OcultarOpciones();
                    }


                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta");
                }
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            txtPass.Focus();
        }
    }
}
