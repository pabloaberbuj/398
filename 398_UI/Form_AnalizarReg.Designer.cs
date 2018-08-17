namespace _398_UI
{
    partial class Form_AnalizarReg
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AnalizarReg));
            this.Panel_AnalizarReg = new System.Windows.Forms.Panel();
            this.BT_ExportarLista = new System.Windows.Forms.Button();
            this.GB_Tendencia = new System.Windows.Forms.GroupBox();
            this.L_Tendencia = new System.Windows.Forms.Label();
            this.BT_AnalisisTendencia = new System.Windows.Forms.Button();
            this.CHB_RangoTendencia = new System.Windows.Forms.CheckBox();
            this.L_TendenciaHasta = new System.Windows.Forms.Label();
            this.L_TendenciaDesde = new System.Windows.Forms.Label();
            this.DTP_TendenciaHasta = new System.Windows.Forms.DateTimePicker();
            this.DTP_TendenciaDesde = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.BT_Imprimir = new System.Windows.Forms.Button();
            this.BT_VPImpresion = new System.Windows.Forms.Button();
            this.BT_Referencia = new System.Windows.Forms.Button();
            this.BT_Importar = new System.Windows.Forms.Button();
            this.BT_Exportar = new System.Windows.Forms.Button();
            this.Chart_Registros = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BtAnalizar = new System.Windows.Forms.Button();
            this.GB_DFSoISO = new System.Windows.Forms.GroupBox();
            this.RB_Iso = new System.Windows.Forms.RadioButton();
            this.RB_DFSFija = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label94 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.CB_EnergiaElec = new System.Windows.Forms.ComboBox();
            this.CB_EnergiaFot = new System.Windows.Forms.ComboBox();
            this.RB_EnergiaElec = new System.Windows.Forms.RadioButton();
            this.RB_EnergiaFot = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ListBox_Equipos = new System.Windows.Forms.ListBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.CHB_Rango = new System.Windows.Forms.CheckBox();
            this.L_FechaHasta = new System.Windows.Forms.Label();
            this.L_FechaDesde = new System.Windows.Forms.Label();
            this.DTPHasta = new System.Windows.Forms.DateTimePicker();
            this.DTPDesde = new System.Windows.Forms.DateTimePicker();
            this.GBConfiguracionReporte = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.BtnVistaPrevia = new System.Windows.Forms.Button();
            this.L_Calibraciones = new System.Windows.Forms.Label();
            this.DGV_Analisis = new System.Windows.Forms.DataGridView();
            this.Variable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.absoluto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_Registros = new System.Windows.Forms.DataGridView();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Panel_AnalizarReg.SuspendLayout();
            this.GB_Tendencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Registros)).BeginInit();
            this.GB_DFSoISO.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.GBConfiguracionReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Analisis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Registros)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_AnalizarReg
            // 
            this.Panel_AnalizarReg.Controls.Add(this.BT_ExportarLista);
            this.Panel_AnalizarReg.Controls.Add(this.GB_Tendencia);
            this.Panel_AnalizarReg.Controls.Add(this.label21);
            this.Panel_AnalizarReg.Controls.Add(this.BT_Imprimir);
            this.Panel_AnalizarReg.Controls.Add(this.BT_VPImpresion);
            this.Panel_AnalizarReg.Controls.Add(this.BT_Referencia);
            this.Panel_AnalizarReg.Controls.Add(this.BT_Importar);
            this.Panel_AnalizarReg.Controls.Add(this.BT_Exportar);
            this.Panel_AnalizarReg.Controls.Add(this.Chart_Registros);
            this.Panel_AnalizarReg.Controls.Add(this.BtAnalizar);
            this.Panel_AnalizarReg.Controls.Add(this.GB_DFSoISO);
            this.Panel_AnalizarReg.Controls.Add(this.groupBox2);
            this.Panel_AnalizarReg.Controls.Add(this.groupBox1);
            this.Panel_AnalizarReg.Controls.Add(this.groupBox6);
            this.Panel_AnalizarReg.Controls.Add(this.GBConfiguracionReporte);
            this.Panel_AnalizarReg.Controls.Add(this.L_Calibraciones);
            this.Panel_AnalizarReg.Controls.Add(this.DGV_Analisis);
            this.Panel_AnalizarReg.Controls.Add(this.DGV_Registros);
            this.Panel_AnalizarReg.Location = new System.Drawing.Point(0, 0);
            this.Panel_AnalizarReg.Name = "Panel_AnalizarReg";
            this.Panel_AnalizarReg.Size = new System.Drawing.Size(870, 700);
            this.Panel_AnalizarReg.TabIndex = 2;
            // 
            // BT_ExportarLista
            // 
            this.BT_ExportarLista.Location = new System.Drawing.Point(693, 143);
            this.BT_ExportarLista.Name = "BT_ExportarLista";
            this.BT_ExportarLista.Size = new System.Drawing.Size(128, 25);
            this.BT_ExportarLista.TabIndex = 85;
            this.BT_ExportarLista.Text = "Exportar Lista";
            this.BT_ExportarLista.UseVisualStyleBackColor = true;
            this.BT_ExportarLista.Click += new System.EventHandler(this.BT_RegistroExportarLista_Click);
            // 
            // GB_Tendencia
            // 
            this.GB_Tendencia.Controls.Add(this.L_Tendencia);
            this.GB_Tendencia.Controls.Add(this.BT_AnalisisTendencia);
            this.GB_Tendencia.Controls.Add(this.CHB_RangoTendencia);
            this.GB_Tendencia.Controls.Add(this.L_TendenciaHasta);
            this.GB_Tendencia.Controls.Add(this.L_TendenciaDesde);
            this.GB_Tendencia.Controls.Add(this.DTP_TendenciaHasta);
            this.GB_Tendencia.Controls.Add(this.DTP_TendenciaDesde);
            this.GB_Tendencia.Enabled = false;
            this.GB_Tendencia.Location = new System.Drawing.Point(612, 454);
            this.GB_Tendencia.Name = "GB_Tendencia";
            this.GB_Tendencia.Size = new System.Drawing.Size(200, 163);
            this.GB_Tendencia.TabIndex = 84;
            this.GB_Tendencia.TabStop = false;
            this.GB_Tendencia.Text = "Tendencia";
            // 
            // L_Tendencia
            // 
            this.L_Tendencia.AutoSize = true;
            this.L_Tendencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Tendencia.Location = new System.Drawing.Point(9, 128);
            this.L_Tendencia.Name = "L_Tendencia";
            this.L_Tendencia.Size = new System.Drawing.Size(84, 17);
            this.L_Tendencia.TabIndex = 83;
            this.L_Tendencia.Text = "Tendencia";
            this.L_Tendencia.Visible = false;
            // 
            // BT_AnalisisTendencia
            // 
            this.BT_AnalisisTendencia.Location = new System.Drawing.Point(36, 96);
            this.BT_AnalisisTendencia.Name = "BT_AnalisisTendencia";
            this.BT_AnalisisTendencia.Size = new System.Drawing.Size(125, 23);
            this.BT_AnalisisTendencia.TabIndex = 49;
            this.BT_AnalisisTendencia.Text = "Analizar tendencia";
            this.BT_AnalisisTendencia.UseVisualStyleBackColor = true;
            this.BT_AnalisisTendencia.Click += new System.EventHandler(this.BT_AnalisisRegistroTendencia_Click);
            // 
            // CHB_RangoTendencia
            // 
            this.CHB_RangoTendencia.AutoSize = true;
            this.CHB_RangoTendencia.Location = new System.Drawing.Point(27, 16);
            this.CHB_RangoTendencia.Name = "CHB_RangoTendencia";
            this.CHB_RangoTendencia.Size = new System.Drawing.Size(161, 17);
            this.CHB_RangoTendencia.TabIndex = 44;
            this.CHB_RangoTendencia.Text = "Acotar a un rango de fechas";
            this.CHB_RangoTendencia.UseVisualStyleBackColor = true;
            this.CHB_RangoTendencia.CheckedChanged += new System.EventHandler(this.CHB_RangoTendenciaRegistros_CheckedChanged);
            // 
            // L_TendenciaHasta
            // 
            this.L_TendenciaHasta.AutoSize = true;
            this.L_TendenciaHasta.Enabled = false;
            this.L_TendenciaHasta.Location = new System.Drawing.Point(30, 69);
            this.L_TendenciaHasta.Name = "L_TendenciaHasta";
            this.L_TendenciaHasta.Size = new System.Drawing.Size(35, 13);
            this.L_TendenciaHasta.TabIndex = 48;
            this.L_TendenciaHasta.Text = "Hasta";
            // 
            // L_TendenciaDesde
            // 
            this.L_TendenciaDesde.AutoSize = true;
            this.L_TendenciaDesde.Enabled = false;
            this.L_TendenciaDesde.Location = new System.Drawing.Point(30, 43);
            this.L_TendenciaDesde.Name = "L_TendenciaDesde";
            this.L_TendenciaDesde.Size = new System.Drawing.Size(38, 13);
            this.L_TendenciaDesde.TabIndex = 47;
            this.L_TendenciaDesde.Text = "Desde";
            // 
            // DTP_TendenciaHasta
            // 
            this.DTP_TendenciaHasta.Enabled = false;
            this.DTP_TendenciaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_TendenciaHasta.Location = new System.Drawing.Point(77, 65);
            this.DTP_TendenciaHasta.Name = "DTP_TendenciaHasta";
            this.DTP_TendenciaHasta.Size = new System.Drawing.Size(84, 20);
            this.DTP_TendenciaHasta.TabIndex = 46;
            // 
            // DTP_TendenciaDesde
            // 
            this.DTP_TendenciaDesde.Enabled = false;
            this.DTP_TendenciaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_TendenciaDesde.Location = new System.Drawing.Point(77, 39);
            this.DTP_TendenciaDesde.Name = "DTP_TendenciaDesde";
            this.DTP_TendenciaDesde.Size = new System.Drawing.Size(84, 20);
            this.DTP_TendenciaDesde.TabIndex = 45;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(196, 453);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(86, 13);
            this.label21.TabIndex = 82;
            this.label21.Text = "Analisis Dw(Zref)";
            // 
            // BT_Imprimir
            // 
            this.BT_Imprimir.Location = new System.Drawing.Point(693, 201);
            this.BT_Imprimir.Name = "BT_Imprimir";
            this.BT_Imprimir.Size = new System.Drawing.Size(128, 25);
            this.BT_Imprimir.TabIndex = 76;
            this.BT_Imprimir.Text = "Imprimir";
            this.BT_Imprimir.UseVisualStyleBackColor = true;
            // 
            // BT_VPImpresion
            // 
            this.BT_VPImpresion.Location = new System.Drawing.Point(693, 173);
            this.BT_VPImpresion.Name = "BT_VPImpresion";
            this.BT_VPImpresion.Size = new System.Drawing.Size(128, 25);
            this.BT_VPImpresion.TabIndex = 77;
            this.BT_VPImpresion.Text = "Vista Previa";
            this.BT_VPImpresion.UseVisualStyleBackColor = true;
            // 
            // BT_Referencia
            // 
            this.BT_Referencia.Location = new System.Drawing.Point(693, 84);
            this.BT_Referencia.Name = "BT_Referencia";
            this.BT_Referencia.Size = new System.Drawing.Size(128, 38);
            this.BT_Referencia.TabIndex = 80;
            this.BT_Referencia.Text = "Establecer como\r\nreferencia";
            this.BT_Referencia.UseVisualStyleBackColor = true;
            this.BT_Referencia.Click += new System.EventHandler(this.BT_RegistroReferencia_Click);
            // 
            // BT_Importar
            // 
            this.BT_Importar.Location = new System.Drawing.Point(693, 26);
            this.BT_Importar.Name = "BT_Importar";
            this.BT_Importar.Size = new System.Drawing.Size(128, 25);
            this.BT_Importar.TabIndex = 79;
            this.BT_Importar.Text = "Importar";
            this.BT_Importar.UseVisualStyleBackColor = true;
            this.BT_Importar.Click += new System.EventHandler(this.BT_RegistroImportar_Click);
            // 
            // BT_Exportar
            // 
            this.BT_Exportar.Location = new System.Drawing.Point(693, 55);
            this.BT_Exportar.Name = "BT_Exportar";
            this.BT_Exportar.Size = new System.Drawing.Size(128, 25);
            this.BT_Exportar.TabIndex = 78;
            this.BT_Exportar.Text = "Exportar";
            this.BT_Exportar.UseVisualStyleBackColor = true;
            this.BT_Exportar.Click += new System.EventHandler(this.BT_RegistroExportar_Click);
            // 
            // Chart_Registros
            // 
            this.Chart_Registros.Location = new System.Drawing.Point(195, 239);
            this.Chart_Registros.Name = "Chart_Registros";
            series2.Name = "Series1";
            this.Chart_Registros.Series.Add(series2);
            this.Chart_Registros.Size = new System.Drawing.Size(626, 198);
            this.Chart_Registros.TabIndex = 0;
            this.Chart_Registros.Text = "chart2";
            // 
            // BtAnalizar
            // 
            this.BtAnalizar.Enabled = false;
            this.BtAnalizar.Location = new System.Drawing.Point(9, 477);
            this.BtAnalizar.Name = "BtAnalizar";
            this.BtAnalizar.Size = new System.Drawing.Size(180, 35);
            this.BtAnalizar.TabIndex = 44;
            this.BtAnalizar.Text = "Analizar";
            this.BtAnalizar.UseVisualStyleBackColor = true;
            this.BtAnalizar.Click += new System.EventHandler(this.BtAnalizar_Click);
            // 
            // GB_DFSoISO
            // 
            this.GB_DFSoISO.Controls.Add(this.RB_Iso);
            this.GB_DFSoISO.Controls.Add(this.RB_DFSFija);
            this.GB_DFSoISO.Enabled = false;
            this.GB_DFSoISO.Location = new System.Drawing.Point(9, 280);
            this.GB_DFSoISO.Name = "GB_DFSoISO";
            this.GB_DFSoISO.Size = new System.Drawing.Size(180, 79);
            this.GB_DFSoISO.TabIndex = 73;
            this.GB_DFSoISO.TabStop = false;
            this.GB_DFSoISO.Text = "3. Elegir condición";
            // 
            // RB_Iso
            // 
            this.RB_Iso.AutoSize = true;
            this.RB_Iso.Location = new System.Drawing.Point(15, 52);
            this.RB_Iso.Name = "RB_Iso";
            this.RB_Iso.Size = new System.Drawing.Size(79, 17);
            this.RB_Iso.TabIndex = 1;
            this.RB_Iso.TabStop = true;
            this.RB_Iso.Text = "Isocentríca";
            this.RB_Iso.UseVisualStyleBackColor = true;
            this.RB_Iso.CheckedChanged += new System.EventHandler(this.habilitarBotonAnalizar);
            // 
            // RB_DFSFija
            // 
            this.RB_DFSFija.AutoSize = true;
            this.RB_DFSFija.Location = new System.Drawing.Point(15, 25);
            this.RB_DFSFija.Name = "RB_DFSFija";
            this.RB_DFSFija.Size = new System.Drawing.Size(65, 17);
            this.RB_DFSFija.TabIndex = 0;
            this.RB_DFSFija.TabStop = true;
            this.RB_DFSFija.Text = "DFS Fija";
            this.RB_DFSFija.UseVisualStyleBackColor = true;
            this.RB_DFSFija.CheckedChanged += new System.EventHandler(this.habilitarBotonAnalizar);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label94);
            this.groupBox2.Controls.Add(this.label50);
            this.groupBox2.Controls.Add(this.CB_EnergiaElec);
            this.groupBox2.Controls.Add(this.CB_EnergiaFot);
            this.groupBox2.Controls.Add(this.RB_EnergiaElec);
            this.groupBox2.Controls.Add(this.RB_EnergiaFot);
            this.groupBox2.Location = new System.Drawing.Point(9, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 87);
            this.groupBox2.TabIndex = 72;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. Elegir Energia";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(148, 49);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(29, 13);
            this.label94.TabIndex = 66;
            this.label94.Text = "MeV";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(148, 23);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(23, 13);
            this.label50.TabIndex = 65;
            this.label50.Text = "MV";
            // 
            // CB_EnergiaElec
            // 
            this.CB_EnergiaElec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_EnergiaElec.Enabled = false;
            this.CB_EnergiaElec.FormattingEnabled = true;
            this.CB_EnergiaElec.Location = new System.Drawing.Point(93, 45);
            this.CB_EnergiaElec.Name = "CB_EnergiaElec";
            this.CB_EnergiaElec.Size = new System.Drawing.Size(52, 21);
            this.CB_EnergiaElec.TabIndex = 3;
            this.CB_EnergiaElec.SelectedIndexChanged += new System.EventHandler(this.habilitarBotonAnalizar);
            // 
            // CB_EnergiaFot
            // 
            this.CB_EnergiaFot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_EnergiaFot.Enabled = false;
            this.CB_EnergiaFot.FormattingEnabled = true;
            this.CB_EnergiaFot.Location = new System.Drawing.Point(93, 17);
            this.CB_EnergiaFot.Name = "CB_EnergiaFot";
            this.CB_EnergiaFot.Size = new System.Drawing.Size(52, 21);
            this.CB_EnergiaFot.TabIndex = 2;
            this.CB_EnergiaFot.SelectedIndexChanged += new System.EventHandler(this.habilitarBotonAnalizar);
            // 
            // RB_EnergiaElec
            // 
            this.RB_EnergiaElec.AutoSize = true;
            this.RB_EnergiaElec.Enabled = false;
            this.RB_EnergiaElec.Location = new System.Drawing.Point(9, 47);
            this.RB_EnergiaElec.Name = "RB_EnergiaElec";
            this.RB_EnergiaElec.Size = new System.Drawing.Size(75, 17);
            this.RB_EnergiaElec.TabIndex = 1;
            this.RB_EnergiaElec.TabStop = true;
            this.RB_EnergiaElec.Text = "Electrones";
            this.RB_EnergiaElec.UseVisualStyleBackColor = true;
            this.RB_EnergiaElec.CheckedChanged += new System.EventHandler(this.chequeoEnergias);
            // 
            // RB_EnergiaFot
            // 
            this.RB_EnergiaFot.AutoSize = true;
            this.RB_EnergiaFot.Enabled = false;
            this.RB_EnergiaFot.Location = new System.Drawing.Point(9, 21);
            this.RB_EnergiaFot.Name = "RB_EnergiaFot";
            this.RB_EnergiaFot.Size = new System.Drawing.Size(63, 17);
            this.RB_EnergiaFot.TabIndex = 0;
            this.RB_EnergiaFot.TabStop = true;
            this.RB_EnergiaFot.Text = "Fotones";
            this.RB_EnergiaFot.UseVisualStyleBackColor = true;
            this.RB_EnergiaFot.CheckedChanged += new System.EventHandler(this.chequeoEnergias);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ListBox_Equipos);
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 152);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Elegir Equipo";
            // 
            // ListBox_Equipos
            // 
            this.ListBox_Equipos.FormattingEnabled = true;
            this.ListBox_Equipos.Location = new System.Drawing.Point(15, 26);
            this.ListBox_Equipos.Name = "ListBox_Equipos";
            this.ListBox_Equipos.Size = new System.Drawing.Size(146, 108);
            this.ListBox_Equipos.TabIndex = 71;
            this.ListBox_Equipos.SelectedIndexChanged += new System.EventHandler(this.ListBox_RegistrosEquipos_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.CHB_Rango);
            this.groupBox6.Controls.Add(this.L_FechaHasta);
            this.groupBox6.Controls.Add(this.L_FechaDesde);
            this.groupBox6.Controls.Add(this.DTPHasta);
            this.groupBox6.Controls.Add(this.DTPDesde);
            this.groupBox6.Location = new System.Drawing.Point(9, 375);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(180, 92);
            this.groupBox6.TabIndex = 65;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "4. Filtrar fechas";
            // 
            // CHB_Rango
            // 
            this.CHB_Rango.AutoSize = true;
            this.CHB_Rango.Location = new System.Drawing.Point(6, 19);
            this.CHB_Rango.Name = "CHB_Rango";
            this.CHB_Rango.Size = new System.Drawing.Size(147, 17);
            this.CHB_Rango.TabIndex = 39;
            this.CHB_Rango.Text = "Elegir un rango de fechas";
            this.CHB_Rango.UseVisualStyleBackColor = true;
            this.CHB_Rango.CheckedChanged += new System.EventHandler(this.ChBRegRango_CheckedChanged);
            // 
            // L_FechaHasta
            // 
            this.L_FechaHasta.AutoSize = true;
            this.L_FechaHasta.Enabled = false;
            this.L_FechaHasta.Location = new System.Drawing.Point(15, 69);
            this.L_FechaHasta.Name = "L_FechaHasta";
            this.L_FechaHasta.Size = new System.Drawing.Size(35, 13);
            this.L_FechaHasta.TabIndex = 43;
            this.L_FechaHasta.Text = "Hasta";
            // 
            // L_FechaDesde
            // 
            this.L_FechaDesde.AutoSize = true;
            this.L_FechaDesde.Enabled = false;
            this.L_FechaDesde.Location = new System.Drawing.Point(13, 45);
            this.L_FechaDesde.Name = "L_FechaDesde";
            this.L_FechaDesde.Size = new System.Drawing.Size(38, 13);
            this.L_FechaDesde.TabIndex = 42;
            this.L_FechaDesde.Text = "Desde";
            // 
            // DTPHasta
            // 
            this.DTPHasta.Enabled = false;
            this.DTPHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPHasta.Location = new System.Drawing.Point(56, 68);
            this.DTPHasta.Name = "DTPHasta";
            this.DTPHasta.Size = new System.Drawing.Size(84, 20);
            this.DTPHasta.TabIndex = 41;
            // 
            // DTPDesde
            // 
            this.DTPDesde.Enabled = false;
            this.DTPDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDesde.Location = new System.Drawing.Point(56, 42);
            this.DTPDesde.Name = "DTPDesde";
            this.DTPDesde.Size = new System.Drawing.Size(84, 20);
            this.DTPDesde.TabIndex = 40;
            // 
            // GBConfiguracionReporte
            // 
            this.GBConfiguracionReporte.Controls.Add(this.checkedListBox1);
            this.GBConfiguracionReporte.Controls.Add(this.BtnImprimir);
            this.GBConfiguracionReporte.Controls.Add(this.BtnVistaPrevia);
            this.GBConfiguracionReporte.Location = new System.Drawing.Point(11, 537);
            this.GBConfiguracionReporte.Name = "GBConfiguracionReporte";
            this.GBConfiguracionReporte.Size = new System.Drawing.Size(178, 136);
            this.GBConfiguracionReporte.TabIndex = 66;
            this.GBConfiguracionReporte.TabStop = false;
            this.GBConfiguracionReporte.Text = "Configuración Reporte";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Lista Calibraciones",
            "Gráfico tasa de dosis ",
            "Análisis"});
            this.checkedListBox1.Location = new System.Drawing.Point(13, 16);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(150, 64);
            this.checkedListBox1.TabIndex = 55;
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Location = new System.Drawing.Point(91, 103);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(84, 23);
            this.BtnImprimir.TabIndex = 54;
            this.BtnImprimir.Text = "Imprimir";
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // BtnVistaPrevia
            // 
            this.BtnVistaPrevia.Location = new System.Drawing.Point(4, 103);
            this.BtnVistaPrevia.Name = "BtnVistaPrevia";
            this.BtnVistaPrevia.Size = new System.Drawing.Size(81, 23);
            this.BtnVistaPrevia.TabIndex = 53;
            this.BtnVistaPrevia.Text = "Vista Previa";
            this.BtnVistaPrevia.UseVisualStyleBackColor = true;
            this.BtnVistaPrevia.Click += new System.EventHandler(this.BtnVistaPrevia_Click);
            // 
            // L_Calibraciones
            // 
            this.L_Calibraciones.AutoSize = true;
            this.L_Calibraciones.Location = new System.Drawing.Point(193, 9);
            this.L_Calibraciones.Name = "L_Calibraciones";
            this.L_Calibraciones.Size = new System.Drawing.Size(70, 13);
            this.L_Calibraciones.TabIndex = 63;
            this.L_Calibraciones.Text = "Calibraciones";
            // 
            // DGV_Analisis
            // 
            this.DGV_Analisis.AllowUserToAddRows = false;
            this.DGV_Analisis.AllowUserToDeleteRows = false;
            this.DGV_Analisis.AllowUserToResizeColumns = false;
            this.DGV_Analisis.AllowUserToResizeRows = false;
            this.DGV_Analisis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Analisis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Variable,
            this.absoluto,
            this.relativo,
            this.Fecha});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Analisis.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_Analisis.Location = new System.Drawing.Point(196, 477);
            this.DGV_Analisis.Name = "DGV_Analisis";
            this.DGV_Analisis.ReadOnly = true;
            this.DGV_Analisis.RowHeadersVisible = false;
            this.DGV_Analisis.Size = new System.Drawing.Size(397, 201);
            this.DGV_Analisis.TabIndex = 62;
            this.DGV_Analisis.Visible = false;
            // 
            // Variable
            // 
            this.Variable.HeaderText = "";
            this.Variable.Name = "Variable";
            this.Variable.ReadOnly = true;
            // 
            // absoluto
            // 
            this.absoluto.HeaderText = "[cGy/UM]";
            this.absoluto.Name = "absoluto";
            this.absoluto.ReadOnly = true;
            // 
            // relativo
            // 
            this.relativo.HeaderText = "Diferencia [%]";
            this.relativo.Name = "relativo";
            this.relativo.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // DGV_Registros
            // 
            this.DGV_Registros.AllowUserToAddRows = false;
            this.DGV_Registros.AllowUserToDeleteRows = false;
            this.DGV_Registros.AllowUserToResizeColumns = false;
            this.DGV_Registros.AllowUserToResizeRows = false;
            this.DGV_Registros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Registros.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_Registros.Location = new System.Drawing.Point(195, 26);
            this.DGV_Registros.Name = "DGV_Registros";
            this.DGV_Registros.ReadOnly = true;
            this.DGV_Registros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Registros.Size = new System.Drawing.Size(492, 199);
            this.DGV_Registros.TabIndex = 60;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Form_AnalizarReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(824, 643);
            this.Controls.Add(this.Panel_AnalizarReg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_AnalizarReg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_AnalizarReg";
            this.Load += new System.EventHandler(this.Form_AnalizarReg_Load);
            this.Panel_AnalizarReg.ResumeLayout(false);
            this.Panel_AnalizarReg.PerformLayout();
            this.GB_Tendencia.ResumeLayout(false);
            this.GB_Tendencia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Registros)).EndInit();
            this.GB_DFSoISO.ResumeLayout(false);
            this.GB_DFSoISO.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.GBConfiguracionReporte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Analisis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Registros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Panel_AnalizarReg;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button BtAnalizar;
        private System.Windows.Forms.CheckBox CHB_Rango;
        private System.Windows.Forms.Label L_FechaHasta;
        private System.Windows.Forms.Label L_FechaDesde;
        private System.Windows.Forms.DateTimePicker DTPHasta;
        private System.Windows.Forms.DateTimePicker DTPDesde;
        private System.Windows.Forms.GroupBox GBConfiguracionReporte;
        private System.Windows.Forms.Button BtnImprimir;
        private System.Windows.Forms.Button BtnVistaPrevia;
        private System.Windows.Forms.Label L_Calibraciones;
        private System.Windows.Forms.DataGridView DGV_Registros;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox ListBox_Equipos;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.GroupBox GB_DFSoISO;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RB_Iso;
        private System.Windows.Forms.RadioButton RB_DFSFija;
        private System.Windows.Forms.ComboBox CB_EnergiaElec;
        private System.Windows.Forms.ComboBox CB_EnergiaFot;
        private System.Windows.Forms.RadioButton RB_EnergiaElec;
        private System.Windows.Forms.RadioButton RB_EnergiaFot;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_Registros;
        private System.Windows.Forms.Button BT_VPImpresion;
        private System.Windows.Forms.Button BT_Imprimir;
        private System.Windows.Forms.Button BT_Referencia;
        private System.Windows.Forms.Button BT_Importar;
        private System.Windows.Forms.Button BT_Exportar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridView DGV_Analisis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Variable;
        private System.Windows.Forms.DataGridViewTextBoxColumn absoluto;
        private System.Windows.Forms.DataGridViewTextBoxColumn relativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.Label L_Tendencia;
        private System.Windows.Forms.GroupBox GB_Tendencia;
        private System.Windows.Forms.CheckBox CHB_RangoTendencia;
        private System.Windows.Forms.Label L_TendenciaHasta;
        private System.Windows.Forms.Label L_TendenciaDesde;
        private System.Windows.Forms.DateTimePicker DTP_TendenciaHasta;
        private System.Windows.Forms.DateTimePicker DTP_TendenciaDesde;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button BT_AnalisisTendencia;
        private System.Windows.Forms.Button BT_ExportarLista;
    }
}

