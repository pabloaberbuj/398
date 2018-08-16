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
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AnalizarReg));
            this.Panel_AnalizarReg = new System.Windows.Forms.Panel();
            this.BT_RegistroExportarLista = new System.Windows.Forms.Button();
            this.GB_Tendencia = new System.Windows.Forms.GroupBox();
            this.L_Tendencia = new System.Windows.Forms.Label();
            this.BT_AnalisisRegistroTendencia = new System.Windows.Forms.Button();
            this.CHB_RangoTendenciaRegistros = new System.Windows.Forms.CheckBox();
            this.L_TendenciaHasta = new System.Windows.Forms.Label();
            this.L_TendenciaDesde = new System.Windows.Forms.Label();
            this.DTP_TendenciaHasta = new System.Windows.Forms.DateTimePicker();
            this.DTP_TendenciaDesde = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.BT_RegistroImprimir = new System.Windows.Forms.Button();
            this.BT_RegistroVPImpresion = new System.Windows.Forms.Button();
            this.BT_RegistroReferencia = new System.Windows.Forms.Button();
            this.BT_RegistroImportar = new System.Windows.Forms.Button();
            this.BT_RegistroExportar = new System.Windows.Forms.Button();
            this.Chart_Registros = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BtAnalizar = new System.Windows.Forms.Button();
            this.GB_DFSoISO = new System.Windows.Forms.GroupBox();
            this.RB_RegistroIso = new System.Windows.Forms.RadioButton();
            this.RB_RegistroDFSFija = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label94 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.CB_RegistroEnergiaElec = new System.Windows.Forms.ComboBox();
            this.CB_RegistroEnergiaFot = new System.Windows.Forms.ComboBox();
            this.RB_RegistroEnergiaElec = new System.Windows.Forms.RadioButton();
            this.RB_RegistroEnergiaFot = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ListBox_RegistrosEquipos = new System.Windows.Forms.ListBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ChBRegRango = new System.Windows.Forms.CheckBox();
            this.L_RegFechaHasta = new System.Windows.Forms.Label();
            this.L_regFechaDesde = new System.Windows.Forms.Label();
            this.DTPRegHasta = new System.Windows.Forms.DateTimePicker();
            this.DTPRegDesde = new System.Windows.Forms.DateTimePicker();
            this.GBConfiguracionReporte = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.BtnVistaPrevia = new System.Windows.Forms.Button();
            this.L_RegistroCalibraciones = new System.Windows.Forms.Label();
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
            this.Panel_AnalizarReg.Controls.Add(this.BT_RegistroExportarLista);
            this.Panel_AnalizarReg.Controls.Add(this.GB_Tendencia);
            this.Panel_AnalizarReg.Controls.Add(this.label21);
            this.Panel_AnalizarReg.Controls.Add(this.BT_RegistroImprimir);
            this.Panel_AnalizarReg.Controls.Add(this.BT_RegistroVPImpresion);
            this.Panel_AnalizarReg.Controls.Add(this.BT_RegistroReferencia);
            this.Panel_AnalizarReg.Controls.Add(this.BT_RegistroImportar);
            this.Panel_AnalizarReg.Controls.Add(this.BT_RegistroExportar);
            this.Panel_AnalizarReg.Controls.Add(this.Chart_Registros);
            this.Panel_AnalizarReg.Controls.Add(this.BtAnalizar);
            this.Panel_AnalizarReg.Controls.Add(this.GB_DFSoISO);
            this.Panel_AnalizarReg.Controls.Add(this.groupBox2);
            this.Panel_AnalizarReg.Controls.Add(this.groupBox1);
            this.Panel_AnalizarReg.Controls.Add(this.groupBox6);
            this.Panel_AnalizarReg.Controls.Add(this.GBConfiguracionReporte);
            this.Panel_AnalizarReg.Controls.Add(this.L_RegistroCalibraciones);
            this.Panel_AnalizarReg.Controls.Add(this.DGV_Analisis);
            this.Panel_AnalizarReg.Controls.Add(this.DGV_Registros);
            this.Panel_AnalizarReg.Location = new System.Drawing.Point(0, 0);
            this.Panel_AnalizarReg.Name = "Panel_AnalizarReg";
            this.Panel_AnalizarReg.Size = new System.Drawing.Size(870, 700);
            this.Panel_AnalizarReg.TabIndex = 2;
            // 
            // BT_RegistroExportarLista
            // 
            this.BT_RegistroExportarLista.Location = new System.Drawing.Point(693, 143);
            this.BT_RegistroExportarLista.Name = "BT_RegistroExportarLista";
            this.BT_RegistroExportarLista.Size = new System.Drawing.Size(128, 25);
            this.BT_RegistroExportarLista.TabIndex = 85;
            this.BT_RegistroExportarLista.Text = "Exportar Lista";
            this.BT_RegistroExportarLista.UseVisualStyleBackColor = true;
            this.BT_RegistroExportarLista.Click += new System.EventHandler(this.BT_RegistroExportarLista_Click);
            // 
            // GB_Tendencia
            // 
            this.GB_Tendencia.Controls.Add(this.L_Tendencia);
            this.GB_Tendencia.Controls.Add(this.BT_AnalisisRegistroTendencia);
            this.GB_Tendencia.Controls.Add(this.CHB_RangoTendenciaRegistros);
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
            // BT_AnalisisRegistroTendencia
            // 
            this.BT_AnalisisRegistroTendencia.Location = new System.Drawing.Point(36, 96);
            this.BT_AnalisisRegistroTendencia.Name = "BT_AnalisisRegistroTendencia";
            this.BT_AnalisisRegistroTendencia.Size = new System.Drawing.Size(125, 23);
            this.BT_AnalisisRegistroTendencia.TabIndex = 49;
            this.BT_AnalisisRegistroTendencia.Text = "Analizar tendencia";
            this.BT_AnalisisRegistroTendencia.UseVisualStyleBackColor = true;
            this.BT_AnalisisRegistroTendencia.Click += new System.EventHandler(this.BT_AnalisisRegistroTendencia_Click);
            // 
            // CHB_RangoTendenciaRegistros
            // 
            this.CHB_RangoTendenciaRegistros.AutoSize = true;
            this.CHB_RangoTendenciaRegistros.Location = new System.Drawing.Point(27, 16);
            this.CHB_RangoTendenciaRegistros.Name = "CHB_RangoTendenciaRegistros";
            this.CHB_RangoTendenciaRegistros.Size = new System.Drawing.Size(161, 17);
            this.CHB_RangoTendenciaRegistros.TabIndex = 44;
            this.CHB_RangoTendenciaRegistros.Text = "Acotar a un rango de fechas";
            this.CHB_RangoTendenciaRegistros.UseVisualStyleBackColor = true;
            this.CHB_RangoTendenciaRegistros.CheckedChanged += new System.EventHandler(this.CHB_RangoTendenciaRegistros_CheckedChanged);
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
            // BT_RegistroImprimir
            // 
            this.BT_RegistroImprimir.Location = new System.Drawing.Point(693, 201);
            this.BT_RegistroImprimir.Name = "BT_RegistroImprimir";
            this.BT_RegistroImprimir.Size = new System.Drawing.Size(128, 25);
            this.BT_RegistroImprimir.TabIndex = 76;
            this.BT_RegistroImprimir.Text = "Imprimir";
            this.BT_RegistroImprimir.UseVisualStyleBackColor = true;
            // 
            // BT_RegistroVPImpresion
            // 
            this.BT_RegistroVPImpresion.Location = new System.Drawing.Point(693, 173);
            this.BT_RegistroVPImpresion.Name = "BT_RegistroVPImpresion";
            this.BT_RegistroVPImpresion.Size = new System.Drawing.Size(128, 25);
            this.BT_RegistroVPImpresion.TabIndex = 77;
            this.BT_RegistroVPImpresion.Text = "Vista Previa";
            this.BT_RegistroVPImpresion.UseVisualStyleBackColor = true;
            // 
            // BT_RegistroReferencia
            // 
            this.BT_RegistroReferencia.Location = new System.Drawing.Point(693, 84);
            this.BT_RegistroReferencia.Name = "BT_RegistroReferencia";
            this.BT_RegistroReferencia.Size = new System.Drawing.Size(128, 38);
            this.BT_RegistroReferencia.TabIndex = 80;
            this.BT_RegistroReferencia.Text = "Establecer como\r\nreferencia";
            this.BT_RegistroReferencia.UseVisualStyleBackColor = true;
            this.BT_RegistroReferencia.Click += new System.EventHandler(this.BT_RegistroReferencia_Click);
            // 
            // BT_RegistroImportar
            // 
            this.BT_RegistroImportar.Location = new System.Drawing.Point(693, 26);
            this.BT_RegistroImportar.Name = "BT_RegistroImportar";
            this.BT_RegistroImportar.Size = new System.Drawing.Size(128, 25);
            this.BT_RegistroImportar.TabIndex = 79;
            this.BT_RegistroImportar.Text = "Importar";
            this.BT_RegistroImportar.UseVisualStyleBackColor = true;
            this.BT_RegistroImportar.Click += new System.EventHandler(this.BT_RegistroImportar_Click);
            // 
            // BT_RegistroExportar
            // 
            this.BT_RegistroExportar.Location = new System.Drawing.Point(693, 55);
            this.BT_RegistroExportar.Name = "BT_RegistroExportar";
            this.BT_RegistroExportar.Size = new System.Drawing.Size(128, 25);
            this.BT_RegistroExportar.TabIndex = 78;
            this.BT_RegistroExportar.Text = "Exportar";
            this.BT_RegistroExportar.UseVisualStyleBackColor = true;
            this.BT_RegistroExportar.Click += new System.EventHandler(this.BT_RegistroExportar_Click);
            // 
            // Chart_Registros
            // 
            this.Chart_Registros.Location = new System.Drawing.Point(195, 239);
            this.Chart_Registros.Name = "Chart_Registros";
            series3.Name = "Series1";
            this.Chart_Registros.Series.Add(series3);
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
            this.GB_DFSoISO.Controls.Add(this.RB_RegistroIso);
            this.GB_DFSoISO.Controls.Add(this.RB_RegistroDFSFija);
            this.GB_DFSoISO.Enabled = false;
            this.GB_DFSoISO.Location = new System.Drawing.Point(9, 280);
            this.GB_DFSoISO.Name = "GB_DFSoISO";
            this.GB_DFSoISO.Size = new System.Drawing.Size(180, 79);
            this.GB_DFSoISO.TabIndex = 73;
            this.GB_DFSoISO.TabStop = false;
            this.GB_DFSoISO.Text = "3. Elegir condición";
            // 
            // RB_RegistroIso
            // 
            this.RB_RegistroIso.AutoSize = true;
            this.RB_RegistroIso.Location = new System.Drawing.Point(15, 52);
            this.RB_RegistroIso.Name = "RB_RegistroIso";
            this.RB_RegistroIso.Size = new System.Drawing.Size(79, 17);
            this.RB_RegistroIso.TabIndex = 1;
            this.RB_RegistroIso.TabStop = true;
            this.RB_RegistroIso.Text = "Isocentríca";
            this.RB_RegistroIso.UseVisualStyleBackColor = true;
            this.RB_RegistroIso.CheckedChanged += new System.EventHandler(this.habilitarBotonAnalizar);
            // 
            // RB_RegistroDFSFija
            // 
            this.RB_RegistroDFSFija.AutoSize = true;
            this.RB_RegistroDFSFija.Location = new System.Drawing.Point(15, 25);
            this.RB_RegistroDFSFija.Name = "RB_RegistroDFSFija";
            this.RB_RegistroDFSFija.Size = new System.Drawing.Size(65, 17);
            this.RB_RegistroDFSFija.TabIndex = 0;
            this.RB_RegistroDFSFija.TabStop = true;
            this.RB_RegistroDFSFija.Text = "DFS Fija";
            this.RB_RegistroDFSFija.UseVisualStyleBackColor = true;
            this.RB_RegistroDFSFija.CheckedChanged += new System.EventHandler(this.habilitarBotonAnalizar);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label94);
            this.groupBox2.Controls.Add(this.label50);
            this.groupBox2.Controls.Add(this.CB_RegistroEnergiaElec);
            this.groupBox2.Controls.Add(this.CB_RegistroEnergiaFot);
            this.groupBox2.Controls.Add(this.RB_RegistroEnergiaElec);
            this.groupBox2.Controls.Add(this.RB_RegistroEnergiaFot);
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
            // CB_RegistroEnergiaElec
            // 
            this.CB_RegistroEnergiaElec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_RegistroEnergiaElec.Enabled = false;
            this.CB_RegistroEnergiaElec.FormattingEnabled = true;
            this.CB_RegistroEnergiaElec.Location = new System.Drawing.Point(93, 45);
            this.CB_RegistroEnergiaElec.Name = "CB_RegistroEnergiaElec";
            this.CB_RegistroEnergiaElec.Size = new System.Drawing.Size(52, 21);
            this.CB_RegistroEnergiaElec.TabIndex = 3;
            this.CB_RegistroEnergiaElec.SelectedIndexChanged += new System.EventHandler(this.habilitarBotonAnalizar);
            // 
            // CB_RegistroEnergiaFot
            // 
            this.CB_RegistroEnergiaFot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_RegistroEnergiaFot.Enabled = false;
            this.CB_RegistroEnergiaFot.FormattingEnabled = true;
            this.CB_RegistroEnergiaFot.Location = new System.Drawing.Point(93, 17);
            this.CB_RegistroEnergiaFot.Name = "CB_RegistroEnergiaFot";
            this.CB_RegistroEnergiaFot.Size = new System.Drawing.Size(52, 21);
            this.CB_RegistroEnergiaFot.TabIndex = 2;
            this.CB_RegistroEnergiaFot.SelectedIndexChanged += new System.EventHandler(this.habilitarBotonAnalizar);
            // 
            // RB_RegistroEnergiaElec
            // 
            this.RB_RegistroEnergiaElec.AutoSize = true;
            this.RB_RegistroEnergiaElec.Enabled = false;
            this.RB_RegistroEnergiaElec.Location = new System.Drawing.Point(9, 47);
            this.RB_RegistroEnergiaElec.Name = "RB_RegistroEnergiaElec";
            this.RB_RegistroEnergiaElec.Size = new System.Drawing.Size(75, 17);
            this.RB_RegistroEnergiaElec.TabIndex = 1;
            this.RB_RegistroEnergiaElec.TabStop = true;
            this.RB_RegistroEnergiaElec.Text = "Electrones";
            this.RB_RegistroEnergiaElec.UseVisualStyleBackColor = true;
            this.RB_RegistroEnergiaElec.CheckedChanged += new System.EventHandler(this.registroChequeoEnergias);
            // 
            // RB_RegistroEnergiaFot
            // 
            this.RB_RegistroEnergiaFot.AutoSize = true;
            this.RB_RegistroEnergiaFot.Enabled = false;
            this.RB_RegistroEnergiaFot.Location = new System.Drawing.Point(9, 21);
            this.RB_RegistroEnergiaFot.Name = "RB_RegistroEnergiaFot";
            this.RB_RegistroEnergiaFot.Size = new System.Drawing.Size(63, 17);
            this.RB_RegistroEnergiaFot.TabIndex = 0;
            this.RB_RegistroEnergiaFot.TabStop = true;
            this.RB_RegistroEnergiaFot.Text = "Fotones";
            this.RB_RegistroEnergiaFot.UseVisualStyleBackColor = true;
            this.RB_RegistroEnergiaFot.CheckedChanged += new System.EventHandler(this.registroChequeoEnergias);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ListBox_RegistrosEquipos);
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 152);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Elegir Equipo";
            // 
            // ListBox_RegistrosEquipos
            // 
            this.ListBox_RegistrosEquipos.FormattingEnabled = true;
            this.ListBox_RegistrosEquipos.Location = new System.Drawing.Point(15, 26);
            this.ListBox_RegistrosEquipos.Name = "ListBox_RegistrosEquipos";
            this.ListBox_RegistrosEquipos.Size = new System.Drawing.Size(146, 108);
            this.ListBox_RegistrosEquipos.TabIndex = 71;
            this.ListBox_RegistrosEquipos.SelectedIndexChanged += new System.EventHandler(this.ListBox_RegistrosEquipos_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ChBRegRango);
            this.groupBox6.Controls.Add(this.L_RegFechaHasta);
            this.groupBox6.Controls.Add(this.L_regFechaDesde);
            this.groupBox6.Controls.Add(this.DTPRegHasta);
            this.groupBox6.Controls.Add(this.DTPRegDesde);
            this.groupBox6.Location = new System.Drawing.Point(9, 375);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(180, 92);
            this.groupBox6.TabIndex = 65;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "4. Filtrar fechas";
            // 
            // ChBRegRango
            // 
            this.ChBRegRango.AutoSize = true;
            this.ChBRegRango.Location = new System.Drawing.Point(6, 19);
            this.ChBRegRango.Name = "ChBRegRango";
            this.ChBRegRango.Size = new System.Drawing.Size(147, 17);
            this.ChBRegRango.TabIndex = 39;
            this.ChBRegRango.Text = "Elegir un rango de fechas";
            this.ChBRegRango.UseVisualStyleBackColor = true;
            this.ChBRegRango.CheckedChanged += new System.EventHandler(this.ChBRegRango_CheckedChanged);
            // 
            // L_RegFechaHasta
            // 
            this.L_RegFechaHasta.AutoSize = true;
            this.L_RegFechaHasta.Enabled = false;
            this.L_RegFechaHasta.Location = new System.Drawing.Point(15, 69);
            this.L_RegFechaHasta.Name = "L_RegFechaHasta";
            this.L_RegFechaHasta.Size = new System.Drawing.Size(35, 13);
            this.L_RegFechaHasta.TabIndex = 43;
            this.L_RegFechaHasta.Text = "Hasta";
            // 
            // L_regFechaDesde
            // 
            this.L_regFechaDesde.AutoSize = true;
            this.L_regFechaDesde.Enabled = false;
            this.L_regFechaDesde.Location = new System.Drawing.Point(13, 45);
            this.L_regFechaDesde.Name = "L_regFechaDesde";
            this.L_regFechaDesde.Size = new System.Drawing.Size(38, 13);
            this.L_regFechaDesde.TabIndex = 42;
            this.L_regFechaDesde.Text = "Desde";
            // 
            // DTPRegHasta
            // 
            this.DTPRegHasta.Enabled = false;
            this.DTPRegHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPRegHasta.Location = new System.Drawing.Point(56, 68);
            this.DTPRegHasta.Name = "DTPRegHasta";
            this.DTPRegHasta.Size = new System.Drawing.Size(84, 20);
            this.DTPRegHasta.TabIndex = 41;
            // 
            // DTPRegDesde
            // 
            this.DTPRegDesde.Enabled = false;
            this.DTPRegDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPRegDesde.Location = new System.Drawing.Point(56, 42);
            this.DTPRegDesde.Name = "DTPRegDesde";
            this.DTPRegDesde.Size = new System.Drawing.Size(84, 20);
            this.DTPRegDesde.TabIndex = 40;
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
            // L_RegistroCalibraciones
            // 
            this.L_RegistroCalibraciones.AutoSize = true;
            this.L_RegistroCalibraciones.Location = new System.Drawing.Point(193, 9);
            this.L_RegistroCalibraciones.Name = "L_RegistroCalibraciones";
            this.L_RegistroCalibraciones.Size = new System.Drawing.Size(70, 13);
            this.L_RegistroCalibraciones.TabIndex = 63;
            this.L_RegistroCalibraciones.Text = "Calibraciones";
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Analisis.DefaultCellStyle = dataGridViewCellStyle5;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Registros.DefaultCellStyle = dataGridViewCellStyle6;
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
        private System.Windows.Forms.CheckBox ChBRegRango;
        private System.Windows.Forms.Label L_RegFechaHasta;
        private System.Windows.Forms.Label L_regFechaDesde;
        private System.Windows.Forms.DateTimePicker DTPRegHasta;
        private System.Windows.Forms.DateTimePicker DTPRegDesde;
        private System.Windows.Forms.GroupBox GBConfiguracionReporte;
        private System.Windows.Forms.Button BtnImprimir;
        private System.Windows.Forms.Button BtnVistaPrevia;
        private System.Windows.Forms.Label L_RegistroCalibraciones;
        private System.Windows.Forms.DataGridView DGV_Registros;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox ListBox_RegistrosEquipos;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.GroupBox GB_DFSoISO;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RB_RegistroIso;
        private System.Windows.Forms.RadioButton RB_RegistroDFSFija;
        private System.Windows.Forms.ComboBox CB_RegistroEnergiaElec;
        private System.Windows.Forms.ComboBox CB_RegistroEnergiaFot;
        private System.Windows.Forms.RadioButton RB_RegistroEnergiaElec;
        private System.Windows.Forms.RadioButton RB_RegistroEnergiaFot;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_Registros;
        private System.Windows.Forms.Button BT_RegistroVPImpresion;
        private System.Windows.Forms.Button BT_RegistroImprimir;
        private System.Windows.Forms.Button BT_RegistroReferencia;
        private System.Windows.Forms.Button BT_RegistroImportar;
        private System.Windows.Forms.Button BT_RegistroExportar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridView DGV_Analisis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Variable;
        private System.Windows.Forms.DataGridViewTextBoxColumn absoluto;
        private System.Windows.Forms.DataGridViewTextBoxColumn relativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.Label L_Tendencia;
        private System.Windows.Forms.GroupBox GB_Tendencia;
        private System.Windows.Forms.CheckBox CHB_RangoTendenciaRegistros;
        private System.Windows.Forms.Label L_TendenciaHasta;
        private System.Windows.Forms.Label L_TendenciaDesde;
        private System.Windows.Forms.DateTimePicker DTP_TendenciaHasta;
        private System.Windows.Forms.DateTimePicker DTP_TendenciaDesde;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button BT_AnalisisRegistroTendencia;
        private System.Windows.Forms.Button BT_RegistroExportarLista;
    }
}

