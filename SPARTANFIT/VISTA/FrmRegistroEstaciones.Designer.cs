namespace SPARTANFIT.VISTA
{
    partial class FrmRegistroEstaciones
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistroEstaciones));
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTituloRojo = new System.Windows.Forms.Label();
            this.lblListado = new System.Windows.Forms.Label();
            this.lblIdRegistro = new System.Windows.Forms.Label();
            this.lblEstacion = new System.Windows.Forms.Label();
            this.lblMiembro = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.txtIdRegistro = new System.Windows.Forms.TextBox();
            this.cmbEstacion = new System.Windows.Forms.ComboBox();
            this.cmbMiembro = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.dgvRegistroEstaciones = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroEstaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMarca
            // 
            this.lblMarca.BackColor = System.Drawing.Color.Transparent;
            this.lblMarca.Font = new System.Drawing.Font("Bebas Neue", 20F);
            this.lblMarca.ForeColor = System.Drawing.Color.White;
            this.lblMarca.Location = new System.Drawing.Point(25, 15);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(230, 45);
            this.lblMarca.TabIndex = 0;
            this.lblMarca.Text = "SPARTANFIT";
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Bebas Neue", 25F);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(452, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(174, 45);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "GESTIÓN DE";
            // 
            // lblTituloRojo
            // 
            this.lblTituloRojo.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloRojo.Font = new System.Drawing.Font("Bebas Neue", 25F, System.Drawing.FontStyle.Bold);
            this.lblTituloRojo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(25)))), ((int)(((byte)(35)))));
            this.lblTituloRojo.Location = new System.Drawing.Point(620, 15);
            this.lblTituloRojo.Name = "lblTituloRojo";
            this.lblTituloRojo.Size = new System.Drawing.Size(400, 45);
            this.lblTituloRojo.TabIndex = 2;
            this.lblTituloRojo.Text = "REGISTRO DE ESTACIONES";
            // 
            // lblListado
            // 
            this.lblListado.BackColor = System.Drawing.Color.Transparent;
            this.lblListado.Font = new System.Drawing.Font("Bebas Neue", 15F);
            this.lblListado.ForeColor = System.Drawing.Color.White;
            this.lblListado.Location = new System.Drawing.Point(700, 95);
            this.lblListado.Name = "lblListado";
            this.lblListado.Size = new System.Drawing.Size(600, 30);
            this.lblListado.TabIndex = 3;
            this.lblListado.Text = "REGISTROS DE ESTACIONES";
            // 
            // lblIdRegistro
            // 
            this.lblIdRegistro.AutoSize = true;
            this.lblIdRegistro.BackColor = System.Drawing.Color.Transparent;
            this.lblIdRegistro.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblIdRegistro.ForeColor = System.Drawing.Color.White;
            this.lblIdRegistro.Location = new System.Drawing.Point(45, 128);
            this.lblIdRegistro.Name = "lblIdRegistro";
            this.lblIdRegistro.Size = new System.Drawing.Size(92, 20);
            this.lblIdRegistro.TabIndex = 5;
            this.lblIdRegistro.Text = "ID Registro:";
            // 
            // lblEstacion
            // 
            this.lblEstacion.AutoSize = true;
            this.lblEstacion.BackColor = System.Drawing.Color.Transparent;
            this.lblEstacion.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEstacion.ForeColor = System.Drawing.Color.White;
            this.lblEstacion.Location = new System.Drawing.Point(340, 128);
            this.lblEstacion.Name = "lblEstacion";
            this.lblEstacion.Size = new System.Drawing.Size(71, 20);
            this.lblEstacion.TabIndex = 7;
            this.lblEstacion.Text = "Estación:";
            // 
            // lblMiembro
            // 
            this.lblMiembro.AutoSize = true;
            this.lblMiembro.BackColor = System.Drawing.Color.Transparent;
            this.lblMiembro.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMiembro.ForeColor = System.Drawing.Color.White;
            this.lblMiembro.Location = new System.Drawing.Point(45, 220);
            this.lblMiembro.Name = "lblMiembro";
            this.lblMiembro.Size = new System.Drawing.Size(77, 20);
            this.lblMiembro.TabIndex = 9;
            this.lblMiembro.Text = "Miembro:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(340, 220);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(101, 20);
            this.lblFecha.TabIndex = 11;
            this.lblFecha.Text = "Fecha y hora:";
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.BackColor = System.Drawing.Color.Transparent;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblResultado.ForeColor = System.Drawing.Color.White;
            this.lblResultado.Location = new System.Drawing.Point(45, 327);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(83, 20);
            this.lblResultado.TabIndex = 13;
            this.lblResultado.Text = "Resultado:";
            // 
            // txtIdRegistro
            // 
            this.txtIdRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtIdRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdRegistro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIdRegistro.ForeColor = System.Drawing.Color.White;
            this.txtIdRegistro.Location = new System.Drawing.Point(45, 151);
            this.txtIdRegistro.Name = "txtIdRegistro";
            this.txtIdRegistro.ReadOnly = true;
            this.txtIdRegistro.Size = new System.Drawing.Size(125, 27);
            this.txtIdRegistro.TabIndex = 6;
            // 
            // cmbEstacion
            // 
            this.cmbEstacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cmbEstacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbEstacion.ForeColor = System.Drawing.Color.White;
            this.cmbEstacion.FormattingEnabled = true;
            this.cmbEstacion.Location = new System.Drawing.Point(340, 150);
            this.cmbEstacion.Name = "cmbEstacion";
            this.cmbEstacion.Size = new System.Drawing.Size(260, 28);
            this.cmbEstacion.TabIndex = 8;
            // 
            // cmbMiembro
            // 
            this.cmbMiembro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cmbMiembro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMiembro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMiembro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbMiembro.ForeColor = System.Drawing.Color.White;
            this.cmbMiembro.FormattingEnabled = true;
            this.cmbMiembro.Location = new System.Drawing.Point(45, 254);
            this.cmbMiembro.Name = "cmbMiembro";
            this.cmbMiembro.Size = new System.Drawing.Size(220, 28);
            this.cmbMiembro.TabIndex = 10;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CalendarForeColor = System.Drawing.Color.White;
            this.dtpFecha.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtpFecha.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dtpFecha.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFecha.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(340, 255);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.ShowUpDown = true;
            this.dtpFecha.Size = new System.Drawing.Size(260, 27);
            this.dtpFecha.TabIndex = 12;
            // 
            // txtResultado
            // 
            this.txtResultado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResultado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtResultado.ForeColor = System.Drawing.Color.White;
            this.txtResultado.Location = new System.Drawing.Point(45, 361);
            this.txtResultado.MaxLength = 255;
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultado.Size = new System.Drawing.Size(555, 85);
            this.txtResultado.TabIndex = 14;
            // 
            // dgvRegistroEstaciones
            // 
            this.dgvRegistroEstaciones.AllowUserToAddRows = false;
            this.dgvRegistroEstaciones.AllowUserToDeleteRows = false;
            this.dgvRegistroEstaciones.AllowUserToResizeRows = false;
            this.dgvRegistroEstaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvRegistroEstaciones.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.dgvRegistroEstaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRegistroEstaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegistroEstaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRegistroEstaciones.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRegistroEstaciones.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRegistroEstaciones.EnableHeadersVisualStyles = false;
            this.dgvRegistroEstaciones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.dgvRegistroEstaciones.Location = new System.Drawing.Point(700, 130);
            this.dgvRegistroEstaciones.MultiSelect = false;
            this.dgvRegistroEstaciones.Name = "dgvRegistroEstaciones";
            this.dgvRegistroEstaciones.ReadOnly = true;
            this.dgvRegistroEstaciones.RowHeadersVisible = false;
            this.dgvRegistroEstaciones.RowHeadersWidth = 51;
            this.dgvRegistroEstaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistroEstaciones.Size = new System.Drawing.Size(640, 430);
            this.dgvRegistroEstaciones.TabIndex = 15;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(10)))), ((int)(((byte)(18)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(45, 500);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(125, 35);
            this.btnNuevo.TabIndex = 16;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = false;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(10)))), ((int)(((byte)(18)))));
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(185, 500);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(125, 35);
            this.btnRegistrar.TabIndex = 17;
            this.btnRegistrar.Text = "REGISTRAR";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(10)))), ((int)(((byte)(18)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(325, 500);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(125, 35);
            this.btnEditar.TabIndex = 18;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(12)))), ((int)(((byte)(18)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(185, 545);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(125, 35);
            this.btnEliminar.TabIndex = 19;
            this.btnEliminar.Text = "DESACTIVAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(325, 545);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 35);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button1.Location = new System.Drawing.Point(1214, 623);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 34);
            this.button1.TabIndex = 33;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmRegistroEstaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1380, 760);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblTituloRojo);
            this.Controls.Add(this.lblListado);
            this.Controls.Add(this.lblIdRegistro);
            this.Controls.Add(this.lblEstacion);
            this.Controls.Add(this.lblMiembro);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.txtIdRegistro);
            this.Controls.Add(this.cmbEstacion);
            this.Controls.Add(this.cmbMiembro);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.dgvRegistroEstaciones);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCancelar);
            this.MinimumSize = new System.Drawing.Size(1240, 700);
            this.Name = "FrmRegistroEstaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRegistroEstaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroEstaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdRegistro;
        private System.Windows.Forms.Label lblEstacion;
        private System.Windows.Forms.Label lblMiembro;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTituloRojo;
        private System.Windows.Forms.Label lblListado;
        private System.Windows.Forms.TextBox txtIdRegistro;
        private System.Windows.Forms.ComboBox cmbEstacion;
        private System.Windows.Forms.ComboBox cmbMiembro;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.DataGridView dgvRegistroEstaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRegistroEstacionesCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRegistroEstacionesCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRegistroEstacionesCol3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRegistroEstacionesCol4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRegistroEstacionesCol5;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button button1;
    }
}
