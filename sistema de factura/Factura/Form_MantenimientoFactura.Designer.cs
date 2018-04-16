namespace sistema_de_factura.Factura
{
    partial class Form_MantenimientoFactura
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodProveedor = new System.Windows.Forms.TextBox();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.txtSaldoFinal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSaldoInicial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBuscarProveedor = new System.Windows.Forms.Button();
            this.txtProveedorNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtClienteNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodFactura = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnProducto = new System.Windows.Forms.Button();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodProducto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DataGridViewDetalleFactura = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.ColumnCodProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDetalleFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCodProveedor);
            this.groupBox1.Controls.Add(this.txtCodCliente);
            this.groupBox1.Controls.Add(this.txtSaldoFinal);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSaldoInicial);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnBuscarProveedor);
            this.groupBox1.Controls.Add(this.txtProveedorNombre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnBuscarCliente);
            this.groupBox1.Controls.Add(this.txtClienteNombre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCodFactura);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(702, 247);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la Factura";
            // 
            // txtCodProveedor
            // 
            this.txtCodProveedor.Location = new System.Drawing.Point(190, 110);
            this.txtCodProveedor.Name = "txtCodProveedor";
            this.txtCodProveedor.Size = new System.Drawing.Size(133, 32);
            this.txtCodProveedor.TabIndex = 2;
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(190, 72);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(133, 32);
            this.txtCodCliente.TabIndex = 0;
            // 
            // txtSaldoFinal
            // 
            this.txtSaldoFinal.Location = new System.Drawing.Point(190, 186);
            this.txtSaldoFinal.Name = "txtSaldoFinal";
            this.txtSaldoFinal.Size = new System.Drawing.Size(423, 32);
            this.txtSaldoFinal.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Saldo Final:";
            // 
            // txtSaldoInicial
            // 
            this.txtSaldoInicial.Location = new System.Drawing.Point(190, 148);
            this.txtSaldoInicial.Name = "txtSaldoInicial";
            this.txtSaldoInicial.Size = new System.Drawing.Size(423, 32);
            this.txtSaldoInicial.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Saldo Inicial:";
            // 
            // btnBuscarProveedor
            // 
            this.btnBuscarProveedor.Location = new System.Drawing.Point(619, 110);
            this.btnBuscarProveedor.Name = "btnBuscarProveedor";
            this.btnBuscarProveedor.Size = new System.Drawing.Size(75, 32);
            this.btnBuscarProveedor.TabIndex = 3;
            this.btnBuscarProveedor.Text = "...";
            this.btnBuscarProveedor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscarProveedor.UseVisualStyleBackColor = true;
            this.btnBuscarProveedor.Click += new System.EventHandler(this.btnBuscarProveedor_Click);
            // 
            // txtProveedorNombre
            // 
            this.txtProveedorNombre.Location = new System.Drawing.Point(329, 110);
            this.txtProveedorNombre.Name = "txtProveedorNombre";
            this.txtProveedorNombre.ReadOnly = true;
            this.txtProveedorNombre.Size = new System.Drawing.Size(284, 32);
            this.txtProveedorNombre.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Proveedor:";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Location = new System.Drawing.Point(621, 72);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(75, 32);
            this.btnBuscarCliente.TabIndex = 1;
            this.btnBuscarCliente.Text = "...";
            this.btnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtClienteNombre
            // 
            this.txtClienteNombre.Location = new System.Drawing.Point(329, 72);
            this.txtClienteNombre.Name = "txtClienteNombre";
            this.txtClienteNombre.ReadOnly = true;
            this.txtClienteNombre.Size = new System.Drawing.Size(284, 32);
            this.txtClienteNombre.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente:";
            // 
            // txtCodFactura
            // 
            this.txtCodFactura.Location = new System.Drawing.Point(190, 34);
            this.txtCodFactura.Name = "txtCodFactura";
            this.txtCodFactura.ReadOnly = true;
            this.txtCodFactura.Size = new System.Drawing.Size(216, 32);
            this.txtCodFactura.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo de Factura:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCantidad);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtPrecio);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.btnProducto);
            this.groupBox2.Controls.Add(this.txtNombreProducto);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCodProducto);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 273);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(702, 258);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de Producto";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(194, 157);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(197, 32);
            this.txtCantidad.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(88, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 24);
            this.label9.TabIndex = 8;
            this.label9.Text = "Cantidad:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(194, 119);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(199, 32);
            this.txtPrecio.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(106, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 24);
            this.label8.TabIndex = 6;
            this.label8.Text = "Precio:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(190, 195);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(112, 50);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnProducto
            // 
            this.btnProducto.Location = new System.Drawing.Point(318, 43);
            this.btnProducto.Name = "btnProducto";
            this.btnProducto.Size = new System.Drawing.Size(75, 32);
            this.btnProducto.TabIndex = 1;
            this.btnProducto.Text = "...";
            this.btnProducto.UseVisualStyleBackColor = true;
            this.btnProducto.Click += new System.EventHandler(this.btnProducto_Click);
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(194, 81);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.ReadOnly = true;
            this.txtNombreProducto.Size = new System.Drawing.Size(502, 32);
            this.txtNombreProducto.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 24);
            this.label7.TabIndex = 2;
            this.label7.Text = "Nombre Producto:";
            // 
            // txtCodProducto
            // 
            this.txtCodProducto.Location = new System.Drawing.Point(194, 43);
            this.txtCodProducto.Name = "txtCodProducto";
            this.txtCodProducto.Size = new System.Drawing.Size(118, 32);
            this.txtCodProducto.TabIndex = 0;
            this.txtCodProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodProducto_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cod Producto:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DataGridViewDetalleFactura);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(720, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(760, 515);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detalle Factura";
            // 
            // DataGridViewDetalleFactura
            // 
            this.DataGridViewDetalleFactura.AllowUserToAddRows = false;
            this.DataGridViewDetalleFactura.AllowUserToDeleteRows = false;
            this.DataGridViewDetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewDetalleFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCodProducto,
            this.ColumnNombreProducto,
            this.ColumnCantidad,
            this.ColumnPrecio,
            this.ColumnDelete});
            this.DataGridViewDetalleFactura.Location = new System.Drawing.Point(6, 31);
            this.DataGridViewDetalleFactura.MultiSelect = false;
            this.DataGridViewDetalleFactura.Name = "DataGridViewDetalleFactura";
            this.DataGridViewDetalleFactura.RowHeadersVisible = false;
            this.DataGridViewDetalleFactura.RowTemplate.Height = 24;
            this.DataGridViewDetalleFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewDetalleFactura.Size = new System.Drawing.Size(731, 471);
            this.DataGridViewDetalleFactura.TabIndex = 0;
            this.DataGridViewDetalleFactura.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewDetalleFactura_CellClick);
            this.DataGridViewDetalleFactura.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewDetalleFactura_CellEnter);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(12, 537);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 47);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // ColumnCodProducto
            // 
            this.ColumnCodProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCodProducto.HeaderText = "Codigo";
            this.ColumnCodProducto.Name = "ColumnCodProducto";
            // 
            // ColumnNombreProducto
            // 
            this.ColumnNombreProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnNombreProducto.HeaderText = "Nombre Producto";
            this.ColumnNombreProducto.Name = "ColumnNombreProducto";
            // 
            // ColumnCantidad
            // 
            this.ColumnCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCantidad.HeaderText = "Cantidad";
            this.ColumnCantidad.Name = "ColumnCantidad";
            // 
            // ColumnPrecio
            // 
            this.ColumnPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPrecio.HeaderText = "Precio";
            this.ColumnPrecio.Name = "ColumnPrecio";
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnDelete.HeaderText = "Accion";
            this.ColumnDelete.Name = "ColumnDelete";
            this.ColumnDelete.Text = "Eliminar";
            this.ColumnDelete.UseColumnTextForButtonValue = true;
            // 
            // Form_MantenimientoFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1526, 604);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_MantenimientoFactura";
            this.Text = "Mantenimiento Factura";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDetalleFactura)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtClienteNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscarProveedor;
        private System.Windows.Forms.TextBox txtProveedorNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSaldoFinal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSaldoInicial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodProveedor;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCodProducto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnProducto;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView DataGridViewDetalleFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCodProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrecio;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnDelete;
    }
}