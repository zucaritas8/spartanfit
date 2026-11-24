namespace SPARTANFIT.VISTA
{
    partial class FrmObjetivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObjetivos));
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTituloRojo = new System.Windows.Forms.Label();
            this.lblListado = new System.Windows.Forms.Label();
            this.lblIdObjetivo = new System.Windows.Forms.Label();
            this.lblMiembro = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblValorInicial = new System.Windows.Forms.Label();
            this.lblValorMeta = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.txtIdObjetivo = new System.Windows.Forms.TextBox();
            this.cmbMiembro = new System.Windows.Forms.ComboBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.cmbUnidad = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.numValorInicial = new System.Windows.Forms.NumericUpDown();
            this.numValorMeta = new System.Windows.Forms.NumericUpDown();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dgvObjetivos = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numValorInicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValorMeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjetivos)).BeginInit();
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
            this.lblTituloRojo.Text = "OBJETIVOS";
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
            this.lblListado.Text = "OBJETIVOS REGISTRADOS";
            // 
            // lblIdObjetivo
            // 
            this.lblIdObjetivo.AutoSize = true;
            this.lblIdObjetivo.BackColor = System.Drawing.Color.Transparent;
            this.lblIdObjetivo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblIdObjetivo.ForeColor = System.Drawing.Color.White;
            this.lblIdObjetivo.Location = new System.Drawing.Point(45, 118);
            this.lblIdObjetivo.Name = "lblIdObjetivo";
            this.lblIdObjetivo.Size = new System.Drawing.Size(92, 20);
            this.lblIdObjetivo.TabIndex = 5;
            this.lblIdObjetivo.Text = "ID Objetivo:";
            // 
            // lblMiembro
            // 
            this.lblMiembro.AutoSize = true;
            this.lblMiembro.BackColor = System.Drawing.Color.Transparent;
            this.lblMiembro.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMiembro.ForeColor = System.Drawing.Color.White;
            this.lblMiembro.Location = new System.Drawing.Point(340, 118);
            this.lblMiembro.Name = "lblMiembro";
            this.lblMiembro.Size = new System.Drawing.Size(77, 20);
            this.lblMiembro.TabIndex = 7;
            this.lblMiembro.Text = "Miembro:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.BackColor = System.Drawing.Color.Transparent;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTipo.ForeColor = System.Drawing.Color.White;
            this.lblTipo.Location = new System.Drawing.Point(45, 195);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(44, 20);
            this.lblTipo.TabIndex = 9;
            this.lblTipo.Text = "Tipo:";
            // 
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.BackColor = System.Drawing.Color.Transparent;
            this.lblUnidad.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblUnidad.ForeColor = System.Drawing.Color.White;
            this.lblUnidad.Location = new System.Drawing.Point(341, 195);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(63, 20);
            this.lblUnidad.TabIndex = 11;
            this.lblUnidad.Text = "Unidad:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDescripcion.ForeColor = System.Drawing.Color.White;
            this.lblDescripcion.Location = new System.Drawing.Point(44, 265);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(94, 20);
            this.lblDescripcion.TabIndex = 13;
            this.lblDescripcion.Text = "Descripción:";
            this.lblDescripcion.Click += new System.EventHandler(this.lblDescripcion_Click);
            // 
            // lblValorInicial
            // 
            this.lblValorInicial.AutoSize = true;
            this.lblValorInicial.BackColor = System.Drawing.Color.Transparent;
            this.lblValorInicial.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblValorInicial.ForeColor = System.Drawing.Color.White;
            this.lblValorInicial.Location = new System.Drawing.Point(44, 361);
            this.lblValorInicial.Name = "lblValorInicial";
            this.lblValorInicial.Size = new System.Drawing.Size(93, 20);
            this.lblValorInicial.TabIndex = 15;
            this.lblValorInicial.Text = "Valor inicial:";
            this.lblValorInicial.Click += new System.EventHandler(this.lblValorInicial_Click);
            // 
            // lblValorMeta
            // 
            this.lblValorMeta.AutoSize = true;
            this.lblValorMeta.BackColor = System.Drawing.Color.Transparent;
            this.lblValorMeta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblValorMeta.ForeColor = System.Drawing.Color.White;
            this.lblValorMeta.Location = new System.Drawing.Point(340, 361);
            this.lblValorMeta.Name = "lblValorMeta";
            this.lblValorMeta.Size = new System.Drawing.Size(89, 20);
            this.lblValorMeta.TabIndex = 17;
            this.lblValorMeta.Text = "Valor meta:";
            this.lblValorMeta.Click += new System.EventHandler(this.lblValorMeta_Click);
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaInicio.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFechaInicio.ForeColor = System.Drawing.Color.White;
            this.lblFechaInicio.Location = new System.Drawing.Point(43, 431);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(94, 20);
            this.lblFechaInicio.TabIndex = 19;
            this.lblFechaInicio.Text = "Fecha inicio:";
            this.lblFechaInicio.Click += new System.EventHandler(this.lblFechaInicio_Click);
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaFin.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFechaFin.ForeColor = System.Drawing.Color.White;
            this.lblFechaFin.Location = new System.Drawing.Point(341, 431);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(76, 20);
            this.lblFechaFin.TabIndex = 21;
            this.lblFechaFin.Text = "Fecha fin:";
            this.lblFechaFin.Click += new System.EventHandler(this.lblFechaFin_Click);
            // 
            // txtIdObjetivo
            // 
            this.txtIdObjetivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtIdObjetivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdObjetivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIdObjetivo.ForeColor = System.Drawing.Color.White;
            this.txtIdObjetivo.Location = new System.Drawing.Point(47, 141);
            this.txtIdObjetivo.Name = "txtIdObjetivo";
            this.txtIdObjetivo.ReadOnly = true;
            this.txtIdObjetivo.Size = new System.Drawing.Size(125, 27);
            this.txtIdObjetivo.TabIndex = 6;
            // 
            // cmbMiembro
            // 
            this.cmbMiembro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cmbMiembro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMiembro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMiembro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbMiembro.ForeColor = System.Drawing.Color.White;
            this.cmbMiembro.FormattingEnabled = true;
            this.cmbMiembro.Location = new System.Drawing.Point(340, 140);
            this.cmbMiembro.Name = "cmbMiembro";
            this.cmbMiembro.Size = new System.Drawing.Size(260, 28);
            this.cmbMiembro.TabIndex = 8;
            // 
            // cmbTipo
            // 
            this.cmbTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipo.ForeColor = System.Drawing.Color.White;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "PESO",
            "FUERZA",
            "RESISTENCIA",
            "FLEXIBILIDAD",
            "OTRO"});
            this.cmbTipo.Location = new System.Drawing.Point(47, 218);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(220, 28);
            this.cmbTipo.TabIndex = 10;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // cmbUnidad
            // 
            this.cmbUnidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cmbUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUnidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbUnidad.ForeColor = System.Drawing.Color.White;
            this.cmbUnidad.FormattingEnabled = true;
            this.cmbUnidad.Items.AddRange(new object[] {
            "KG",
            "CM",
            "REPETICIONES",
            "MINUTOS",
            "%",
            "OTRO"});
            this.cmbUnidad.Location = new System.Drawing.Point(345, 218);
            this.cmbUnidad.Name = "cmbUnidad";
            this.cmbUnidad.Size = new System.Drawing.Size(125, 28);
            this.cmbUnidad.TabIndex = 12;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescripcion.ForeColor = System.Drawing.Color.White;
            this.txtDescripcion.Location = new System.Drawing.Point(45, 288);
            this.txtDescripcion.MaxLength = 255;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(555, 55);
            this.txtDescripcion.TabIndex = 14;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // numValorInicial
            // 
            this.numValorInicial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.numValorInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numValorInicial.DecimalPlaces = 2;
            this.numValorInicial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numValorInicial.ForeColor = System.Drawing.Color.White;
            this.numValorInicial.Location = new System.Drawing.Point(45, 384);
            this.numValorInicial.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numValorInicial.Name = "numValorInicial";
            this.numValorInicial.Size = new System.Drawing.Size(220, 27);
            this.numValorInicial.TabIndex = 16;
            this.numValorInicial.ThousandsSeparator = true;
            this.numValorInicial.ValueChanged += new System.EventHandler(this.numValorInicial_ValueChanged);
            // 
            // numValorMeta
            // 
            this.numValorMeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.numValorMeta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numValorMeta.DecimalPlaces = 2;
            this.numValorMeta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numValorMeta.ForeColor = System.Drawing.Color.White;
            this.numValorMeta.Location = new System.Drawing.Point(340, 384);
            this.numValorMeta.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numValorMeta.Name = "numValorMeta";
            this.numValorMeta.Size = new System.Drawing.Size(220, 27);
            this.numValorMeta.TabIndex = 18;
            this.numValorMeta.ThousandsSeparator = true;
            this.numValorMeta.ValueChanged += new System.EventHandler(this.numValorMeta_ValueChanged);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CalendarForeColor = System.Drawing.Color.White;
            this.dtpFechaInicio.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtpFechaInicio.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dtpFechaInicio.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(45, 454);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(220, 27);
            this.dtpFechaInicio.TabIndex = 20;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CalendarForeColor = System.Drawing.Color.White;
            this.dtpFechaFin.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtpFechaFin.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dtpFechaFin.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaFin.Checked = false;
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(340, 454);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.ShowCheckBox = true;
            this.dtpFechaFin.Size = new System.Drawing.Size(260, 27);
            this.dtpFechaFin.TabIndex = 22;
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.dtpFechaFin_ValueChanged);
            // 
            // dgvObjetivos
            // 
            this.dgvObjetivos.AllowUserToAddRows = false;
            this.dgvObjetivos.AllowUserToDeleteRows = false;
            this.dgvObjetivos.AllowUserToResizeRows = false;
            this.dgvObjetivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvObjetivos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.dgvObjetivos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvObjetivos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvObjetivos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvObjetivos.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvObjetivos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvObjetivos.EnableHeadersVisualStyles = false;
            this.dgvObjetivos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.dgvObjetivos.Location = new System.Drawing.Point(700, 130);
            this.dgvObjetivos.MultiSelect = false;
            this.dgvObjetivos.Name = "dgvObjetivos";
            this.dgvObjetivos.ReadOnly = true;
            this.dgvObjetivos.RowHeadersVisible = false;
            this.dgvObjetivos.RowHeadersWidth = 51;
            this.dgvObjetivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvObjetivos.Size = new System.Drawing.Size(640, 430);
            this.dgvObjetivos.TabIndex = 23;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(10)))), ((int)(((byte)(18)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(48, 522);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(125, 35);
            this.btnNuevo.TabIndex = 24;
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
            this.btnRegistrar.Location = new System.Drawing.Point(188, 522);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(125, 35);
            this.btnRegistrar.TabIndex = 25;
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
            this.btnEditar.Location = new System.Drawing.Point(328, 522);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(125, 35);
            this.btnEditar.TabIndex = 26;
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
            this.btnEliminar.Location = new System.Drawing.Point(188, 567);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(125, 35);
            this.btnEliminar.TabIndex = 27;
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
            this.btnCancelar.Location = new System.Drawing.Point(328, 567);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 35);
            this.btnCancelar.TabIndex = 28;
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
            this.button1.Location = new System.Drawing.Point(1225, 638);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 34);
            this.button1.TabIndex = 33;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmObjetivos
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
            this.Controls.Add(this.lblIdObjetivo);
            this.Controls.Add(this.lblMiembro);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblUnidad);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblValorInicial);
            this.Controls.Add(this.lblValorMeta);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.txtIdObjetivo);
            this.Controls.Add(this.cmbMiembro);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.cmbUnidad);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.numValorInicial);
            this.Controls.Add(this.numValorMeta);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.dgvObjetivos);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCancelar);
            this.MinimumSize = new System.Drawing.Size(1240, 700);
            this.Name = "FrmObjetivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmObjetivos";
            ((System.ComponentModel.ISupportInitialize)(this.numValorInicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValorMeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjetivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdObjetivo;
        private System.Windows.Forms.Label lblMiembro;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblValorInicial;
        private System.Windows.Forms.Label lblValorMeta;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTituloRojo;
        private System.Windows.Forms.Label lblListado;
        private System.Windows.Forms.TextBox txtIdObjetivo;
        private System.Windows.Forms.ComboBox cmbMiembro;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.ComboBox cmbUnidad;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.NumericUpDown numValorInicial;
        private System.Windows.Forms.NumericUpDown numValorMeta;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DataGridView dgvObjetivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvObjetivosCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvObjetivosCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvObjetivosCol3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvObjetivosCol4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvObjetivosCol5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvObjetivosCol6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvObjetivosCol7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvObjetivosCol8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvObjetivosCol9;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button button1;
    }
}
