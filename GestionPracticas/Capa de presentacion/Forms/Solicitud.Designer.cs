namespace GestionPracticas.Forms
{
    partial class Solicitud
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.fechaSolicitud = new System.Windows.Forms.DateTimePicker();
            this.fechaRealizacion = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombrePractica = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMateria = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNoAlumnos = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.dateHora = new System.Windows.Forms.DateTimePicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipError = new System.Windows.Forms.ToolTip(this.components);
            this.comboArea = new System.Windows.Forms.ComboBox();
            this.comboLabo = new System.Windows.Forms.ComboBox();
            this.comboProfe = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(371, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha solicitud";
            // 
            // fechaSolicitud
            // 
            this.fechaSolicitud.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fechaSolicitud.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaSolicitud.Location = new System.Drawing.Point(448, 22);
            this.fechaSolicitud.Margin = new System.Windows.Forms.Padding(2);
            this.fechaSolicitud.Name = "fechaSolicitud";
            this.fechaSolicitud.Size = new System.Drawing.Size(85, 20);
            this.fechaSolicitud.TabIndex = 10;
            // 
            // fechaRealizacion
            // 
            this.fechaRealizacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaRealizacion.Location = new System.Drawing.Point(120, 75);
            this.fechaRealizacion.Margin = new System.Windows.Forms.Padding(2);
            this.fechaRealizacion.Name = "fechaRealizacion";
            this.fechaRealizacion.Size = new System.Drawing.Size(85, 20);
            this.fechaRealizacion.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha realización";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hora";
            // 
            // txtNombrePractica
            // 
            this.txtNombrePractica.Location = new System.Drawing.Point(120, 156);
            this.txtNombrePractica.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombrePractica.MaxLength = 100;
            this.txtNombrePractica.Name = "txtNombrePractica";
            this.txtNombrePractica.Size = new System.Drawing.Size(412, 20);
            this.txtNombrePractica.TabIndex = 2;
            this.txtNombrePractica.TextChanged += new System.EventHandler(this.txtNombrePractica_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 158);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nombre de la practica";
            // 
            // txtMateria
            // 
            this.txtMateria.Location = new System.Drawing.Point(120, 178);
            this.txtMateria.Margin = new System.Windows.Forms.Padding(2);
            this.txtMateria.MaxLength = 100;
            this.txtMateria.Name = "txtMateria";
            this.txtMateria.Size = new System.Drawing.Size(412, 20);
            this.txtMateria.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 183);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Materia";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 204);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Carrera";
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(120, 224);
            this.txtGrupo.Margin = new System.Windows.Forms.Padding(2);
            this.txtGrupo.MaxLength = 50;
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(208, 20);
            this.txtGrupo.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 227);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Grupo/Semestre";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 249);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Laboratorio/taller";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 272);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Docente solicitante";
            // 
            // txtNoAlumnos
            // 
            this.txtNoAlumnos.Location = new System.Drawing.Point(447, 223);
            this.txtNoAlumnos.Margin = new System.Windows.Forms.Padding(2);
            this.txtNoAlumnos.MaxLength = 5;
            this.txtNoAlumnos.Name = "txtNoAlumnos";
            this.txtNoAlumnos.Size = new System.Drawing.Size(85, 20);
            this.txtNoAlumnos.TabIndex = 6;
            this.txtNoAlumnos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoAlumnos_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(361, 225);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "No. de alumnos";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrar.Location = new System.Drawing.Point(447, 315);
            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(85, 39);
            this.btnRegistrar.TabIndex = 22;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateHora
            // 
            this.dateHora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateHora.Location = new System.Drawing.Point(448, 75);
            this.dateHora.Margin = new System.Windows.Forms.Padding(2);
            this.dateHora.Name = "dateHora";
            this.dateHora.Size = new System.Drawing.Size(85, 20);
            this.dateHora.TabIndex = 11;
            // 
            // toolTipError
            // 
            this.toolTipError.BackColor = System.Drawing.Color.Firebrick;
            // 
            // comboArea
            // 
            this.comboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboArea.FormattingEnabled = true;
            this.comboArea.Location = new System.Drawing.Point(120, 200);
            this.comboArea.Margin = new System.Windows.Forms.Padding(2);
            this.comboArea.Name = "comboArea";
            this.comboArea.Size = new System.Drawing.Size(412, 21);
            this.comboArea.TabIndex = 4;
            this.comboArea.SelectedIndexChanged += new System.EventHandler(this.comboArea_SelectedIndexChanged);
            // 
            // comboLabo
            // 
            this.comboLabo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLabo.FormattingEnabled = true;
            this.comboLabo.Location = new System.Drawing.Point(120, 246);
            this.comboLabo.Margin = new System.Windows.Forms.Padding(2);
            this.comboLabo.Name = "comboLabo";
            this.comboLabo.Size = new System.Drawing.Size(412, 21);
            this.comboLabo.TabIndex = 7;
            // 
            // comboProfe
            // 
            this.comboProfe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProfe.Enabled = false;
            this.comboProfe.FormattingEnabled = true;
            this.comboProfe.Location = new System.Drawing.Point(120, 270);
            this.comboProfe.Margin = new System.Windows.Forms.Padding(2);
            this.comboProfe.Name = "comboProfe";
            this.comboProfe.Size = new System.Drawing.Size(412, 21);
            this.comboProfe.TabIndex = 8;
            // 
            // Solicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 363);
            this.Controls.Add(this.comboProfe);
            this.Controls.Add(this.comboLabo);
            this.Controls.Add(this.comboArea);
            this.Controls.Add(this.dateHora);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtNoAlumnos);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtGrupo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMateria);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNombrePractica);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fechaRealizacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fechaSolicitud);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Solicitud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker fechaSolicitud;
        private System.Windows.Forms.DateTimePicker fechaRealizacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombrePractica;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMateria;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNoAlumnos;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.DateTimePicker dateHora;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTipError;
        private System.Windows.Forms.ComboBox comboArea;
        private System.Windows.Forms.ComboBox comboLabo;
        private System.Windows.Forms.ComboBox comboProfe;
    }
}