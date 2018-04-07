namespace sistema_de_factura
{
    partial class Form_ListarUsuario
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
            this.dataGridViewUsuario = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.ColumncodUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnusuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuario)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewUsuario
            // 
            this.dataGridViewUsuario.AllowUserToAddRows = false;
            this.dataGridViewUsuario.AllowUserToDeleteRows = false;
            this.dataGridViewUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumncodUsuario,
            this.Columnusuario});
            this.dataGridViewUsuario.Location = new System.Drawing.Point(12, 119);
            this.dataGridViewUsuario.Name = "dataGridViewUsuario";
            this.dataGridViewUsuario.ReadOnly = true;
            this.dataGridViewUsuario.RowTemplate.Height = 24;
            this.dataGridViewUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsuario.Size = new System.Drawing.Size(735, 317);
            this.dataGridViewUsuario.TabIndex = 0;
            this.dataGridViewUsuario.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsuario_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBusqueda);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 101);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "datos de busqueda";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.Location = new System.Drawing.Point(312, 12);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(191, 101);
            this.btnBusqueda.TabIndex = 2;
            this.btnBusqueda.Text = "Busqueda";
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(6, 39);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(257, 35);
            this.txtBusqueda.TabIndex = 0;
            // 
            // ColumncodUsuario
            // 
            this.ColumncodUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumncodUsuario.DataPropertyName = "usuarioid";
            this.ColumncodUsuario.HeaderText = "Codigo de usuario";
            this.ColumncodUsuario.Name = "ColumncodUsuario";
            this.ColumncodUsuario.ReadOnly = true;
            // 
            // Columnusuario
            // 
            this.Columnusuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Columnusuario.DataPropertyName = "usuario";
            this.Columnusuario.HeaderText = "Nombre de usuario";
            this.Columnusuario.Name = "Columnusuario";
            this.Columnusuario.ReadOnly = true;
            // 
            // Form_ListarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 448);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewUsuario);
            this.Name = "Form_ListarUsuario";
            this.Text = "Lista de Usuario";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuario)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUsuario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumncodUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnusuario;
    }
}