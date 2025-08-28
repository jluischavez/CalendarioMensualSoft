namespace CalendarioMensualSoft
{
    partial class FrmCaptura
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDia = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.TxtYear = new System.Windows.Forms.TextBox();
            this.CBMes = new System.Windows.Forms.ComboBox();
            this.CBDias = new System.Windows.Forms.ComboBox();
            this.GPFechaInicio = new System.Windows.Forms.GroupBox();
            this.lblDiasAMostrar = new System.Windows.Forms.Label();
            this.txtDiasAMostrar = new System.Windows.Forms.TextBox();
            this.btnGenerarCalendario = new System.Windows.Forms.Button();
            this.GPFechaInicio.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDia
            // 
            this.lblDia.AutoSize = true;
            this.lblDia.Location = new System.Drawing.Point(311, 21);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(27, 15);
            this.lblDia.TabIndex = 0;
            this.lblDia.Text = "Día:";
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(83, 21);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(32, 15);
            this.lblMes.TabIndex = 1;
            this.lblMes.Text = "Mes:";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(205, 21);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(32, 15);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "Año:";
            // 
            // TxtYear
            // 
            this.TxtYear.Location = new System.Drawing.Point(205, 39);
            this.TxtYear.MaxLength = 4;
            this.TxtYear.Name = "TxtYear";
            this.TxtYear.Size = new System.Drawing.Size(100, 23);
            this.TxtYear.TabIndex = 2;
            // 
            // CBMes
            // 
            this.CBMes.FormattingEnabled = true;
            this.CBMes.Location = new System.Drawing.Point(78, 39);
            this.CBMes.Name = "CBMes";
            this.CBMes.Size = new System.Drawing.Size(121, 23);
            this.CBMes.TabIndex = 1;
            // 
            // CBDias
            // 
            this.CBDias.FormattingEnabled = true;
            this.CBDias.Location = new System.Drawing.Point(311, 39);
            this.CBDias.Name = "CBDias";
            this.CBDias.Size = new System.Drawing.Size(52, 23);
            this.CBDias.TabIndex = 3;
            // 
            // GPFechaInicio
            // 
            this.GPFechaInicio.Controls.Add(this.lblDiasAMostrar);
            this.GPFechaInicio.Controls.Add(this.txtDiasAMostrar);
            this.GPFechaInicio.Controls.Add(this.CBDias);
            this.GPFechaInicio.Controls.Add(this.lblDia);
            this.GPFechaInicio.Controls.Add(this.CBMes);
            this.GPFechaInicio.Controls.Add(this.lblMes);
            this.GPFechaInicio.Controls.Add(this.TxtYear);
            this.GPFechaInicio.Controls.Add(this.lblYear);
            this.GPFechaInicio.Location = new System.Drawing.Point(12, 12);
            this.GPFechaInicio.Name = "GPFechaInicio";
            this.GPFechaInicio.Size = new System.Drawing.Size(488, 126);
            this.GPFechaInicio.TabIndex = 1;
            this.GPFechaInicio.TabStop = false;
            this.GPFechaInicio.Text = "Captura: ";
            // 
            // lblDiasAMostrar
            // 
            this.lblDiasAMostrar.AutoSize = true;
            this.lblDiasAMostrar.Location = new System.Drawing.Point(111, 95);
            this.lblDiasAMostrar.Name = "lblDiasAMostrar";
            this.lblDiasAMostrar.Size = new System.Drawing.Size(85, 15);
            this.lblDiasAMostrar.TabIndex = 9;
            this.lblDiasAMostrar.Text = "Días a mostrar:";
            // 
            // txtDiasAMostrar
            // 
            this.txtDiasAMostrar.Location = new System.Drawing.Point(202, 92);
            this.txtDiasAMostrar.MaxLength = 4;
            this.txtDiasAMostrar.Name = "txtDiasAMostrar";
            this.txtDiasAMostrar.Size = new System.Drawing.Size(100, 23);
            this.txtDiasAMostrar.TabIndex = 4;
            // 
            // btnGenerarCalendario
            // 
            this.btnGenerarCalendario.Location = new System.Drawing.Point(194, 151);
            this.btnGenerarCalendario.Name = "btnGenerarCalendario";
            this.btnGenerarCalendario.Size = new System.Drawing.Size(123, 23);
            this.btnGenerarCalendario.TabIndex = 2;
            this.btnGenerarCalendario.Text = "Generar Calendario";
            this.btnGenerarCalendario.UseVisualStyleBackColor = true;
            this.btnGenerarCalendario.Click += new System.EventHandler(this.btnGenerarCalendario_Click);
            // 
            // FrmCaptura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 186);
            this.Controls.Add(this.btnGenerarCalendario);
            this.Controls.Add(this.GPFechaInicio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmCaptura";
            this.ShowIcon = false;
            this.Text = "Calendario de días calculados.";
            this.GPFechaInicio.ResumeLayout(false);
            this.GPFechaInicio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblDia;
        private Label lblMes;
        private Label lblYear;
        private TextBox TxtYear;
        private ComboBox CBMes;
        private ComboBox CBDias;
        private GroupBox GPFechaInicio;
        private Label lblDiasAMostrar;
        private TextBox txtDiasAMostrar;
        private Button btnGenerarCalendario;
    }
}