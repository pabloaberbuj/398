namespace _398_UI
{
    partial class NuevoSistDos
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
            this.LB_Camara = new System.Windows.Forms.Label();
            this.LB_Electrometro = new System.Windows.Forms.Label();
            this.LB_FCal = new System.Windows.Forms.Label();
            this.LB_FechaCal = new System.Windows.Forms.Label();
            this.LB_LabCal = new System.Windows.Forms.Label();
            this.CB_Camara = new System.Windows.Forms.ComboBox();
            this.CB_Electrometro = new System.Windows.Forms.ComboBox();
            this.TB_FCal = new System.Windows.Forms.TextBox();
            this.LB_FCalUnidad = new System.Windows.Forms.Label();
            this.DTP_FechaCal = new System.Windows.Forms.DateTimePicker();
            this.LB_HazRef = new System.Windows.Forms.Label();
            this.LB_Temp = new System.Windows.Forms.Label();
            this.LB_Presion = new System.Windows.Forms.Label();
            this.LB_Humedad = new System.Windows.Forms.Label();
            this.TB_LabCal = new System.Windows.Forms.TextBox();
            this.CB_HazRef = new System.Windows.Forms.ComboBox();
            this.LB_TempUnid = new System.Windows.Forms.Label();
            this.TB_Temp = new System.Windows.Forms.TextBox();
            this.LB_PresionUnid = new System.Windows.Forms.Label();
            this.TB_Presion = new System.Windows.Forms.TextBox();
            this.LB_HumedadUnid = new System.Windows.Forms.Label();
            this.TB_Humedad = new System.Windows.Forms.TextBox();
            this.BT_Guardar = new System.Windows.Forms.Button();
            this.BT_Cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Tension = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_Tension = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LB_Camara
            // 
            this.LB_Camara.AutoSize = true;
            this.LB_Camara.Location = new System.Drawing.Point(25, 27);
            this.LB_Camara.Name = "LB_Camara";
            this.LB_Camara.Size = new System.Drawing.Size(56, 13);
            this.LB_Camara.TabIndex = 0;
            this.LB_Camara.Text = "Cámara (*)";
            // 
            // LB_Electrometro
            // 
            this.LB_Electrometro.AutoSize = true;
            this.LB_Electrometro.Location = new System.Drawing.Point(25, 54);
            this.LB_Electrometro.Name = "LB_Electrometro";
            this.LB_Electrometro.Size = new System.Drawing.Size(79, 13);
            this.LB_Electrometro.TabIndex = 1;
            this.LB_Electrometro.Text = "Electrómetro (*)";
            // 
            // LB_FCal
            // 
            this.LB_FCal.AutoSize = true;
            this.LB_FCal.Location = new System.Drawing.Point(25, 85);
            this.LB_FCal.Name = "LB_FCal";
            this.LB_FCal.Size = new System.Drawing.Size(119, 13);
            this.LB_FCal.TabIndex = 2;
            this.LB_FCal.Text = "Factor de calibración (*)";
            // 
            // LB_FechaCal
            // 
            this.LB_FechaCal.AutoSize = true;
            this.LB_FechaCal.Location = new System.Drawing.Point(27, 271);
            this.LB_FechaCal.Name = "LB_FechaCal";
            this.LB_FechaCal.Size = new System.Drawing.Size(106, 13);
            this.LB_FechaCal.TabIndex = 3;
            this.LB_FechaCal.Text = "Fecha de calibración";
            // 
            // LB_LabCal
            // 
            this.LB_LabCal.AutoSize = true;
            this.LB_LabCal.Location = new System.Drawing.Point(27, 305);
            this.LB_LabCal.Name = "LB_LabCal";
            this.LB_LabCal.Size = new System.Drawing.Size(72, 13);
            this.LB_LabCal.TabIndex = 4;
            this.LB_LabCal.Text = "Calibrada por:";
            // 
            // CB_Camara
            // 
            this.CB_Camara.FormattingEnabled = true;
            this.CB_Camara.Items.AddRange(new object[] {
            "marca,modelo,SN"});
            this.CB_Camara.Location = new System.Drawing.Point(165, 24);
            this.CB_Camara.Name = "CB_Camara";
            this.CB_Camara.Size = new System.Drawing.Size(173, 21);
            this.CB_Camara.TabIndex = 1;
            this.CB_Camara.Leave += new System.EventHandler(this.Leave_ObligatoriosparaGuardar);
            // 
            // CB_Electrometro
            // 
            this.CB_Electrometro.FormattingEnabled = true;
            this.CB_Electrometro.Items.AddRange(new object[] {
            "marca,modelo,SN"});
            this.CB_Electrometro.Location = new System.Drawing.Point(165, 51);
            this.CB_Electrometro.Name = "CB_Electrometro";
            this.CB_Electrometro.Size = new System.Drawing.Size(173, 21);
            this.CB_Electrometro.TabIndex = 2;
            this.CB_Electrometro.Leave += new System.EventHandler(this.Leave_ObligatoriosparaGuardar);
            // 
            // TB_FCal
            // 
            this.TB_FCal.Location = new System.Drawing.Point(165, 82);
            this.TB_FCal.Name = "TB_FCal";
            this.TB_FCal.Size = new System.Drawing.Size(121, 20);
            this.TB_FCal.TabIndex = 3;
            this.TB_FCal.Leave += new System.EventHandler(this.Leave_EsNumeroObligatoriosparaGuardar);
            // 
            // LB_FCalUnidad
            // 
            this.LB_FCalUnidad.AutoSize = true;
            this.LB_FCalUnidad.Location = new System.Drawing.Point(292, 85);
            this.LB_FCalUnidad.Name = "LB_FCalUnidad";
            this.LB_FCalUnidad.Size = new System.Drawing.Size(46, 13);
            this.LB_FCalUnidad.TabIndex = 8;
            this.LB_FCalUnidad.Text = "mGy/nC";
            // 
            // DTP_FechaCal
            // 
            this.DTP_FechaCal.Location = new System.Drawing.Point(167, 271);
            this.DTP_FechaCal.Name = "DTP_FechaCal";
            this.DTP_FechaCal.Size = new System.Drawing.Size(173, 20);
            this.DTP_FechaCal.TabIndex = 10;
            // 
            // LB_HazRef
            // 
            this.LB_HazRef.AutoSize = true;
            this.LB_HazRef.Location = new System.Drawing.Point(25, 155);
            this.LB_HazRef.Name = "LB_HazRef";
            this.LB_HazRef.Size = new System.Drawing.Size(104, 13);
            this.LB_HazRef.TabIndex = 10;
            this.LB_HazRef.Text = "Haz de referencia (*)";
            // 
            // LB_Temp
            // 
            this.LB_Temp.AutoSize = true;
            this.LB_Temp.Location = new System.Drawing.Point(27, 186);
            this.LB_Temp.Name = "LB_Temp";
            this.LB_Temp.Size = new System.Drawing.Size(80, 13);
            this.LB_Temp.TabIndex = 11;
            this.LB_Temp.Text = "Temperatura (*)";
            // 
            // LB_Presion
            // 
            this.LB_Presion.AutoSize = true;
            this.LB_Presion.Location = new System.Drawing.Point(27, 212);
            this.LB_Presion.Name = "LB_Presion";
            this.LB_Presion.Size = new System.Drawing.Size(55, 13);
            this.LB_Presion.TabIndex = 12;
            this.LB_Presion.Text = "Presión (*)";
            // 
            // LB_Humedad
            // 
            this.LB_Humedad.AutoSize = true;
            this.LB_Humedad.Location = new System.Drawing.Point(27, 238);
            this.LB_Humedad.Name = "LB_Humedad";
            this.LB_Humedad.Size = new System.Drawing.Size(53, 13);
            this.LB_Humedad.TabIndex = 13;
            this.LB_Humedad.Text = "Humedad";
            // 
            // TB_LabCal
            // 
            this.TB_LabCal.Location = new System.Drawing.Point(167, 302);
            this.TB_LabCal.Name = "TB_LabCal";
            this.TB_LabCal.Size = new System.Drawing.Size(173, 20);
            this.TB_LabCal.TabIndex = 11;
            // 
            // CB_HazRef
            // 
            this.CB_HazRef.FormattingEnabled = true;
            this.CB_HazRef.Items.AddRange(new object[] {
            "Co-60"});
            this.CB_HazRef.Location = new System.Drawing.Point(166, 152);
            this.CB_HazRef.Name = "CB_HazRef";
            this.CB_HazRef.Size = new System.Drawing.Size(173, 21);
            this.CB_HazRef.TabIndex = 6;
            this.CB_HazRef.Leave += new System.EventHandler(this.Leave_ObligatoriosparaGuardar);
            // 
            // LB_TempUnid
            // 
            this.LB_TempUnid.AutoSize = true;
            this.LB_TempUnid.Location = new System.Drawing.Point(275, 186);
            this.LB_TempUnid.Name = "LB_TempUnid";
            this.LB_TempUnid.Size = new System.Drawing.Size(18, 13);
            this.LB_TempUnid.TabIndex = 17;
            this.LB_TempUnid.Text = "ºC";
            // 
            // TB_Temp
            // 
            this.TB_Temp.Location = new System.Drawing.Point(166, 183);
            this.TB_Temp.Name = "TB_Temp";
            this.TB_Temp.Size = new System.Drawing.Size(94, 20);
            this.TB_Temp.TabIndex = 7;
            this.TB_Temp.Leave += new System.EventHandler(this.Leave_EsNumeroObligatoriosparaGuardar);
            // 
            // LB_PresionUnid
            // 
            this.LB_PresionUnid.AutoSize = true;
            this.LB_PresionUnid.Location = new System.Drawing.Point(275, 212);
            this.LB_PresionUnid.Name = "LB_PresionUnid";
            this.LB_PresionUnid.Size = new System.Drawing.Size(26, 13);
            this.LB_PresionUnid.TabIndex = 19;
            this.LB_PresionUnid.Text = "hPa";
            // 
            // TB_Presion
            // 
            this.TB_Presion.Location = new System.Drawing.Point(166, 209);
            this.TB_Presion.Name = "TB_Presion";
            this.TB_Presion.Size = new System.Drawing.Size(94, 20);
            this.TB_Presion.TabIndex = 8;
            this.TB_Presion.Leave += new System.EventHandler(this.Leave_EsNumeroObligatoriosparaGuardar);
            // 
            // LB_HumedadUnid
            // 
            this.LB_HumedadUnid.AutoSize = true;
            this.LB_HumedadUnid.Location = new System.Drawing.Point(275, 238);
            this.LB_HumedadUnid.Name = "LB_HumedadUnid";
            this.LB_HumedadUnid.Size = new System.Drawing.Size(15, 13);
            this.LB_HumedadUnid.TabIndex = 21;
            this.LB_HumedadUnid.Text = "%";
            // 
            // TB_Humedad
            // 
            this.TB_Humedad.Location = new System.Drawing.Point(166, 235);
            this.TB_Humedad.Name = "TB_Humedad";
            this.TB_Humedad.Size = new System.Drawing.Size(94, 20);
            this.TB_Humedad.TabIndex = 9;
            this.TB_Humedad.Leave += new System.EventHandler(this.TB_EsNumero);
            // 
            // BT_Guardar
            // 
            this.BT_Guardar.Enabled = false;
            this.BT_Guardar.Location = new System.Drawing.Point(29, 374);
            this.BT_Guardar.Name = "BT_Guardar";
            this.BT_Guardar.Size = new System.Drawing.Size(128, 23);
            this.BT_Guardar.TabIndex = 12;
            this.BT_Guardar.Text = "Guardar";
            this.BT_Guardar.UseVisualStyleBackColor = true;
            this.BT_Guardar.Click += new System.EventHandler(this.BT_Guardar_Click);
            // 
            // BT_Cancelar
            // 
            this.BT_Cancelar.Location = new System.Drawing.Point(202, 374);
            this.BT_Cancelar.Name = "BT_Cancelar";
            this.BT_Cancelar.Size = new System.Drawing.Size(136, 23);
            this.BT_Cancelar.TabIndex = 13;
            this.BT_Cancelar.Text = "Cancelar";
            this.BT_Cancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "V";
            // 
            // TB_Tension
            // 
            this.TB_Tension.Location = new System.Drawing.Point(212, 116);
            this.TB_Tension.Name = "TB_Tension";
            this.TB_Tension.Size = new System.Drawing.Size(74, 20);
            this.TB_Tension.TabIndex = 5;
            this.TB_Tension.Leave += new System.EventHandler(this.Leave_EsNumeroObligatoriosparaGuardar);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Tensión(*)";
            // 
            // CB_Tension
            // 
            this.CB_Tension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Tension.FormattingEnabled = true;
            this.CB_Tension.Items.AddRange(new object[] {
            "+",
            "-"});
            this.CB_Tension.Location = new System.Drawing.Point(165, 116);
            this.CB_Tension.Name = "CB_Tension";
            this.CB_Tension.Size = new System.Drawing.Size(41, 21);
            this.CB_Tension.TabIndex = 4;
            this.CB_Tension.Leave += new System.EventHandler(this.Leave_ObligatoriosparaGuardar);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "(*) Obligatorios";
            // 
            // NuevoSistDos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 409);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CB_Tension);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_Tension);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BT_Cancelar);
            this.Controls.Add(this.BT_Guardar);
            this.Controls.Add(this.LB_HumedadUnid);
            this.Controls.Add(this.TB_Humedad);
            this.Controls.Add(this.LB_PresionUnid);
            this.Controls.Add(this.TB_Presion);
            this.Controls.Add(this.LB_TempUnid);
            this.Controls.Add(this.TB_Temp);
            this.Controls.Add(this.CB_HazRef);
            this.Controls.Add(this.TB_LabCal);
            this.Controls.Add(this.LB_Humedad);
            this.Controls.Add(this.LB_Presion);
            this.Controls.Add(this.LB_Temp);
            this.Controls.Add(this.LB_HazRef);
            this.Controls.Add(this.DTP_FechaCal);
            this.Controls.Add(this.LB_FCalUnidad);
            this.Controls.Add(this.TB_FCal);
            this.Controls.Add(this.CB_Electrometro);
            this.Controls.Add(this.CB_Camara);
            this.Controls.Add(this.LB_LabCal);
            this.Controls.Add(this.LB_FechaCal);
            this.Controls.Add(this.LB_FCal);
            this.Controls.Add(this.LB_Electrometro);
            this.Controls.Add(this.LB_Camara);
            this.Name = "NuevoSistDos";
            this.Text = "NuevoSistDos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_Camara;
        private System.Windows.Forms.Label LB_Electrometro;
        private System.Windows.Forms.Label LB_FCal;
        private System.Windows.Forms.Label LB_FechaCal;
        private System.Windows.Forms.Label LB_LabCal;
        private System.Windows.Forms.ComboBox CB_Camara;
        private System.Windows.Forms.ComboBox CB_Electrometro;
        private System.Windows.Forms.TextBox TB_FCal;
        private System.Windows.Forms.Label LB_FCalUnidad;
        private System.Windows.Forms.DateTimePicker DTP_FechaCal;
        private System.Windows.Forms.Label LB_HazRef;
        private System.Windows.Forms.Label LB_Temp;
        private System.Windows.Forms.Label LB_Presion;
        private System.Windows.Forms.Label LB_Humedad;
        private System.Windows.Forms.TextBox TB_LabCal;
        private System.Windows.Forms.ComboBox CB_HazRef;
        private System.Windows.Forms.Label LB_TempUnid;
        private System.Windows.Forms.TextBox TB_Temp;
        private System.Windows.Forms.Label LB_PresionUnid;
        private System.Windows.Forms.TextBox TB_Presion;
        private System.Windows.Forms.Label LB_HumedadUnid;
        private System.Windows.Forms.TextBox TB_Humedad;
        private System.Windows.Forms.Button BT_Guardar;
        private System.Windows.Forms.Button BT_Cancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Tension;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_Tension;
        private System.Windows.Forms.Label label3;
    }
}