namespace GestionPracticas.Forms
{
    partial class Guia2
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
            this.txtboxObjetivo = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tablaMaterial = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtboxIntroduccion = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCondicionesSeguridad = new System.Windows.Forms.TextBox();
            this.txtPeligros = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRespuestaContingencia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tablaMaterial)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Objetivo(s) de la practica";
            // 
            // txtboxObjetivo
            // 
            this.txtboxObjetivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxObjetivo.Location = new System.Drawing.Point(9, 26);
            this.txtboxObjetivo.Margin = new System.Windows.Forms.Padding(2);
            this.txtboxObjetivo.MaxLength = 1000;
            this.txtboxObjetivo.Name = "txtboxObjetivo";
            this.txtboxObjetivo.Size = new System.Drawing.Size(528, 56);
            this.txtboxObjetivo.TabIndex = 1;
            this.txtboxObjetivo.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Introducción (Fundamento teorico)";
            // 
            // tablaMaterial
            // 
            this.tablaMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cantidad,
            this.Descripcion});
            this.tablaMaterial.Location = new System.Drawing.Point(9, 172);
            this.tablaMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.tablaMaterial.Name = "tablaMaterial";
            this.tablaMaterial.RowHeadersWidth = 51;
            this.tablaMaterial.RowTemplate.Height = 24;
            this.tablaMaterial.Size = new System.Drawing.Size(527, 104);
            this.tablaMaterial.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 157);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Material y/o equipo empleado";
            // 
            // txtboxIntroduccion
            // 
            this.txtboxIntroduccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxIntroduccion.Location = new System.Drawing.Point(9, 99);
            this.txtboxIntroduccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtboxIntroduccion.MaxLength = 1000;
            this.txtboxIntroduccion.Name = "txtboxIntroduccion";
            this.txtboxIntroduccion.Size = new System.Drawing.Size(528, 56);
            this.txtboxIntroduccion.TabIndex = 6;
            this.txtboxIntroduccion.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 279);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(284, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Condiciones de seguridad para la realización de la practica";
            // 
            // txtCondicionesSeguridad
            // 
            this.txtCondicionesSeguridad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCondicionesSeguridad.Location = new System.Drawing.Point(9, 294);
            this.txtCondicionesSeguridad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCondicionesSeguridad.MaxLength = 200;
            this.txtCondicionesSeguridad.Name = "txtCondicionesSeguridad";
            this.txtCondicionesSeguridad.Size = new System.Drawing.Size(528, 20);
            this.txtCondicionesSeguridad.TabIndex = 8;
            // 
            // txtPeligros
            // 
            this.txtPeligros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPeligros.Location = new System.Drawing.Point(9, 330);
            this.txtPeligros.Margin = new System.Windows.Forms.Padding(2);
            this.txtPeligros.MaxLength = 200;
            this.txtPeligros.Name = "txtPeligros";
            this.txtPeligros.Size = new System.Drawing.Size(528, 20);
            this.txtPeligros.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 314);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(282, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Peligros o incidentes en el manejo inadecuado de insumos";
            // 
            // txtRespuestaContingencia
            // 
            this.txtRespuestaContingencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRespuestaContingencia.Location = new System.Drawing.Point(9, 366);
            this.txtRespuestaContingencia.Margin = new System.Windows.Forms.Padding(2);
            this.txtRespuestaContingencia.MaxLength = 200;
            this.txtRespuestaContingencia.Name = "txtRespuestaContingencia";
            this.txtRespuestaContingencia.Size = new System.Drawing.Size(528, 20);
            this.txtRespuestaContingencia.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 350);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(219, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Respuesta ante contingencia de emergencia";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(453, 400);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 30);
            this.button1.TabIndex = 13;
            this.button1.Text = "Siguiente >>>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MaxInputLength = 9;
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 90;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.MaxInputLength = 100;
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 250;
            // 
            // Guia2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 441);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtRespuestaContingencia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPeligros);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCondicionesSeguridad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtboxIntroduccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tablaMaterial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtboxObjetivo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Guia2";
            this.Text = "Guia2";
            ((System.ComponentModel.ISupportInitialize)(this.tablaMaterial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.RichTextBox txtboxObjetivo;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView tablaMaterial;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.RichTextBox txtboxIntroduccion;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtCondicionesSeguridad;
        public System.Windows.Forms.TextBox txtPeligros;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtRespuestaContingencia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
    }
}