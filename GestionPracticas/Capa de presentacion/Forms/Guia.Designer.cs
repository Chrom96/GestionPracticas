namespace GestionPracticas.Forms
{
    partial class Guia
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtnoUnidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnoPractica = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPersonaAutoriza = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPersonaRevisa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPersonaElabora = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboDepa = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Departamento de";
            // 
            // txtnoUnidad
            // 
            this.txtnoUnidad.Location = new System.Drawing.Point(122, 61);
            this.txtnoUnidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtnoUnidad.MaxLength = 4;
            this.txtnoUnidad.Name = "txtnoUnidad";
            this.txtnoUnidad.Size = new System.Drawing.Size(72, 20);
            this.txtnoUnidad.TabIndex = 13;
            this.txtnoUnidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnoUnidad_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Unidad no.";
            // 
            // txtnoPractica
            // 
            this.txtnoPractica.Location = new System.Drawing.Point(122, 37);
            this.txtnoPractica.Margin = new System.Windows.Forms.Padding(2);
            this.txtnoPractica.MaxLength = 10;
            this.txtnoPractica.Name = "txtnoPractica";
            this.txtnoPractica.Size = new System.Drawing.Size(72, 20);
            this.txtnoPractica.TabIndex = 15;
            this.txtnoPractica.TextChanged += new System.EventHandler(this.txtnoPractica_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Practica no.";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtPersonaAutoriza);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPersonaRevisa);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtPersonaElabora);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(11, 155);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(512, 120);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Persona que...";
            // 
            // txtPersonaAutoriza
            // 
            this.txtPersonaAutoriza.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPersonaAutoriza.Location = new System.Drawing.Point(64, 87);
            this.txtPersonaAutoriza.Margin = new System.Windows.Forms.Padding(2);
            this.txtPersonaAutoriza.MaxLength = 200;
            this.txtPersonaAutoriza.Name = "txtPersonaAutoriza";
            this.txtPersonaAutoriza.Size = new System.Drawing.Size(442, 20);
            this.txtPersonaAutoriza.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 90);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Autoriza";
            // 
            // txtPersonaRevisa
            // 
            this.txtPersonaRevisa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPersonaRevisa.Location = new System.Drawing.Point(64, 55);
            this.txtPersonaRevisa.Margin = new System.Windows.Forms.Padding(2);
            this.txtPersonaRevisa.MaxLength = 200;
            this.txtPersonaRevisa.Name = "txtPersonaRevisa";
            this.txtPersonaRevisa.Size = new System.Drawing.Size(442, 20);
            this.txtPersonaRevisa.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 57);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Revisa";
            // 
            // txtPersonaElabora
            // 
            this.txtPersonaElabora.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPersonaElabora.Location = new System.Drawing.Point(64, 22);
            this.txtPersonaElabora.Margin = new System.Windows.Forms.Padding(2);
            this.txtPersonaElabora.MaxLength = 200;
            this.txtPersonaElabora.Name = "txtPersonaElabora";
            this.txtPersonaElabora.Size = new System.Drawing.Size(442, 20);
            this.txtPersonaElabora.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Elabora";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(437, 336);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 31);
            this.button1.TabIndex = 19;
            this.button1.Text = "Siguiente >>>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboDepa
            // 
            this.comboDepa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDepa.FormattingEnabled = true;
            this.comboDepa.Location = new System.Drawing.Point(127, 103);
            this.comboDepa.Margin = new System.Windows.Forms.Padding(2);
            this.comboDepa.Name = "comboDepa";
            this.comboDepa.Size = new System.Drawing.Size(390, 21);
            this.comboDepa.TabIndex = 20;
            // 
            // Guia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 378);
            this.Controls.Add(this.comboDepa);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtnoPractica);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtnoUnidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Guia";
            this.Text = "Guia";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtnoUnidad;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtnoPractica;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtPersonaElabora;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtPersonaAutoriza;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtPersonaRevisa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboDepa;
    }
}