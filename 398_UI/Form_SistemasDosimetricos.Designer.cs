namespace _398_UI
{
    partial class Form_SistemasDosimetricos
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
            this.Panel_SistDos = new System.Windows.Forms.Panel();
            this.GB_SistDos = new System.Windows.Forms.GroupBox();
            this.BT_ImportarSistDos = new System.Windows.Forms.Button();
            this.BT_SistDosIraCal = new System.Windows.Forms.Button();
            this.BT_PredSistDos = new System.Windows.Forms.Button();
            this.BT_EditarSistDos = new System.Windows.Forms.Button();
            this.BT_ExportarSistDos = new System.Windows.Forms.Button();
            this.BT_EliminarSistDos = new System.Windows.Forms.Button();
            this.BT_NuevSistDos = new System.Windows.Forms.Button();
            this.DGV_SistDos = new System.Windows.Forms.DataGridView();
            this.GB_Electrómetros = new System.Windows.Forms.GroupBox();
            this.BT_Electrometro_Cancelar = new System.Windows.Forms.Button();
            this.TB_ModeloElec = new System.Windows.Forms.TextBox();
            this.TB_MarcaElec = new System.Windows.Forms.TextBox();
            this.BT_EliminarElec = new System.Windows.Forms.Button();
            this.BT_EditarElec = new System.Windows.Forms.Button();
            this.BT_GuardarElec = new System.Windows.Forms.Button();
            this.DGV_Elec = new System.Windows.Forms.DataGridView();
            this.TB_SNElec = new System.Windows.Forms.TextBox();
            this.LB_SNElec = new System.Windows.Forms.Label();
            this.LB_ModeloElec = new System.Windows.Forms.Label();
            this.LB_MarcaElec = new System.Windows.Forms.Label();
            this.GB_Camaras = new System.Windows.Forms.GroupBox();
            this.BT_Camara_Cancelar = new System.Windows.Forms.Button();
            this.BT_EliminarCam = new System.Windows.Forms.Button();
            this.BT_EditarCam = new System.Windows.Forms.Button();
            this.BT_GuardarCam = new System.Windows.Forms.Button();
            this.DGV_Cam = new System.Windows.Forms.DataGridView();
            this.CB_ModCam = new System.Windows.Forms.ComboBox();
            this.CB_MarcaCam = new System.Windows.Forms.ComboBox();
            this.TB_SNCam = new System.Windows.Forms.TextBox();
            this.LB_SNCam = new System.Windows.Forms.Label();
            this.LB_ModCam = new System.Windows.Forms.Label();
            this.LB_MarcaCam = new System.Windows.Forms.Label();
            this.Panel_SistDos.SuspendLayout();
            this.GB_SistDos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SistDos)).BeginInit();
            this.GB_Electrómetros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Elec)).BeginInit();
            this.GB_Camaras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Cam)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_SistDos
            // 
            this.Panel_SistDos.Controls.Add(this.GB_SistDos);
            this.Panel_SistDos.Controls.Add(this.GB_Electrómetros);
            this.Panel_SistDos.Controls.Add(this.GB_Camaras);
            this.Panel_SistDos.Location = new System.Drawing.Point(0, 0);
            this.Panel_SistDos.Name = "Panel_SistDos";
            this.Panel_SistDos.Size = new System.Drawing.Size(870, 700);
            this.Panel_SistDos.TabIndex = 2;
            // 
            // GB_SistDos
            // 
            this.GB_SistDos.Controls.Add(this.BT_ImportarSistDos);
            this.GB_SistDos.Controls.Add(this.BT_SistDosIraCal);
            this.GB_SistDos.Controls.Add(this.BT_PredSistDos);
            this.GB_SistDos.Controls.Add(this.BT_EditarSistDos);
            this.GB_SistDos.Controls.Add(this.BT_ExportarSistDos);
            this.GB_SistDos.Controls.Add(this.BT_EliminarSistDos);
            this.GB_SistDos.Controls.Add(this.BT_NuevSistDos);
            this.GB_SistDos.Controls.Add(this.DGV_SistDos);
            this.GB_SistDos.Location = new System.Drawing.Point(12, 409);
            this.GB_SistDos.Name = "GB_SistDos";
            this.GB_SistDos.Size = new System.Drawing.Size(782, 270);
            this.GB_SistDos.TabIndex = 10;
            this.GB_SistDos.TabStop = false;
            this.GB_SistDos.Text = "Sistemas dosimétricos";
            // 
            // BT_ImportarSistDos
            // 
            this.BT_ImportarSistDos.Location = new System.Drawing.Point(619, 73);
            this.BT_ImportarSistDos.Name = "BT_ImportarSistDos";
            this.BT_ImportarSistDos.Size = new System.Drawing.Size(157, 23);
            this.BT_ImportarSistDos.TabIndex = 20;
            this.BT_ImportarSistDos.Text = "Importar";
            this.BT_ImportarSistDos.UseVisualStyleBackColor = true;
            this.BT_ImportarSistDos.Click += new System.EventHandler(this.BT_ImportarSistDos_Click);
            // 
            // BT_SistDosIraCal
            // 
            this.BT_SistDosIraCal.Location = new System.Drawing.Point(619, 183);
            this.BT_SistDosIraCal.Name = "BT_SistDosIraCal";
            this.BT_SistDosIraCal.Size = new System.Drawing.Size(157, 44);
            this.BT_SistDosIraCal.TabIndex = 18;
            this.BT_SistDosIraCal.Text = "Seleccionar e ir a Calibración";
            this.BT_SistDosIraCal.UseVisualStyleBackColor = true;
            //this.BT_SistDosIraCal.Click += new System.EventHandler(this.BT_SistDosIraCal_Click);
            // 
            // BT_PredSistDos
            // 
            this.BT_PredSistDos.Location = new System.Drawing.Point(619, 157);
            this.BT_PredSistDos.Name = "BT_PredSistDos";
            this.BT_PredSistDos.Size = new System.Drawing.Size(157, 23);
            this.BT_PredSistDos.TabIndex = 17;
            this.BT_PredSistDos.Text = "Elegir como predeterminado";
            this.BT_PredSistDos.UseVisualStyleBackColor = true;
            this.BT_PredSistDos.Click += new System.EventHandler(this.BT_PredSistDos_Click);
            // 
            // BT_EditarSistDos
            // 
            this.BT_EditarSistDos.Location = new System.Drawing.Point(619, 128);
            this.BT_EditarSistDos.Name = "BT_EditarSistDos";
            this.BT_EditarSistDos.Size = new System.Drawing.Size(157, 23);
            this.BT_EditarSistDos.TabIndex = 16;
            this.BT_EditarSistDos.Text = "Editar";
            this.BT_EditarSistDos.UseVisualStyleBackColor = true;
            this.BT_EditarSistDos.Click += new System.EventHandler(this.BT_EditarSistDos_Click);
            // 
            // BT_ExportarSistDos
            // 
            this.BT_ExportarSistDos.Location = new System.Drawing.Point(619, 99);
            this.BT_ExportarSistDos.Name = "BT_ExportarSistDos";
            this.BT_ExportarSistDos.Size = new System.Drawing.Size(157, 23);
            this.BT_ExportarSistDos.TabIndex = 15;
            this.BT_ExportarSistDos.Text = "Exportar";
            this.BT_ExportarSistDos.UseVisualStyleBackColor = true;
            this.BT_ExportarSistDos.Click += new System.EventHandler(this.BT_ExportarSistDos_Click);
            // 
            // BT_EliminarSistDos
            // 
            this.BT_EliminarSistDos.Location = new System.Drawing.Point(619, 230);
            this.BT_EliminarSistDos.Name = "BT_EliminarSistDos";
            this.BT_EliminarSistDos.Size = new System.Drawing.Size(157, 23);
            this.BT_EliminarSistDos.TabIndex = 19;
            this.BT_EliminarSistDos.Text = "Eliminar";
            this.BT_EliminarSistDos.UseVisualStyleBackColor = true;
            this.BT_EliminarSistDos.Click += new System.EventHandler(this.BT_EliminarSistDos_Click);
            // 
            // BT_NuevSistDos
            // 
            this.BT_NuevSistDos.Location = new System.Drawing.Point(619, 33);
            this.BT_NuevSistDos.Name = "BT_NuevSistDos";
            this.BT_NuevSistDos.Size = new System.Drawing.Size(157, 35);
            this.BT_NuevSistDos.TabIndex = 14;
            this.BT_NuevSistDos.Text = "Crear nuevo sistema dosimetrico";
            this.BT_NuevSistDos.UseVisualStyleBackColor = true;
            this.BT_NuevSistDos.Click += new System.EventHandler(this.BT_NuevSistDos_Click);
            // 
            // DGV_SistDos
            // 
            this.DGV_SistDos.AllowUserToAddRows = false;
            this.DGV_SistDos.AllowUserToResizeColumns = false;
            this.DGV_SistDos.AllowUserToResizeRows = false;
            this.DGV_SistDos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_SistDos.Location = new System.Drawing.Point(19, 33);
            this.DGV_SistDos.Name = "DGV_SistDos";
            this.DGV_SistDos.ReadOnly = true;
            this.DGV_SistDos.RowHeadersVisible = false;
            this.DGV_SistDos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_SistDos.Size = new System.Drawing.Size(594, 220);
            this.DGV_SistDos.TabIndex = 13;
            this.DGV_SistDos.SelectionChanged += new System.EventHandler(this.habilitarSistDosBotones);
            // 
            // GB_Electrómetros
            // 
            this.GB_Electrómetros.Controls.Add(this.BT_Electrometro_Cancelar);
            this.GB_Electrómetros.Controls.Add(this.TB_ModeloElec);
            this.GB_Electrómetros.Controls.Add(this.TB_MarcaElec);
            this.GB_Electrómetros.Controls.Add(this.BT_EliminarElec);
            this.GB_Electrómetros.Controls.Add(this.BT_EditarElec);
            this.GB_Electrómetros.Controls.Add(this.BT_GuardarElec);
            this.GB_Electrómetros.Controls.Add(this.DGV_Elec);
            this.GB_Electrómetros.Controls.Add(this.TB_SNElec);
            this.GB_Electrómetros.Controls.Add(this.LB_SNElec);
            this.GB_Electrómetros.Controls.Add(this.LB_ModeloElec);
            this.GB_Electrómetros.Controls.Add(this.LB_MarcaElec);
            this.GB_Electrómetros.Location = new System.Drawing.Point(404, 12);
            this.GB_Electrómetros.Name = "GB_Electrómetros";
            this.GB_Electrómetros.Size = new System.Drawing.Size(390, 354);
            this.GB_Electrómetros.TabIndex = 9;
            this.GB_Electrómetros.TabStop = false;
            this.GB_Electrómetros.Text = "Electrómetros";
            // 
            // BT_Electrometro_Cancelar
            // 
            this.BT_Electrometro_Cancelar.Location = new System.Drawing.Point(257, 63);
            this.BT_Electrometro_Cancelar.Name = "BT_Electrometro_Cancelar";
            this.BT_Electrometro_Cancelar.Size = new System.Drawing.Size(119, 23);
            this.BT_Electrometro_Cancelar.TabIndex = 74;
            this.BT_Electrometro_Cancelar.Text = "Cancelar";
            this.BT_Electrometro_Cancelar.UseVisualStyleBackColor = true;
            this.BT_Electrometro_Cancelar.Click += new System.EventHandler(this.BT_Electrometro_Cancelar_Click);
            // 
            // TB_ModeloElec
            // 
            this.TB_ModeloElec.Location = new System.Drawing.Point(121, 64);
            this.TB_ModeloElec.Name = "TB_ModeloElec";
            this.TB_ModeloElec.Size = new System.Drawing.Size(100, 20);
            this.TB_ModeloElec.TabIndex = 8;
            this.TB_ModeloElec.TextChanged += new System.EventHandler(this.habilitarElecBotones);
            // 
            // TB_MarcaElec
            // 
            this.TB_MarcaElec.Location = new System.Drawing.Point(121, 33);
            this.TB_MarcaElec.Name = "TB_MarcaElec";
            this.TB_MarcaElec.Size = new System.Drawing.Size(100, 20);
            this.TB_MarcaElec.TabIndex = 7;
            this.TB_MarcaElec.TextChanged += new System.EventHandler(this.habilitarElecBotones);
            // 
            // BT_EliminarElec
            // 
            this.BT_EliminarElec.Location = new System.Drawing.Point(280, 315);
            this.BT_EliminarElec.Name = "BT_EliminarElec";
            this.BT_EliminarElec.Size = new System.Drawing.Size(96, 23);
            this.BT_EliminarElec.TabIndex = 12;
            this.BT_EliminarElec.Text = "Eliminar";
            this.BT_EliminarElec.UseVisualStyleBackColor = true;
            this.BT_EliminarElec.Click += new System.EventHandler(this.BT_EliminarElec_Click);
            // 
            // BT_EditarElec
            // 
            this.BT_EditarElec.Location = new System.Drawing.Point(148, 315);
            this.BT_EditarElec.Name = "BT_EditarElec";
            this.BT_EditarElec.Size = new System.Drawing.Size(96, 23);
            this.BT_EditarElec.TabIndex = 11;
            this.BT_EditarElec.Text = "Editar";
            this.BT_EditarElec.UseVisualStyleBackColor = true;
            this.BT_EditarElec.Click += new System.EventHandler(this.BT_EditarElec_Click);
            // 
            // BT_GuardarElec
            // 
            this.BT_GuardarElec.Location = new System.Drawing.Point(257, 27);
            this.BT_GuardarElec.Name = "BT_GuardarElec";
            this.BT_GuardarElec.Size = new System.Drawing.Size(119, 23);
            this.BT_GuardarElec.TabIndex = 10;
            this.BT_GuardarElec.Text = "Guardar";
            this.BT_GuardarElec.UseVisualStyleBackColor = true;
            this.BT_GuardarElec.Click += new System.EventHandler(this.BT_GuardarElec_Click);
            // 
            // DGV_Elec
            // 
            this.DGV_Elec.AllowUserToAddRows = false;
            this.DGV_Elec.AllowUserToResizeColumns = false;
            this.DGV_Elec.AllowUserToResizeRows = false;
            this.DGV_Elec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Elec.Location = new System.Drawing.Point(14, 150);
            this.DGV_Elec.Name = "DGV_Elec";
            this.DGV_Elec.ReadOnly = true;
            this.DGV_Elec.RowHeadersVisible = false;
            this.DGV_Elec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Elec.Size = new System.Drawing.Size(362, 150);
            this.DGV_Elec.TabIndex = 19;
            this.DGV_Elec.SelectionChanged += new System.EventHandler(this.habilitarElecBotones);
            // 
            // TB_SNElec
            // 
            this.TB_SNElec.Location = new System.Drawing.Point(121, 96);
            this.TB_SNElec.Name = "TB_SNElec";
            this.TB_SNElec.Size = new System.Drawing.Size(100, 20);
            this.TB_SNElec.TabIndex = 9;
            this.TB_SNElec.TextChanged += new System.EventHandler(this.habilitarElecBotones);
            // 
            // LB_SNElec
            // 
            this.LB_SNElec.AutoSize = true;
            this.LB_SNElec.Location = new System.Drawing.Point(26, 98);
            this.LB_SNElec.Name = "LB_SNElec";
            this.LB_SNElec.Size = new System.Drawing.Size(84, 13);
            this.LB_SNElec.TabIndex = 15;
            this.LB_SNElec.Text = "Número de serie";
            // 
            // LB_ModeloElec
            // 
            this.LB_ModeloElec.AutoSize = true;
            this.LB_ModeloElec.Location = new System.Drawing.Point(26, 67);
            this.LB_ModeloElec.Name = "LB_ModeloElec";
            this.LB_ModeloElec.Size = new System.Drawing.Size(42, 13);
            this.LB_ModeloElec.TabIndex = 14;
            this.LB_ModeloElec.Text = "Modelo";
            // 
            // LB_MarcaElec
            // 
            this.LB_MarcaElec.AutoSize = true;
            this.LB_MarcaElec.Location = new System.Drawing.Point(26, 38);
            this.LB_MarcaElec.Name = "LB_MarcaElec";
            this.LB_MarcaElec.Size = new System.Drawing.Size(37, 13);
            this.LB_MarcaElec.TabIndex = 13;
            this.LB_MarcaElec.Text = "Marca";
            // 
            // GB_Camaras
            // 
            this.GB_Camaras.Controls.Add(this.BT_Camara_Cancelar);
            this.GB_Camaras.Controls.Add(this.BT_EliminarCam);
            this.GB_Camaras.Controls.Add(this.BT_EditarCam);
            this.GB_Camaras.Controls.Add(this.BT_GuardarCam);
            this.GB_Camaras.Controls.Add(this.DGV_Cam);
            this.GB_Camaras.Controls.Add(this.CB_ModCam);
            this.GB_Camaras.Controls.Add(this.CB_MarcaCam);
            this.GB_Camaras.Controls.Add(this.TB_SNCam);
            this.GB_Camaras.Controls.Add(this.LB_SNCam);
            this.GB_Camaras.Controls.Add(this.LB_ModCam);
            this.GB_Camaras.Controls.Add(this.LB_MarcaCam);
            this.GB_Camaras.Location = new System.Drawing.Point(3, 12);
            this.GB_Camaras.Name = "GB_Camaras";
            this.GB_Camaras.Size = new System.Drawing.Size(390, 354);
            this.GB_Camaras.TabIndex = 8;
            this.GB_Camaras.TabStop = false;
            this.GB_Camaras.Text = "Cámaras";
            // 
            // BT_Camara_Cancelar
            // 
            this.BT_Camara_Cancelar.Location = new System.Drawing.Point(265, 63);
            this.BT_Camara_Cancelar.Name = "BT_Camara_Cancelar";
            this.BT_Camara_Cancelar.Size = new System.Drawing.Size(119, 23);
            this.BT_Camara_Cancelar.TabIndex = 73;
            this.BT_Camara_Cancelar.Text = "Cancelar";
            this.BT_Camara_Cancelar.UseVisualStyleBackColor = true;
            this.BT_Camara_Cancelar.Click += new System.EventHandler(this.BT_Camara_Cancelar_Click);
            // 
            // BT_EliminarCam
            // 
            this.BT_EliminarCam.Location = new System.Drawing.Point(275, 315);
            this.BT_EliminarCam.Name = "BT_EliminarCam";
            this.BT_EliminarCam.Size = new System.Drawing.Size(96, 23);
            this.BT_EliminarCam.TabIndex = 6;
            this.BT_EliminarCam.Text = "Eliminar";
            this.BT_EliminarCam.UseVisualStyleBackColor = true;
            this.BT_EliminarCam.Click += new System.EventHandler(this.BT_EliminarCam_Click);
            // 
            // BT_EditarCam
            // 
            this.BT_EditarCam.Location = new System.Drawing.Point(143, 315);
            this.BT_EditarCam.Name = "BT_EditarCam";
            this.BT_EditarCam.Size = new System.Drawing.Size(96, 23);
            this.BT_EditarCam.TabIndex = 5;
            this.BT_EditarCam.Text = "Editar";
            this.BT_EditarCam.UseVisualStyleBackColor = true;
            this.BT_EditarCam.Click += new System.EventHandler(this.BT_EditarCam_Click);
            // 
            // BT_GuardarCam
            // 
            this.BT_GuardarCam.Location = new System.Drawing.Point(265, 28);
            this.BT_GuardarCam.Name = "BT_GuardarCam";
            this.BT_GuardarCam.Size = new System.Drawing.Size(119, 23);
            this.BT_GuardarCam.TabIndex = 4;
            this.BT_GuardarCam.Text = "Guardar";
            this.BT_GuardarCam.UseVisualStyleBackColor = true;
            this.BT_GuardarCam.Click += new System.EventHandler(this.BT_GuardarCam_Click);
            // 
            // DGV_Cam
            // 
            this.DGV_Cam.AllowUserToAddRows = false;
            this.DGV_Cam.AllowUserToResizeColumns = false;
            this.DGV_Cam.AllowUserToResizeRows = false;
            this.DGV_Cam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Cam.Location = new System.Drawing.Point(9, 150);
            this.DGV_Cam.Name = "DGV_Cam";
            this.DGV_Cam.ReadOnly = true;
            this.DGV_Cam.RowHeadersVisible = false;
            this.DGV_Cam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Cam.Size = new System.Drawing.Size(362, 150);
            this.DGV_Cam.TabIndex = 7;
            this.DGV_Cam.SelectionChanged += new System.EventHandler(this.habilitarCamBotones);
            // 
            // CB_ModCam
            // 
            this.CB_ModCam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ModCam.FormattingEnabled = true;
            this.CB_ModCam.Location = new System.Drawing.Point(116, 63);
            this.CB_ModCam.Name = "CB_ModCam";
            this.CB_ModCam.Size = new System.Drawing.Size(132, 21);
            this.CB_ModCam.TabIndex = 2;
            this.CB_ModCam.SelectedIndexChanged += new System.EventHandler(this.habilitarCamBotones);
            // 
            // CB_MarcaCam
            // 
            this.CB_MarcaCam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_MarcaCam.FormattingEnabled = true;
            this.CB_MarcaCam.Location = new System.Drawing.Point(116, 29);
            this.CB_MarcaCam.Name = "CB_MarcaCam";
            this.CB_MarcaCam.Size = new System.Drawing.Size(100, 21);
            this.CB_MarcaCam.TabIndex = 1;
            this.CB_MarcaCam.SelectedIndexChanged += new System.EventHandler(this.CB_MarcaCam_SelectedIndexChanged);
            // 
            // TB_SNCam
            // 
            this.TB_SNCam.Location = new System.Drawing.Point(116, 95);
            this.TB_SNCam.Name = "TB_SNCam";
            this.TB_SNCam.Size = new System.Drawing.Size(100, 20);
            this.TB_SNCam.TabIndex = 3;
            this.TB_SNCam.TextChanged += new System.EventHandler(this.habilitarCamBotones);
            // 
            // LB_SNCam
            // 
            this.LB_SNCam.AutoSize = true;
            this.LB_SNCam.Location = new System.Drawing.Point(21, 98);
            this.LB_SNCam.Name = "LB_SNCam";
            this.LB_SNCam.Size = new System.Drawing.Size(84, 13);
            this.LB_SNCam.TabIndex = 2;
            this.LB_SNCam.Text = "Número de serie";
            // 
            // LB_ModCam
            // 
            this.LB_ModCam.AutoSize = true;
            this.LB_ModCam.Location = new System.Drawing.Point(21, 66);
            this.LB_ModCam.Name = "LB_ModCam";
            this.LB_ModCam.Size = new System.Drawing.Size(42, 13);
            this.LB_ModCam.TabIndex = 1;
            this.LB_ModCam.Text = "Modelo";
            // 
            // LB_MarcaCam
            // 
            this.LB_MarcaCam.AutoSize = true;
            this.LB_MarcaCam.Location = new System.Drawing.Point(21, 38);
            this.LB_MarcaCam.Name = "LB_MarcaCam";
            this.LB_MarcaCam.Size = new System.Drawing.Size(37, 13);
            this.LB_MarcaCam.TabIndex = 0;
            this.LB_MarcaCam.Text = "Marca";
            // 
            // Form_SistemasDosimetricos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(810, 682);
            this.Controls.Add(this.Panel_SistDos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_SistemasDosimetricos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_SistemasDosimetricos";
            this.Load += new System.EventHandler(this.Form_SistemasDosimetricos_Load);
            this.Panel_SistDos.ResumeLayout(false);
            this.GB_SistDos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SistDos)).EndInit();
            this.GB_Electrómetros.ResumeLayout(false);
            this.GB_Electrómetros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Elec)).EndInit();
            this.GB_Camaras.ResumeLayout(false);
            this.GB_Camaras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Cam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Panel_SistDos;
        private System.Windows.Forms.GroupBox GB_SistDos;
        private System.Windows.Forms.Button BT_ExportarSistDos;
        private System.Windows.Forms.Button BT_EliminarSistDos;
        private System.Windows.Forms.Button BT_NuevSistDos;
        private System.Windows.Forms.DataGridView DGV_SistDos;
        private System.Windows.Forms.GroupBox GB_Electrómetros;
        private System.Windows.Forms.TextBox TB_ModeloElec;
        private System.Windows.Forms.TextBox TB_MarcaElec;
        private System.Windows.Forms.Button BT_EliminarElec;
        private System.Windows.Forms.Button BT_EditarElec;
        private System.Windows.Forms.Button BT_GuardarElec;
        private System.Windows.Forms.DataGridView DGV_Elec;
        private System.Windows.Forms.TextBox TB_SNElec;
        private System.Windows.Forms.Label LB_SNElec;
        private System.Windows.Forms.Label LB_ModeloElec;
        private System.Windows.Forms.Label LB_MarcaElec;
        private System.Windows.Forms.GroupBox GB_Camaras;
        private System.Windows.Forms.Button BT_EliminarCam;
        private System.Windows.Forms.Button BT_EditarCam;
        private System.Windows.Forms.Button BT_GuardarCam;
        private System.Windows.Forms.DataGridView DGV_Cam;
        private System.Windows.Forms.ComboBox CB_ModCam;
        private System.Windows.Forms.ComboBox CB_MarcaCam;
        private System.Windows.Forms.TextBox TB_SNCam;
        private System.Windows.Forms.Label LB_SNCam;
        private System.Windows.Forms.Label LB_ModCam;
        private System.Windows.Forms.Label LB_MarcaCam;
        private System.Windows.Forms.Button BT_PredSistDos;
        private System.Windows.Forms.Button BT_EditarSistDos;
        private System.Windows.Forms.Button BT_SistDosIraCal;
        private System.Windows.Forms.Button BT_Electrometro_Cancelar;
        private System.Windows.Forms.Button BT_Camara_Cancelar;
        private System.Windows.Forms.Button BT_ImportarSistDos;
    }
}

