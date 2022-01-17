namespace Presentador
{
    partial class EspecificacionProducto
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
            this.dgvEspecificaciones = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecificaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEspecificaciones
            // 
            this.dgvEspecificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEspecificaciones.Location = new System.Drawing.Point(42, 47);
            this.dgvEspecificaciones.Name = "dgvEspecificaciones";
            this.dgvEspecificaciones.Size = new System.Drawing.Size(420, 135);
            this.dgvEspecificaciones.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "StockDisponible";
            // 
            // EspecificacionProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 371);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvEspecificaciones);
            this.Name = "EspecificacionProducto";
            this.Text = "EspecificacionProducto";
            this.Load += new System.EventHandler(this.EspecificacionProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecificaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEspecificaciones;
        private System.Windows.Forms.Label label1;
    }
}