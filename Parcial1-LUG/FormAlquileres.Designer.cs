namespace Parcial1_LUG
{
    partial class FormAlquileres
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            grpDatos = new GroupBox();
            lblTipoBicicleta = new Label();
            cmbTipoBicicleta = new ComboBox();
            btnLimpiar = new Button();
            lblDni = new Label();
            btnEliminar = new Button();
            txtDni = new TextBox();
            btnModificar = new Button();
            lblImporte = new Label();
            txtImporte = new TextBox();
            btnRegistrar = new Button();
            lblFechaAlquiler = new Label();
            dtpFechaAlquiler = new DateTimePicker();
            lblNumeroAlquiler = new Label();
            txtNumeroAlquiler = new TextBox();
            btnBuscar = new Button();
            btnListar = new Button();
            dgvAlquileres = new DataGridView();
            groupBox1 = new GroupBox();
            grpBorrador = new GroupBox();
            lstBorrador = new ListBox();
            btnAgregarBorrador = new Button();
            btnConfirmarBorrador = new Button();
            grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlquileres).BeginInit();
            groupBox1.SuspendLayout();
            grpBorrador.SuspendLayout();
            SuspendLayout();
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(lblTipoBicicleta);
            grpDatos.Controls.Add(cmbTipoBicicleta);
            grpDatos.Controls.Add(btnLimpiar);
            grpDatos.Controls.Add(lblDni);
            grpDatos.Controls.Add(btnEliminar);
            grpDatos.Controls.Add(txtDni);
            grpDatos.Controls.Add(btnModificar);
            grpDatos.Controls.Add(lblImporte);
            grpDatos.Controls.Add(txtImporte);
            grpDatos.Controls.Add(btnRegistrar);
            grpDatos.Controls.Add(lblFechaAlquiler);
            grpDatos.Controls.Add(dtpFechaAlquiler);
            grpDatos.Location = new Point(14, 16);
            grpDatos.Margin = new Padding(3, 4, 3, 4);
            grpDatos.Name = "grpDatos";
            grpDatos.Padding = new Padding(3, 4, 3, 4);
            grpDatos.Size = new Size(411, 347);
            grpDatos.TabIndex = 0;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos del alquiler";
            // 
            // lblTipoBicicleta
            // 
            lblTipoBicicleta.AutoSize = true;
            lblTipoBicicleta.Location = new Point(21, 47);
            lblTipoBicicleta.Name = "lblTipoBicicleta";
            lblTipoBicicleta.Size = new Size(123, 20);
            lblTipoBicicleta.TabIndex = 0;
            lblTipoBicicleta.Text = "Tipo de bicicleta:";
            // 
            // cmbTipoBicicleta
            // 
            cmbTipoBicicleta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoBicicleta.FormattingEnabled = true;
            cmbTipoBicicleta.Location = new Point(171, 43);
            cmbTipoBicicleta.Margin = new Padding(3, 4, 3, 4);
            cmbTipoBicicleta.Name = "cmbTipoBicicleta";
            cmbTipoBicicleta.Size = new Size(217, 28);
            cmbTipoBicicleta.TabIndex = 1;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(239, 290);
            btnLimpiar.Margin = new Padding(3, 4, 3, 4);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(149, 40);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(21, 96);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(111, 20);
            lblDni.TabIndex = 2;
            lblDni.Text = "DNI del cliente:";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(21, 290);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(149, 40);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(171, 92);
            txtDni.Margin = new Padding(3, 4, 3, 4);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(217, 27);
            txtDni.TabIndex = 3;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(239, 226);
            btnModificar.Margin = new Padding(3, 4, 3, 4);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(149, 40);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // lblImporte
            // 
            lblImporte.AutoSize = true;
            lblImporte.Location = new Point(21, 145);
            lblImporte.Name = "lblImporte";
            lblImporte.Size = new Size(100, 20);
            lblImporte.TabIndex = 4;
            lblImporte.Text = "Importe total:";
            // 
            // txtImporte
            // 
            txtImporte.Location = new Point(171, 141);
            txtImporte.Margin = new Padding(3, 4, 3, 4);
            txtImporte.Name = "txtImporte";
            txtImporte.Size = new Size(217, 27);
            txtImporte.TabIndex = 5;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(21, 231);
            btnRegistrar.Margin = new Padding(3, 4, 3, 4);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(149, 40);
            btnRegistrar.TabIndex = 1;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // lblFechaAlquiler
            // 
            lblFechaAlquiler.AutoSize = true;
            lblFechaAlquiler.Location = new Point(21, 195);
            lblFechaAlquiler.Name = "lblFechaAlquiler";
            lblFechaAlquiler.Size = new Size(129, 20);
            lblFechaAlquiler.TabIndex = 6;
            lblFechaAlquiler.Text = "Fecha del alquiler:";
            // 
            // dtpFechaAlquiler
            // 
            dtpFechaAlquiler.Format = DateTimePickerFormat.Short;
            dtpFechaAlquiler.Location = new Point(171, 191);
            dtpFechaAlquiler.Margin = new Padding(3, 4, 3, 4);
            dtpFechaAlquiler.Name = "dtpFechaAlquiler";
            dtpFechaAlquiler.Size = new Size(217, 27);
            dtpFechaAlquiler.TabIndex = 7;
            // 
            // lblNumeroAlquiler
            // 
            lblNumeroAlquiler.AutoSize = true;
            lblNumeroAlquiler.Location = new Point(18, 31);
            lblNumeroAlquiler.Name = "lblNumeroAlquiler";
            lblNumeroAlquiler.Size = new Size(112, 20);
            lblNumeroAlquiler.TabIndex = 8;
            lblNumeroAlquiler.Text = "N° alquiler (ID):";
            // 
            // txtNumeroAlquiler
            // 
            txtNumeroAlquiler.Location = new Point(149, 31);
            txtNumeroAlquiler.Margin = new Padding(3, 4, 3, 4);
            txtNumeroAlquiler.Name = "txtNumeroAlquiler";
            txtNumeroAlquiler.Size = new Size(217, 27);
            txtNumeroAlquiler.TabIndex = 9;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(217, 76);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(149, 40);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar por ID";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(734, 695);
            btnListar.Margin = new Padding(3, 4, 3, 4);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(149, 40);
            btnListar.TabIndex = 6;
            btnListar.Text = "Actualizar lista";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // dgvAlquileres
            // 
            dgvAlquileres.AllowUserToAddRows = false;
            dgvAlquileres.AllowUserToDeleteRows = false;
            dgvAlquileres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAlquileres.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvAlquileres.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlquileres.Location = new Point(14, 380);
            dgvAlquileres.Margin = new Padding(3, 4, 3, 4);
            dgvAlquileres.MultiSelect = false;
            dgvAlquileres.Name = "dgvAlquileres";
            dgvAlquileres.ReadOnly = true;
            dgvAlquileres.RowHeadersVisible = false;
            dgvAlquileres.RowHeadersWidth = 51;
            dgvAlquileres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlquileres.Size = new Size(869, 287);
            dgvAlquileres.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblNumeroAlquiler);
            groupBox1.Controls.Add(txtNumeroAlquiler);
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Location = new Point(455, 36);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(390, 128);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Modificar";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // grpBorrador
            // 
            grpBorrador.Controls.Add(lstBorrador);
            grpBorrador.Controls.Add(btnAgregarBorrador);
            grpBorrador.Controls.Add(btnConfirmarBorrador);
            grpBorrador.Location = new Point(455, 178);
            grpBorrador.Name = "grpBorrador";
            grpBorrador.Size = new Size(390, 190);
            grpBorrador.TabIndex = 11;
            grpBorrador.TabStop = false;
            grpBorrador.Text = "Borrador (transaccional)";
            // 
            // lstBorrador
            // 
            lstBorrador.FormattingEnabled = true;
            lstBorrador.Location = new Point(15, 30);
            lstBorrador.Name = "lstBorrador";
            lstBorrador.Size = new Size(360, 84);
            lstBorrador.TabIndex = 0;
            // 
            // btnAgregarBorrador
            // 
            btnAgregarBorrador.Location = new Point(15, 136);
            btnAgregarBorrador.Name = "btnAgregarBorrador";
            btnAgregarBorrador.Size = new Size(175, 40);
            btnAgregarBorrador.TabIndex = 1;
            btnAgregarBorrador.Text = "Agregar al listado";
            btnAgregarBorrador.UseVisualStyleBackColor = true;
            btnAgregarBorrador.Click += btnAgregarBorrador_Click;
            // 
            // btnConfirmarBorrador
            // 
            btnConfirmarBorrador.Location = new Point(200, 136);
            btnConfirmarBorrador.Name = "btnConfirmarBorrador";
            btnConfirmarBorrador.Size = new Size(175, 40);
            btnConfirmarBorrador.TabIndex = 2;
            btnConfirmarBorrador.Text = "Confirmar listado";
            btnConfirmarBorrador.UseVisualStyleBackColor = true;
            btnConfirmarBorrador.Click += btnConfirmarBorrador_Click;
            // 
            // FormAlquileres
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 748);
            Controls.Add(grpBorrador);
            Controls.Add(groupBox1);
            Controls.Add(dgvAlquileres);
            Controls.Add(btnListar);
            Controls.Add(grpDatos);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FormAlquileres";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BiciGestion - Gestion de alquileres de bicicletas";
            Load += FormAlquileres_Load;
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlquileres).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            grpBorrador.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblTipoBicicleta;
        private System.Windows.Forms.ComboBox cmbTipoBicicleta;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label lblFechaAlquiler;
        private System.Windows.Forms.DateTimePicker dtpFechaAlquiler;
        private System.Windows.Forms.Label lblNumeroAlquiler;
        private System.Windows.Forms.TextBox txtNumeroAlquiler;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.DataGridView dgvAlquileres;
        private GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpBorrador;
        private System.Windows.Forms.ListBox lstBorrador;
        private System.Windows.Forms.Button btnAgregarBorrador;
        private System.Windows.Forms.Button btnConfirmarBorrador;
    }
}
