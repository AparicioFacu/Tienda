namespace Presentador
{
    partial class ListaProducto
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
            this.dvgProductos = new System.Windows.Forms.DataGridView();
            this.btnProducto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgProductos
            // 
            this.dvgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgProductos.Location = new System.Drawing.Point(30, 142);
            this.dvgProductos.Name = "dvgProductos";
            this.dvgProductos.Size = new System.Drawing.Size(832, 245);
            this.dvgProductos.TabIndex = 0;
            this.dvgProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgProductos_CellClick);
            this.dvgProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgProductos_CellContentClick);
            // 
            // btnProducto
            // 
            this.btnProducto.Location = new System.Drawing.Point(373, 57);
            this.btnProducto.Name = "btnProducto";
            this.btnProducto.Size = new System.Drawing.Size(119, 45);
            this.btnProducto.TabIndex = 1;
            this.btnProducto.Text = "Agregar Producto";
            this.btnProducto.UseVisualStyleBackColor = true;
            this.btnProducto.Click += new System.EventHandler(this.btnProducto_Click);
            // 
            // ListaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 450);
            this.Controls.Add(this.btnProducto);
            this.Controls.Add(this.dvgProductos);
            this.Name = "ListaProducto";
            this.Text = "ListaProducto";
            this.Load += new System.EventHandler(this.ListaProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgProductos;
        private System.Windows.Forms.Button btnProducto;
    }
}