namespace _398_UI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Panel_Equipos = new System.Windows.Forms.Panel();
            this.Panel_SistDos = new System.Windows.Forms.Panel();
            this.Panel_Inicio = new System.Windows.Forms.Panel();
            this.Bt_CalFot = new System.Windows.Forms.Button();
            this.Bt_SistDos = new System.Windows.Forms.Button();
            this.Bt_Equipos = new System.Windows.Forms.Button();
            this.Bt_AnalizarReg = new System.Windows.Forms.Button();
            this.Bt_Inicio = new System.Windows.Forms.Button();
            this.Panel_AnalizarReg = new System.Windows.Forms.Panel();
            this.Bt_CalElec = new System.Windows.Forms.Button();
            this.Panel_Botones = new System.Windows.Forms.Panel();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Panel_CalFot = new System.Windows.Forms.Panel();
            this.BT_CerrarCalFotones = new System.Windows.Forms.Button();
            this.BT_NuevaCalFotones = new System.Windows.Forms.Button();
            this.TabC_CaliFotones = new System.Windows.Forms.TabControl();
            this.Panel_CalElec = new System.Windows.Forms.Panel();
            this.BT_CerrarCalElectrones = new System.Windows.Forms.Button();
            this.BT_NuevaCalElectrones = new System.Windows.Forms.Button();
            this.TabC_CaliElectrones = new System.Windows.Forms.TabControl();
            this.Panel_Botones.SuspendLayout();
            this.Panel_CalFot.SuspendLayout();
            this.Panel_CalElec.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Equipos
            // 
            this.Panel_Equipos.Location = new System.Drawing.Point(0, 0);
            this.Panel_Equipos.Name = "Panel_Equipos";
            this.Panel_Equipos.Size = new System.Drawing.Size(870, 700);
            this.Panel_Equipos.TabIndex = 1;
            this.Panel_Equipos.Visible = false;
            // 
            // Panel_SistDos
            // 
            this.Panel_SistDos.Location = new System.Drawing.Point(0, 0);
            this.Panel_SistDos.Name = "Panel_SistDos";
            this.Panel_SistDos.Size = new System.Drawing.Size(870, 700);
            this.Panel_SistDos.TabIndex = 2;
            // 
            // Panel_Inicio
            // 
            this.Panel_Inicio.Location = new System.Drawing.Point(0, 0);
            this.Panel_Inicio.Name = "Panel_Inicio";
            this.Panel_Inicio.Size = new System.Drawing.Size(870, 700);
            this.Panel_Inicio.TabIndex = 1;
            // 
            // Bt_CalFot
            // 
            this.Bt_CalFot.BackColor = System.Drawing.SystemColors.Control;
            this.Bt_CalFot.FlatAppearance.BorderSize = 0;
            this.Bt_CalFot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_CalFot.Location = new System.Drawing.Point(0, 0);
            this.Bt_CalFot.Name = "Bt_CalFot";
            this.Bt_CalFot.Size = new System.Drawing.Size(130, 50);
            this.Bt_CalFot.TabIndex = 3;
            this.Bt_CalFot.Text = "Calibración fotones";
            this.Bt_CalFot.UseVisualStyleBackColor = false;
            this.Bt_CalFot.Click += new System.EventHandler(this.Bt_CalFot_Click);
            // 
            // Bt_SistDos
            // 
            this.Bt_SistDos.BackColor = System.Drawing.SystemColors.Control;
            this.Bt_SistDos.FlatAppearance.BorderSize = 0;
            this.Bt_SistDos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_SistDos.Location = new System.Drawing.Point(0, 100);
            this.Bt_SistDos.Name = "Bt_SistDos";
            this.Bt_SistDos.Size = new System.Drawing.Size(130, 50);
            this.Bt_SistDos.TabIndex = 4;
            this.Bt_SistDos.Text = "Sistemas Dosimétricos";
            this.Bt_SistDos.UseVisualStyleBackColor = false;
            this.Bt_SistDos.Click += new System.EventHandler(this.Bt_SistDos_Click);
            // 
            // Bt_Equipos
            // 
            this.Bt_Equipos.FlatAppearance.BorderSize = 0;
            this.Bt_Equipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Equipos.Location = new System.Drawing.Point(0, 150);
            this.Bt_Equipos.Name = "Bt_Equipos";
            this.Bt_Equipos.Size = new System.Drawing.Size(130, 50);
            this.Bt_Equipos.TabIndex = 5;
            this.Bt_Equipos.Text = "Equipos";
            this.Bt_Equipos.UseVisualStyleBackColor = true;
            this.Bt_Equipos.Click += new System.EventHandler(this.Bt_Equipos_Click);
            // 
            // Bt_AnalizarReg
            // 
            this.Bt_AnalizarReg.FlatAppearance.BorderSize = 0;
            this.Bt_AnalizarReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_AnalizarReg.Location = new System.Drawing.Point(0, 200);
            this.Bt_AnalizarReg.Name = "Bt_AnalizarReg";
            this.Bt_AnalizarReg.Size = new System.Drawing.Size(130, 50);
            this.Bt_AnalizarReg.TabIndex = 6;
            this.Bt_AnalizarReg.Text = "Analizar Registros";
            this.Bt_AnalizarReg.UseVisualStyleBackColor = true;
            this.Bt_AnalizarReg.Click += new System.EventHandler(this.Bt_AnalizarReg_Click);
            // 
            // Bt_Inicio
            // 
            this.Bt_Inicio.FlatAppearance.BorderSize = 0;
            this.Bt_Inicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Inicio.Location = new System.Drawing.Point(0, 640);
            this.Bt_Inicio.Name = "Bt_Inicio";
            this.Bt_Inicio.Size = new System.Drawing.Size(130, 50);
            this.Bt_Inicio.TabIndex = 7;
            this.Bt_Inicio.Text = "Volver al Inicio";
            this.Bt_Inicio.UseVisualStyleBackColor = true;
            this.Bt_Inicio.Click += new System.EventHandler(this.Bt_Inicio_Click);
            // 
            // Panel_AnalizarReg
            // 
            this.Panel_AnalizarReg.Location = new System.Drawing.Point(0, 0);
            this.Panel_AnalizarReg.Name = "Panel_AnalizarReg";
            this.Panel_AnalizarReg.Size = new System.Drawing.Size(870, 700);
            this.Panel_AnalizarReg.TabIndex = 2;
            // 
            // Bt_CalElec
            // 
            this.Bt_CalElec.FlatAppearance.BorderSize = 0;
            this.Bt_CalElec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_CalElec.Location = new System.Drawing.Point(0, 50);
            this.Bt_CalElec.Name = "Bt_CalElec";
            this.Bt_CalElec.Size = new System.Drawing.Size(130, 50);
            this.Bt_CalElec.TabIndex = 8;
            this.Bt_CalElec.Text = "Calibración electrones";
            this.Bt_CalElec.UseVisualStyleBackColor = true;
            this.Bt_CalElec.Click += new System.EventHandler(this.Bt_CalElec_Click);
            // 
            // Panel_Botones
            // 
            this.Panel_Botones.Controls.Add(this.Bt_CalFot);
            this.Panel_Botones.Controls.Add(this.Bt_Inicio);
            this.Panel_Botones.Controls.Add(this.Bt_CalElec);
            this.Panel_Botones.Controls.Add(this.Bt_AnalizarReg);
            this.Panel_Botones.Controls.Add(this.Bt_SistDos);
            this.Panel_Botones.Controls.Add(this.Bt_Equipos);
            this.Panel_Botones.Location = new System.Drawing.Point(874, 0);
            this.Panel_Botones.Name = "Panel_Botones";
            this.Panel_Botones.Size = new System.Drawing.Size(134, 697);
            this.Panel_Botones.TabIndex = 11;
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
            // Panel_CalFot
            // 
            this.Panel_CalFot.Controls.Add(this.BT_CerrarCalFotones);
            this.Panel_CalFot.Controls.Add(this.BT_NuevaCalFotones);
            this.Panel_CalFot.Controls.Add(this.TabC_CaliFotones);
            this.Panel_CalFot.Location = new System.Drawing.Point(0, 0);
            this.Panel_CalFot.Name = "Panel_CalFot";
            this.Panel_CalFot.Size = new System.Drawing.Size(870, 700);
            this.Panel_CalFot.TabIndex = 0;
            // 
            // BT_CerrarCalFotones
            // 
            this.BT_CerrarCalFotones.Location = new System.Drawing.Point(786, 56);
            this.BT_CerrarCalFotones.Name = "BT_CerrarCalFotones";
            this.BT_CerrarCalFotones.Size = new System.Drawing.Size(72, 37);
            this.BT_CerrarCalFotones.TabIndex = 2;
            this.BT_CerrarCalFotones.Text = "Cerrar Calibración";
            this.BT_CerrarCalFotones.UseVisualStyleBackColor = true;
            this.BT_CerrarCalFotones.Click += new System.EventHandler(this.BT_CerrarCalFotones_Click);
            // 
            // BT_NuevaCalFotones
            // 
            this.BT_NuevaCalFotones.Location = new System.Drawing.Point(786, 7);
            this.BT_NuevaCalFotones.Name = "BT_NuevaCalFotones";
            this.BT_NuevaCalFotones.Size = new System.Drawing.Size(72, 37);
            this.BT_NuevaCalFotones.TabIndex = 1;
            this.BT_NuevaCalFotones.Text = "Nueva Calibración";
            this.BT_NuevaCalFotones.UseVisualStyleBackColor = true;
            this.BT_NuevaCalFotones.Click += new System.EventHandler(this.BT_NuevaCalFotones_Click);
            // 
            // TabC_CaliFotones
            // 
            this.TabC_CaliFotones.Location = new System.Drawing.Point(0, 0);
            this.TabC_CaliFotones.Name = "TabC_CaliFotones";
            this.TabC_CaliFotones.SelectedIndex = 0;
            this.TabC_CaliFotones.Size = new System.Drawing.Size(804, 700);
            this.TabC_CaliFotones.TabIndex = 0;
            // 
            // Panel_CalElec
            // 
            this.Panel_CalElec.Controls.Add(this.BT_CerrarCalElectrones);
            this.Panel_CalElec.Controls.Add(this.BT_NuevaCalElectrones);
            this.Panel_CalElec.Controls.Add(this.TabC_CaliElectrones);
            this.Panel_CalElec.Location = new System.Drawing.Point(4, 0);
            this.Panel_CalElec.Name = "Panel_CalElec";
            this.Panel_CalElec.Size = new System.Drawing.Size(870, 700);
            this.Panel_CalElec.TabIndex = 12;
            // 
            // BT_CerrarCalElectrones
            // 
            this.BT_CerrarCalElectrones.Location = new System.Drawing.Point(786, 56);
            this.BT_CerrarCalElectrones.Name = "BT_CerrarCalElectrones";
            this.BT_CerrarCalElectrones.Size = new System.Drawing.Size(72, 37);
            this.BT_CerrarCalElectrones.TabIndex = 2;
            this.BT_CerrarCalElectrones.Text = "Cerrar Calibración";
            this.BT_CerrarCalElectrones.UseVisualStyleBackColor = true;
            this.BT_CerrarCalElectrones.Click += new System.EventHandler(this.BT_CerrarCalElectrones_Click);
            // 
            // BT_NuevaCalElectrones
            // 
            this.BT_NuevaCalElectrones.Location = new System.Drawing.Point(786, 7);
            this.BT_NuevaCalElectrones.Name = "BT_NuevaCalElectrones";
            this.BT_NuevaCalElectrones.Size = new System.Drawing.Size(72, 37);
            this.BT_NuevaCalElectrones.TabIndex = 1;
            this.BT_NuevaCalElectrones.Text = "Nueva Calibración";
            this.BT_NuevaCalElectrones.UseVisualStyleBackColor = true;
            this.BT_NuevaCalElectrones.Click += new System.EventHandler(this.BT_NuevaCalElectrones_Click);
            // 
            // TabC_CaliElectrones
            // 
            this.TabC_CaliElectrones.Location = new System.Drawing.Point(0, 0);
            this.TabC_CaliElectrones.Name = "TabC_CaliElectrones";
            this.TabC_CaliElectrones.SelectedIndex = 0;
            this.TabC_CaliElectrones.Size = new System.Drawing.Size(804, 700);
            this.TabC_CaliElectrones.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1008, 692);
            this.Controls.Add(this.Panel_CalElec);
            this.Controls.Add(this.Panel_CalFot);
            this.Controls.Add(this.Panel_Inicio);
            this.Controls.Add(this.Panel_AnalizarReg);
            this.Controls.Add(this.Panel_SistDos);
            this.Controls.Add(this.Panel_Equipos);
            this.Controls.Add(this.Panel_Botones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Panel_Botones.ResumeLayout(false);
            this.Panel_CalFot.ResumeLayout(false);
            this.Panel_CalElec.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Panel_Equipos;
        private System.Windows.Forms.Panel Panel_SistDos;
        private System.Windows.Forms.Panel Panel_Inicio;
        private System.Windows.Forms.Button Bt_CalFot;
        private System.Windows.Forms.Button Bt_SistDos;
        private System.Windows.Forms.Button Bt_Equipos;
        private System.Windows.Forms.Button Bt_AnalizarReg;
        private System.Windows.Forms.Button Bt_Inicio;
        private System.Windows.Forms.Panel Panel_AnalizarReg;
        private System.Windows.Forms.Button Bt_CalElec;
        private System.Windows.Forms.Panel Panel_Botones;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel Panel_CalFot;
        private System.Windows.Forms.TabControl TabC_CaliFotones;
        private System.Windows.Forms.Button BT_CerrarCalFotones;
        private System.Windows.Forms.Button BT_NuevaCalFotones;
        private System.Windows.Forms.Panel Panel_CalElec;
        private System.Windows.Forms.Button BT_CerrarCalElectrones;
        private System.Windows.Forms.Button BT_NuevaCalElectrones;
        private System.Windows.Forms.TabControl TabC_CaliElectrones;
    }
}

