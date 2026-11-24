namespace SPARTANFIT.VISTA
{
    partial class FrmRutinas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRutinas));
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTituloRojo = new System.Windows.Forms.Label();
            this.lblListado = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.lblIdRutina = new System.Windows.Forms.Label();
            this.lblCoach = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.lblUnidadTiempo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblEjercicio = new System.Windows.Forms.Label();
            this.lblNumeroSeries = new System.Windows.Forms.Label();
            this.lblOrden = new System.Windows.Forms.Label();
            this.lblRepeticiones = new System.Windows.Forms.Label();
            this.txtIdRutina = new System.Windows.Forms.TextBox();
            this.cmbCoach = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.numTiempo = new System.Windows.Forms.NumericUpDown();
            this.cmbUnidadTiempo = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.cmbEjercicio = new System.Windows.Forms.ComboBox();
            this.numNumeroSeries = new System.Windows.Forms.NumericUpDown();
            this.numOrden = new System.Windows.Forms.NumericUpDown();
            this.numRepeticiones = new System.Windows.Forms.NumericUpDown();
            this.dgvRutinas = new System.Windows.Forms.DataGridView();
            this.dgvRutinaEjercicios = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTiempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumeroSeries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOrden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeticiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRutinas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRutinaEjercicios)).BeginInit();
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
            this.lblTitulo.Location = new System.Drawing.Point(440, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(190, 45);
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
            this.lblTituloRojo.Size = new System.Drawing.Size(360, 45);
            this.lblTituloRojo.TabIndex = 2;
            this.lblTituloRojo.Text = "RUTINAS";
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
            this.lblListado.Text = "RUTINAS REGISTRADAS";
            // 
            // lblDetalle
            // 
            this.lblDetalle.BackColor = System.Drawing.Color.Transparent;
            this.lblDetalle.Font = new System.Drawing.Font("Bebas Neue", 15F);
            this.lblDetalle.ForeColor = System.Drawing.Color.White;
            this.lblDetalle.Location = new System.Drawing.Point(700, 395);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(600, 28);
            this.lblDetalle.TabIndex = 4;
            this.lblDetalle.Text = "EJERCICIOS ASIGNADOS";
            // 
            // lblIdRutina
            // 
            this.lblIdRutina.AutoSize = true;
            this.lblIdRutina.BackColor = System.Drawing.Color.Transparent;
            this.lblIdRutina.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblIdRutina.ForeColor = System.Drawing.Color.White;
            this.lblIdRutina.Location = new System.Drawing.Point(45, 128);
            this.lblIdRutina.Name = "lblIdRutina";
            this.lblIdRutina.Size = new System.Drawing.Size(79, 20);
            this.lblIdRutina.TabIndex = 5;
            this.lblIdRutina.Text = "ID Rutina:";
            // 
            // lblCoach
            // 
            this.lblCoach.AutoSize = true;
            this.lblCoach.BackColor = System.Drawing.Color.Transparent;
            this.lblCoach.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCoach.ForeColor = System.Drawing.Color.White;
            this.lblCoach.Location = new System.Drawing.Point(340, 128);
            this.lblCoach.Name = "lblCoach";
            this.lblCoach.Size = new System.Drawing.Size(55, 20);
            this.lblCoach.TabIndex = 7;
            this.lblCoach.Text = "Coach:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(45, 210);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(71, 20);
            this.lblNombre.TabIndex = 9;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.BackColor = System.Drawing.Color.Transparent;
            this.lblTiempo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTiempo.ForeColor = System.Drawing.Color.White;
            this.lblTiempo.Location = new System.Drawing.Point(340, 210);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(66, 20);
            this.lblTiempo.TabIndex = 11;
            this.lblTiempo.Text = "Tiempo:";
            // 
            // lblUnidadTiempo
            // 
            this.lblUnidadTiempo.AutoSize = true;
            this.lblUnidadTiempo.BackColor = System.Drawing.Color.Transparent;
            this.lblUnidadTiempo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblUnidadTiempo.ForeColor = System.Drawing.Color.White;
            this.lblUnidadTiempo.Location = new System.Drawing.Point(467, 209);
            this.lblUnidadTiempo.Name = "lblUnidadTiempo";
            this.lblUnidadTiempo.Size = new System.Drawing.Size(117, 20);
            this.lblUnidadTiempo.TabIndex = 13;
            this.lblUnidadTiempo.Text = "Unidad tiempo:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDescripcion.ForeColor = System.Drawing.Color.White;
            this.lblDescripcion.Location = new System.Drawing.Point(45, 290);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(94, 20);
            this.lblDescripcion.TabIndex = 15;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblEjercicio
            // 
            this.lblEjercicio.AutoSize = true;
            this.lblEjercicio.BackColor = System.Drawing.Color.Transparent;
            this.lblEjercicio.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEjercicio.ForeColor = System.Drawing.Color.White;
            this.lblEjercicio.Location = new System.Drawing.Point(45, 398);
            this.lblEjercicio.Name = "lblEjercicio";
            this.lblEjercicio.Size = new System.Drawing.Size(70, 20);
            this.lblEjercicio.TabIndex = 17;
            this.lblEjercicio.Text = "Ejercicio:";
            // 
            // lblNumeroSeries
            // 
            this.lblNumeroSeries.AutoSize = true;
            this.lblNumeroSeries.BackColor = System.Drawing.Color.Transparent;
            this.lblNumeroSeries.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNumeroSeries.ForeColor = System.Drawing.Color.White;
            this.lblNumeroSeries.Location = new System.Drawing.Point(340, 398);
            this.lblNumeroSeries.Name = "lblNumeroSeries";
            this.lblNumeroSeries.Size = new System.Drawing.Size(80, 20);
            this.lblNumeroSeries.TabIndex = 19;
            this.lblNumeroSeries.Text = "N.º series:";
            // 
            // lblOrden
            // 
            this.lblOrden.AutoSize = true;
            this.lblOrden.BackColor = System.Drawing.Color.Transparent;
            this.lblOrden.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblOrden.ForeColor = System.Drawing.Color.White;
            this.lblOrden.Location = new System.Drawing.Point(45, 474);
            this.lblOrden.Name = "lblOrden";
            this.lblOrden.Size = new System.Drawing.Size(56, 20);
            this.lblOrden.TabIndex = 21;
            this.lblOrden.Text = "Orden:";
            // 
            // lblRepeticiones
            // 
            this.lblRepeticiones.AutoSize = true;
            this.lblRepeticiones.BackColor = System.Drawing.Color.Transparent;
            this.lblRepeticiones.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRepeticiones.ForeColor = System.Drawing.Color.White;
            this.lblRepeticiones.Location = new System.Drawing.Point(336, 474);
            this.lblRepeticiones.Name = "lblRepeticiones";
            this.lblRepeticiones.Size = new System.Drawing.Size(102, 20);
            this.lblRepeticiones.TabIndex = 23;
            this.lblRepeticiones.Text = "Repeticiones:";
            // 
            // txtIdRutina
            // 
            this.txtIdRutina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtIdRutina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdRutina.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIdRutina.ForeColor = System.Drawing.Color.White;
            this.txtIdRutina.Location = new System.Drawing.Point(45, 151);
            this.txtIdRutina.Name = "txtIdRutina";
            this.txtIdRutina.ReadOnly = true;
            this.txtIdRutina.Size = new System.Drawing.Size(125, 27);
            this.txtIdRutina.TabIndex = 6;
            // 
            // cmbCoach
            // 
            this.cmbCoach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cmbCoach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCoach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCoach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCoach.ForeColor = System.Drawing.Color.White;
            this.cmbCoach.FormattingEnabled = true;
            this.cmbCoach.Location = new System.Drawing.Point(340, 150);
            this.cmbCoach.Name = "cmbCoach";
            this.cmbCoach.Size = new System.Drawing.Size(260, 28);
            this.cmbCoach.TabIndex = 8;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombre.ForeColor = System.Drawing.Color.White;
            this.txtNombre.Location = new System.Drawing.Point(45, 233);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(220, 27);
            this.txtNombre.TabIndex = 10;
            // 
            // numTiempo
            // 
            this.numTiempo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.numTiempo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numTiempo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numTiempo.ForeColor = System.Drawing.Color.White;
            this.numTiempo.Location = new System.Drawing.Point(340, 233);
            this.numTiempo.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTiempo.Name = "numTiempo";
            this.numTiempo.Size = new System.Drawing.Size(125, 27);
            this.numTiempo.TabIndex = 12;
            this.numTiempo.ThousandsSeparator = true;
            // 
            // cmbUnidadTiempo
            // 
            this.cmbUnidadTiempo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cmbUnidadTiempo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidadTiempo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUnidadTiempo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbUnidadTiempo.ForeColor = System.Drawing.Color.White;
            this.cmbUnidadTiempo.FormattingEnabled = true;
            this.cmbUnidadTiempo.Items.AddRange(new object[] {
            "MINUTOS",
            "HORAS",
            "SEGUNDOS"});
            this.cmbUnidadTiempo.Location = new System.Drawing.Point(471, 232);
            this.cmbUnidadTiempo.Name = "cmbUnidadTiempo";
            this.cmbUnidadTiempo.Size = new System.Drawing.Size(125, 28);
            this.cmbUnidadTiempo.TabIndex = 14;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescripcion.ForeColor = System.Drawing.Color.White;
            this.txtDescripcion.Location = new System.Drawing.Point(45, 313);
            this.txtDescripcion.MaxLength = 255;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(555, 65);
            this.txtDescripcion.TabIndex = 16;
            // 
            // cmbEjercicio
            // 
            this.cmbEjercicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEjercicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEjercicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbEjercicio.ForeColor = System.Drawing.Color.White;
            this.cmbEjercicio.FormattingEnabled = true;
            this.cmbEjercicio.Location = new System.Drawing.Point(45, 421);
            this.cmbEjercicio.Name = "cmbEjercicio";
            this.cmbEjercicio.Size = new System.Drawing.Size(220, 28);
            this.cmbEjercicio.TabIndex = 18;
            // 
            // numNumeroSeries
            // 
            this.numNumeroSeries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.numNumeroSeries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numNumeroSeries.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numNumeroSeries.ForeColor = System.Drawing.Color.White;
            this.numNumeroSeries.Location = new System.Drawing.Point(340, 422);
            this.numNumeroSeries.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numNumeroSeries.Name = "numNumeroSeries";
            this.numNumeroSeries.Size = new System.Drawing.Size(125, 27);
            this.numNumeroSeries.TabIndex = 20;
            this.numNumeroSeries.ThousandsSeparator = true;
            // 
            // numOrden
            // 
            this.numOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.numOrden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numOrden.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numOrden.ForeColor = System.Drawing.Color.White;
            this.numOrden.Location = new System.Drawing.Point(45, 497);
            this.numOrden.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numOrden.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOrden.Name = "numOrden";
            this.numOrden.Size = new System.Drawing.Size(220, 27);
            this.numOrden.TabIndex = 22;
            this.numOrden.ThousandsSeparator = true;
            this.numOrden.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numRepeticiones
            // 
            this.numRepeticiones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.numRepeticiones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numRepeticiones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numRepeticiones.ForeColor = System.Drawing.Color.White;
            this.numRepeticiones.Location = new System.Drawing.Point(340, 497);
            this.numRepeticiones.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numRepeticiones.Name = "numRepeticiones";
            this.numRepeticiones.Size = new System.Drawing.Size(125, 27);
            this.numRepeticiones.TabIndex = 24;
            this.numRepeticiones.ThousandsSeparator = true;
            // 
            // dgvRutinas
            // 
            this.dgvRutinas.AllowUserToAddRows = false;
            this.dgvRutinas.AllowUserToDeleteRows = false;
            this.dgvRutinas.AllowUserToResizeRows = false;
            this.dgvRutinas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvRutinas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.dgvRutinas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRutinas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRutinas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRutinas.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRutinas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRutinas.EnableHeadersVisualStyles = false;
            this.dgvRutinas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.dgvRutinas.Location = new System.Drawing.Point(700, 130);
            this.dgvRutinas.MultiSelect = false;
            this.dgvRutinas.Name = "dgvRutinas";
            this.dgvRutinas.ReadOnly = true;
            this.dgvRutinas.RowHeadersVisible = false;
            this.dgvRutinas.RowHeadersWidth = 51;
            this.dgvRutinas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRutinas.Size = new System.Drawing.Size(640, 235);
            this.dgvRutinas.TabIndex = 25;
            // 
            // dgvRutinaEjercicios
            // 
            this.dgvRutinaEjercicios.AllowUserToAddRows = false;
            this.dgvRutinaEjercicios.AllowUserToDeleteRows = false;
            this.dgvRutinaEjercicios.AllowUserToResizeRows = false;
            this.dgvRutinaEjercicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvRutinaEjercicios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.dgvRutinaEjercicios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRutinaEjercicios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRutinaEjercicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRutinaEjercicios.ColumnHeadersHeight = 35;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRutinaEjercicios.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRutinaEjercicios.EnableHeadersVisualStyles = false;
            this.dgvRutinaEjercicios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.dgvRutinaEjercicios.Location = new System.Drawing.Point(700, 425);
            this.dgvRutinaEjercicios.MultiSelect = false;
            this.dgvRutinaEjercicios.Name = "dgvRutinaEjercicios";
            this.dgvRutinaEjercicios.ReadOnly = true;
            this.dgvRutinaEjercicios.RowHeadersVisible = false;
            this.dgvRutinaEjercicios.RowHeadersWidth = 51;
            this.dgvRutinaEjercicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRutinaEjercicios.Size = new System.Drawing.Size(640, 175);
            this.dgvRutinaEjercicios.TabIndex = 26;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(10)))), ((int)(((byte)(18)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(48, 574);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(125, 35);
            this.btnNuevo.TabIndex = 27;
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
            this.btnRegistrar.Location = new System.Drawing.Point(188, 574);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(125, 35);
            this.btnRegistrar.TabIndex = 28;
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
            this.btnEditar.Location = new System.Drawing.Point(328, 574);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(125, 35);
            this.btnEditar.TabIndex = 29;
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
            this.btnEliminar.Location = new System.Drawing.Point(188, 619);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(125, 35);
            this.btnEliminar.TabIndex = 30;
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
            this.btnCancelar.Location = new System.Drawing.Point(328, 619);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 35);
            this.btnCancelar.TabIndex = 31;
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
            this.button1.Location = new System.Drawing.Point(1225, 643);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 34);
            this.button1.TabIndex = 33;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmRutinas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1380, 780);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblTituloRojo);
            this.Controls.Add(this.lblListado);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.lblIdRutina);
            this.Controls.Add(this.lblCoach);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.lblUnidadTiempo);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblEjercicio);
            this.Controls.Add(this.lblNumeroSeries);
            this.Controls.Add(this.lblOrden);
            this.Controls.Add(this.lblRepeticiones);
            this.Controls.Add(this.txtIdRutina);
            this.Controls.Add(this.cmbCoach);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.numTiempo);
            this.Controls.Add(this.cmbUnidadTiempo);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.cmbEjercicio);
            this.Controls.Add(this.numNumeroSeries);
            this.Controls.Add(this.numOrden);
            this.Controls.Add(this.numRepeticiones);
            this.Controls.Add(this.dgvRutinas);
            this.Controls.Add(this.dgvRutinaEjercicios);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCancelar);
            this.MinimumSize = new System.Drawing.Size(1240, 720);
            this.Name = "FrmRutinas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRutinas";
            ((System.ComponentModel.ISupportInitialize)(this.numTiempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumeroSeries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOrden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeticiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRutinas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRutinaEjercicios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdRutina;
        private System.Windows.Forms.Label lblCoach;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Label lblUnidadTiempo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblEjercicio;
        private System.Windows.Forms.Label lblNumeroSeries;
        private System.Windows.Forms.Label lblOrden;
        private System.Windows.Forms.Label lblRepeticiones;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTituloRojo;
        private System.Windows.Forms.Label lblListado;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.TextBox txtIdRutina;
        private System.Windows.Forms.ComboBox cmbCoach;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.NumericUpDown numTiempo;
        private System.Windows.Forms.ComboBox cmbUnidadTiempo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cmbEjercicio;
        private System.Windows.Forms.NumericUpDown numNumeroSeries;
        private System.Windows.Forms.NumericUpDown numOrden;
        private System.Windows.Forms.NumericUpDown numRepeticiones;
        private System.Windows.Forms.DataGridView dgvRutinas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRutinasCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRutinasCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRutinasCol3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRutinasCol4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRutinasCol5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRutinasCol6;
        private System.Windows.Forms.DataGridView dgvRutinaEjercicios;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRutinaEjerciciosCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRutinaEjerciciosCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRutinaEjerciciosCol3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRutinaEjerciciosCol4;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button button1;
    }
}
