using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using GestionPracticas.Capa_de_negocio.Clases;

namespace GestionPracticas.Forms
{
    public partial class Guia3 : Form
    {
        public Guia3()
        {
            InitializeComponent();
        }
        public Main FormPadre;
        public Guia2 Guia2;
        private void button1_Click(object sender, EventArgs e)
        {
            Capa_de_negocio.Guia GuiaNegocio = new Capa_de_negocio.Guia();
            string departamento = Guia2.Guia1.departamento;
            string nopractica = Guia2.Guia1.nopractica;
            string unidad = Guia2.Guia1.unidad;
            string personaelabora = Guia2.Guia1.personaelabora;
            string personarevisa = Guia2.Guia1.personarevisa;
            string personaautoriza = Guia2.Guia1.personaautoriza;
            string objetivo = Guia2.objetivos;
            string introduccion = Guia2.introduccion;
            string material = Guia2.material;
            string condicionesseguridad = Guia2.condicionesseguridad;
            string peligros = Guia2.peligrosincidentes;
            string respuestacontingencia = Guia2.respuestacontingencia;
            string desarrolloexperimental = txtboxDesarrollo.Text;
            string cuestionario = txtboxCuestionario.Text;
            string tiporesiduos = txtTipoResiduo.Text;
            string tratamientoresiduos = txtTratamientoResiduo.Text;
            string disposicionresiduos = txtDisposicionResiduo.Text;
            string actividadescomplementarias = txtboxActividadesComplementarias.Text;
            string bibliografia = txtboxBibliografia.Text;

            if (txtboxDesarrollo.TextLength < 1)
            {
                toolTip1.Show("Campo vacío.", txtboxDesarrollo, 0, -20, 2000); // Puedes personalizar la posición y la duración del ToolTip.
            }
            else
            {
                Accion accion = GuiaNegocio.Crear(departamento, nopractica, unidad, personaelabora, personarevisa, personaautoriza, objetivo, introduccion, material, condicionesseguridad, peligros, respuestacontingencia, desarrolloexperimental, cuestionario, tiporesiduos, tratamientoresiduos, disposicionresiduos, actividadescomplementarias, bibliografia);
                if (accion.Realizada)
                {
                    MessageBox.Show("Guia registrada con exito.");
                    //Pasar a la siguiente hoja
                    Main test = FormPadre;

                    Forms.ListaPracticas Frm = new Forms.ListaPracticas();
                    Frm.FormPadre = this.FormPadre;
                    Frm.SetBtnText("Guia >>>");
                    Frm.BtnTxt = "Guia >>>";
                    Frm.destino = 2;
                    test.AgregarForm(Frm, "Lista Practicas (Guia)");
                }
            }

            
        }
    }
}
