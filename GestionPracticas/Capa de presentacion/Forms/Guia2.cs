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
    public partial class Guia2 : Form
    {
        public Guia2()
        {
            InitializeComponent();
        }
        public Main FormPadre;
        public Guia Guia1;

        public string objetivos;
        public string introduccion;
        public string material;
        public string condicionesseguridad;
        public string peligrosincidentes;
        public string respuestacontingencia;

        private void button1_Click(object sender, EventArgs e)
        {
            Capa_de_negocio.Guia GuiaNegocio = new Capa_de_negocio.Guia();
            objetivos = txtboxObjetivo.Text;
            introduccion = txtboxIntroduccion.Text;
            material = GuiaNegocio.ConvertirDataGrid(tablaMaterial);
            condicionesseguridad = txtCondicionesSeguridad.Text;
            peligrosincidentes = txtPeligros.Text;
            respuestacontingencia = txtRespuestaContingencia.Text;

            if (txtboxObjetivo.TextLength < 1)
            {
                toolTip1.Show("Campo vacío.", txtboxObjetivo, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }else if (txtboxIntroduccion.TextLength < 1)
            {
                toolTip1.Show("Campo vacío.", txtboxIntroduccion, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }else
            {
                Main test = FormPadre;
                Forms.Guia3 Frm = new Forms.Guia3();
                Frm.FormPadre = this.FormPadre;
                Frm.Guia2 = this;
                test.AgregarForm(Frm, "Guia 3/3");
            }

            
        }
    }
}
