namespace GestionPracticas.Forms_1_
{
    partial class GenerarReportes
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.radioGuia = new System.Windows.Forms.RadioButton();
            this.radioAsistencias = new System.Windows.Forms.RadioButton();
            this.radioSolicitud = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.txtBuscar);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(11, 95);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(473, 335);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Practicas";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 40);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(465, 280);
            this.dataGridView1.TabIndex = 4;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(84, 17);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscar.MaxLength = 80;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(379, 20);
            this.txtBuscar.TabIndex = 3;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Buscar";
            // 
            // radioGuia
            // 
            this.radioGuia.AutoSize = true;
            this.radioGuia.Location = new System.Drawing.Point(182, 76);
            this.radioGuia.Name = "radioGuia";
            this.radioGuia.Size = new System.Drawing.Size(47, 17);
            this.radioGuia.TabIndex = 29;
            this.radioGuia.Text = "Guia";
            this.radioGuia.UseVisualStyleBackColor = true;
            // 
            // radioAsistencias
            // 
            this.radioAsistencias.AutoSize = true;
            this.radioAsistencias.Location = new System.Drawing.Point(182, 52);
            this.radioAsistencias.Name = "radioAsistencias";
            this.radioAsistencias.Size = new System.Drawing.Size(78, 17);
            this.radioAsistencias.TabIndex = 28;
            this.radioAsistencias.Text = "Asistencias";
            this.radioAsistencias.UseVisualStyleBackColor = true;
            // 
            // radioSolicitud
            // 
            this.radioSolicitud.AutoSize = true;
            this.radioSolicitud.Checked = true;
            this.radioSolicitud.Location = new System.Drawing.Point(182, 28);
            this.radioSolicitud.Name = "radioSolicitud";
            this.radioSolicitud.Size = new System.Drawing.Size(65, 17);
            this.radioSolicitud.TabIndex = 27;
            this.radioSolicitud.TabStop = true;
            this.radioSolicitud.Text = "Solicitud";
            this.radioSolicitud.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(279, 28);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 65);
            this.button1.TabIndex = 26;
            this.button1.Text = "Imprimir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // GenerarReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 442);
            this.Controls.Add(this.radioGuia);
            this.Controls.Add(this.radioAsistencias);
            this.Controls.Add(this.radioSolicitud);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GenerarReportes";
            this.Text = "ReportearSolicitud";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioGuia;
        private System.Windows.Forms.RadioButton radioAsistencias;
        private System.Windows.Forms.RadioButton radioSolicitud;
        private System.Windows.Forms.Button button1;
    }
}