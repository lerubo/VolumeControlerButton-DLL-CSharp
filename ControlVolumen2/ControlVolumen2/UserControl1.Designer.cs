namespace ControlVolumen2
{
    partial class Controlador
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.img_Altavoz = new System.Windows.Forms.PictureBox();
            this.lbl_Porcentaje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.img_Altavoz)).BeginInit();
            this.SuspendLayout();
            // 
            // img_Altavoz
            // 
            this.img_Altavoz.Image = global::ControlVolumen2.Properties.Resources.altavozMedio;
            this.img_Altavoz.Location = new System.Drawing.Point(0, 0);
            this.img_Altavoz.Name = "img_Altavoz";
            this.img_Altavoz.Size = new System.Drawing.Size(100, 100);
            this.img_Altavoz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_Altavoz.TabIndex = 0;
            this.img_Altavoz.TabStop = false;
            this.img_Altavoz.Click += new System.EventHandler(this.img_Altavoz_Click);
            // 
            // lbl_Porcentaje
            // 
            this.lbl_Porcentaje.AutoSize = true;
            this.lbl_Porcentaje.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Porcentaje.Font = new System.Drawing.Font("Decker", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Porcentaje.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_Porcentaje.Location = new System.Drawing.Point(106, 39);
            this.lbl_Porcentaje.Name = "lbl_Porcentaje";
            this.lbl_Porcentaje.Size = new System.Drawing.Size(49, 19);
            this.lbl_Porcentaje.TabIndex = 1;
            this.lbl_Porcentaje.Text = "0000";
            // 
            // Controlador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_Porcentaje);
            this.Controls.Add(this.img_Altavoz);
            this.MaximumSize = new System.Drawing.Size(500, 100);
            this.MinimumSize = new System.Drawing.Size(500, 100);
            this.Name = "Controlador";
            this.Size = new System.Drawing.Size(500, 100);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Controlador_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Controlador_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Controlador_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.img_Altavoz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox img_Altavoz;
        private System.Windows.Forms.Label lbl_Porcentaje;
    }
}
