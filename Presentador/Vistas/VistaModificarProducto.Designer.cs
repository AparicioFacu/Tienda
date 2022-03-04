
namespace Presentador.Vistas
{
    partial class VistaModificarProducto
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
            this.button1 = new System.Windows.Forms.Button();
            this.panelTalleColor = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxTipoTalle = new System.Windows.Forms.ComboBox();
            this.cbxTalle = new System.Windows.Forms.ComboBox();
            this.cbxColor = new System.Windows.Forms.ComboBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtPrecioFinal = new System.Windows.Forms.TextBox();
            this.txtMargenGanancia = new System.Windows.Forms.TextBox();
            this.txtPorcentajeIVA = new System.Windows.Forms.TextBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cbxRubro = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxMarca = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label223 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.panelTalleColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.button1.Location = new System.Drawing.Point(427, 507);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 42);
            this.button1.TabIndex = 50;
            this.button1.Text = "Modificar Producto";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelTalleColor
            // 
            this.panelTalleColor.Controls.Add(this.btnEliminar);
            this.panelTalleColor.Controls.Add(this.label10);
            this.panelTalleColor.Controls.Add(this.dataGridView1);
            this.panelTalleColor.Controls.Add(this.btnGuardar);
            this.panelTalleColor.Controls.Add(this.label7);
            this.panelTalleColor.Controls.Add(this.label8);
            this.panelTalleColor.Controls.Add(this.label9);
            this.panelTalleColor.Controls.Add(this.cbxTipoTalle);
            this.panelTalleColor.Controls.Add(this.cbxTalle);
            this.panelTalleColor.Controls.Add(this.cbxColor);
            this.panelTalleColor.Controls.Add(this.txtStock);
            this.panelTalleColor.Location = new System.Drawing.Point(545, 12);
            this.panelTalleColor.Name = "panelTalleColor";
            this.panelTalleColor.Size = new System.Drawing.Size(444, 472);
            this.panelTalleColor.TabIndex = 49;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnEliminar.Location = new System.Drawing.Point(257, 246);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(108, 42);
            this.btnEliminar.TabIndex = 29;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(28, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 25);
            this.label10.TabIndex = 26;
            this.label10.Text = "TipoTalle";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(46, 306);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(359, 139);
            this.dataGridView1.TabIndex = 28;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnGuardar.Location = new System.Drawing.Point(65, 246);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(108, 42);
            this.btnGuardar.TabIndex = 24;
            this.btnGuardar.Text = "Agregar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 25);
            this.label7.TabIndex = 10;
            this.label7.Text = "Talle";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 25);
            this.label8.TabIndex = 11;
            this.label8.Text = "Color";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(28, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 25);
            this.label9.TabIndex = 12;
            this.label9.Text = "Stock";
            // 
            // cbxTipoTalle
            // 
            this.cbxTipoTalle.FormattingEnabled = true;
            this.cbxTipoTalle.Location = new System.Drawing.Point(153, 61);
            this.cbxTipoTalle.Name = "cbxTipoTalle";
            this.cbxTipoTalle.Size = new System.Drawing.Size(194, 21);
            this.cbxTipoTalle.TabIndex = 25;
            this.cbxTipoTalle.SelectedIndexChanged += new System.EventHandler(this.cbxTipoTalle_SelectedIndexChanged);
            // 
            // cbxTalle
            // 
            this.cbxTalle.FormattingEnabled = true;
            this.cbxTalle.Location = new System.Drawing.Point(153, 106);
            this.cbxTalle.Name = "cbxTalle";
            this.cbxTalle.Size = new System.Drawing.Size(194, 21);
            this.cbxTalle.TabIndex = 14;
            // 
            // cbxColor
            // 
            this.cbxColor.FormattingEnabled = true;
            this.cbxColor.Location = new System.Drawing.Point(153, 155);
            this.cbxColor.Name = "cbxColor";
            this.cbxColor.Size = new System.Drawing.Size(194, 21);
            this.cbxColor.TabIndex = 15;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(153, 197);
            this.txtStock.Multiline = true;
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(194, 25);
            this.txtStock.TabIndex = 22;
            // 
            // txtPrecioFinal
            // 
            this.txtPrecioFinal.Location = new System.Drawing.Point(194, 258);
            this.txtPrecioFinal.Multiline = true;
            this.txtPrecioFinal.Name = "txtPrecioFinal";
            this.txtPrecioFinal.Size = new System.Drawing.Size(194, 25);
            this.txtPrecioFinal.TabIndex = 46;
            // 
            // txtMargenGanancia
            // 
            this.txtMargenGanancia.Location = new System.Drawing.Point(194, 216);
            this.txtMargenGanancia.Multiline = true;
            this.txtMargenGanancia.Name = "txtMargenGanancia";
            this.txtMargenGanancia.Size = new System.Drawing.Size(194, 25);
            this.txtMargenGanancia.TabIndex = 45;
            this.txtMargenGanancia.TextChanged += new System.EventHandler(this.txtMargenGanancia_TextChanged);
            // 
            // txtPorcentajeIVA
            // 
            this.txtPorcentajeIVA.Location = new System.Drawing.Point(194, 171);
            this.txtPorcentajeIVA.Multiline = true;
            this.txtPorcentajeIVA.Name = "txtPorcentajeIVA";
            this.txtPorcentajeIVA.Size = new System.Drawing.Size(194, 25);
            this.txtPorcentajeIVA.TabIndex = 44;
            this.txtPorcentajeIVA.TextChanged += new System.EventHandler(this.txtPorcentajeIVA_TextChanged);
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(194, 125);
            this.txtCosto.Multiline = true;
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(194, 25);
            this.txtCosto.TabIndex = 43;
            this.txtCosto.TextChanged += new System.EventHandler(this.txtCosto_TextChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(194, 85);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(194, 25);
            this.txtDescripcion.TabIndex = 42;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(194, 40);
            this.txtCodigo.Multiline = true;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(194, 25);
            this.txtCodigo.TabIndex = 41;
            // 
            // cbxRubro
            // 
            this.cbxRubro.FormattingEnabled = true;
            this.cbxRubro.Location = new System.Drawing.Point(194, 343);
            this.cbxRubro.Name = "cbxRubro";
            this.cbxRubro.Size = new System.Drawing.Size(194, 21);
            this.cbxRubro.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 339);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 25);
            this.label6.TabIndex = 39;
            this.label6.Text = "Rubro";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 25);
            this.label5.TabIndex = 38;
            this.label5.Text = "Marca";
            // 
            // cbxMarca
            // 
            this.cbxMarca.FormattingEnabled = true;
            this.cbxMarca.Location = new System.Drawing.Point(194, 304);
            this.cbxMarca.Name = "cbxMarca";
            this.cbxMarca.Size = new System.Drawing.Size(194, 21);
            this.cbxMarca.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 25);
            this.label4.TabIndex = 36;
            this.label4.Text = "Precio Final";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 25);
            this.label3.TabIndex = 35;
            this.label3.Text = "Margen Ganancia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 25);
            this.label2.TabIndex = 34;
            this.label2.Text = "Porcentaje IVA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 33;
            this.label1.Text = "Costo";
            // 
            // label223
            // 
            this.label223.AutoSize = true;
            this.label223.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label223.Location = new System.Drawing.Point(20, 85);
            this.label223.Name = "label223";
            this.label223.Size = new System.Drawing.Size(114, 25);
            this.label223.TabIndex = 32;
            this.label223.Text = "Descripcion";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label111.Location = new System.Drawing.Point(20, 40);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(75, 25);
            this.label111.TabIndex = 31;
            this.label111.Text = "Codigo";
            // 
            // VistaModificarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelTalleColor);
            this.Controls.Add(this.txtPrecioFinal);
            this.Controls.Add(this.txtMargenGanancia);
            this.Controls.Add(this.txtPorcentajeIVA);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.cbxRubro);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxMarca);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label223);
            this.Controls.Add(this.label111);
            this.Name = "VistaModificarProducto";
            this.Text = "VistaModificarProducto";
            this.Load += new System.EventHandler(this.VistaModificarProducto_Load);
            this.panelTalleColor.ResumeLayout(false);
            this.panelTalleColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelTalleColor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxTipoTalle;
        private System.Windows.Forms.ComboBox cbxTalle;
        private System.Windows.Forms.ComboBox cbxColor;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtPrecioFinal;
        private System.Windows.Forms.TextBox txtMargenGanancia;
        private System.Windows.Forms.TextBox txtPorcentajeIVA;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.ComboBox cbxRubro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxMarca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label223;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.Button btnEliminar;
    }
}