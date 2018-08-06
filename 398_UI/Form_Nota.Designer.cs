namespace _398_UI
{
    partial class Form_Nota
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
            this.TB_TextoNota = new System.Windows.Forms.TextBox();
            this.BT_AdjuntarImagen = new System.Windows.Forms.Button();
            this.BT_GuardarNota = new System.Windows.Forms.Button();
            this.BT_EliminarNota = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TB_TextoNota
            // 
            this.TB_TextoNota.Location = new System.Drawing.Point(20, 61);
            this.TB_TextoNota.Multiline = true;
            this.TB_TextoNota.Name = "TB_TextoNota";
            this.TB_TextoNota.Size = new System.Drawing.Size(225, 132);
            this.TB_TextoNota.TabIndex = 0;
            // 
            // BT_AdjuntarImagen
            // 
            this.BT_AdjuntarImagen.Location = new System.Drawing.Point(143, 12);
            this.BT_AdjuntarImagen.Name = "BT_AdjuntarImagen";
            this.BT_AdjuntarImagen.Size = new System.Drawing.Size(102, 23);
            this.BT_AdjuntarImagen.TabIndex = 1;
            this.BT_AdjuntarImagen.Text = "Agregar imagen";
            this.BT_AdjuntarImagen.UseVisualStyleBackColor = true;
            // 
            // BT_GuardarNota
            // 
            this.BT_GuardarNota.Location = new System.Drawing.Point(34, 208);
            this.BT_GuardarNota.Name = "BT_GuardarNota";
            this.BT_GuardarNota.Size = new System.Drawing.Size(75, 23);
            this.BT_GuardarNota.TabIndex = 2;
            this.BT_GuardarNota.Text = "Guardar";
            this.BT_GuardarNota.UseVisualStyleBackColor = true;
            // 
            // BT_EliminarNota
            // 
            this.BT_EliminarNota.Location = new System.Drawing.Point(153, 208);
            this.BT_EliminarNota.Name = "BT_EliminarNota";
            this.BT_EliminarNota.Size = new System.Drawing.Size(75, 23);
            this.BT_EliminarNota.TabIndex = 3;
            this.BT_EliminarNota.Text = "Cancelar";
            this.BT_EliminarNota.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nota para:";
            // 
            // Form_Nota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 243);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BT_EliminarNota);
            this.Controls.Add(this.BT_GuardarNota);
            this.Controls.Add(this.BT_AdjuntarImagen);
            this.Controls.Add(this.TB_TextoNota);
            this.Name = "Form_Nota";
            this.Text = "Nota";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_TextoNota;
        private System.Windows.Forms.Button BT_AdjuntarImagen;
        private System.Windows.Forms.Button BT_GuardarNota;
        private System.Windows.Forms.Button BT_EliminarNota;
        private System.Windows.Forms.Label label1;
    }
}