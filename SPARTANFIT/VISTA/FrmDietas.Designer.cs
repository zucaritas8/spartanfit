namespace SPARTANFIT.VISTA
{
    partial class FrmDietas
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
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTituloRojo = new System.Windows.Forms.Label();
            this.lblListado = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.lblIdDieta = new System.Windows.Forms.Label();
            this.lblMiembro = new System.Windows.Forms.Label();
            this.lblCoach = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblCarbohidratos = new System.Windows.Forms.Label();
            this.lblCalorias = new System.Windows.Forms.Label();
            this.lblProteinas = new System.Windows.Forms.Label();
            this.lblGrasas = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblTiempoComida = new System.Windows.Forms.Label();
            this.lblDescripcionDetalle = new System.Windows.Forms.Label();
            this.txtIdDieta = new System.Windows.Forms.TextBox();
            this.cmbMiembro = new System.Windows.Forms.ComboBox();
            this.cmbCoach = new System.Windows.Forms.ComboBox();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.numCarbohidratos = new System.Windows.Forms.NumericUpDown();
            this.numCalorias = new System.Windows.Forms.NumericUpDown();
            this.numProteinas = new System.Windows.Forms.NumericUpDown();
            this.numGrasas = new System.Windows.Forms.NumericUpDown();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.cmbTiempoComida = new System.Windows.Forms.ComboBox();
            this.txtDescripcionDetalle = new System.Windows.Forms.TextBox();
            this.dgvDietas = new System.Windows.Forms.DataGridView();
            this.dgvDietaDetalle = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCarbohidratos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCalorias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProteinas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGrasas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDietas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDietaDetalle)).BeginInit();
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
            this.lblTituloRojo.Text = "DIETAS";
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
            this.lblListado.Text = "DIETAS REGISTRADAS";
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
            this.lblDetalle.Text = "COMIDAS DE LA DIETA";
            // 
            // lblIdDieta
            // 
            this.lblIdDieta.AutoSize = true;
            this.lblIdDieta.BackColor = System.Drawing.Color.Transparent;
            this.lblIdDieta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblIdDieta.ForeColor = System.Drawing.Color.White;
            this.lblIdDieta.Location = new System.Drawing.Point(45, 118);
            this.lblIdDieta.Name = "lblIdDieta";
            this.lblIdDieta.Size = new System.Drawing.Size(70, 20);
            this.lblIdDieta.TabIndex = 5;
            this.lblIdDieta.Text = "ID Dieta:";
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
            // lblCoach
            // 
            this.lblCoach.AutoSize = true;
            this.lblCoach.BackColor = System.Drawing.Color.Transparent;
            this.lblCoach.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCoach.ForeColor = System.Drawing.Color.White;
            this.lblCoach.Location = new System.Drawing.Point(41, 172);
            this.lblCoach.Name = "lblCoach";
            this.lblCoach.Size = new System.Drawing.Size(55, 20);
            this.lblCoach.TabIndex = 9;
            this.lblCoach.Text = "Coach:";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaInicio.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFechaInicio.ForeColor = System.Drawing.Color.White;
            this.lblFechaInicio.Location = new System.Drawing.Point(340, 186);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(94, 20);
            this.lblFechaInicio.TabIndex = 11;
            this.lblFechaInicio.Text = "Fecha inicio:";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaFin.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFechaFin.ForeColor = System.Drawing.Color.White;
            this.lblFechaFin.Location = new System.Drawing.Point(45, 230);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(76, 20);
            this.lblFechaFin.TabIndex = 13;
            this.lblFechaFin.Text = "Fecha fin:";
            // 
            // lblCarbohidratos
            // 
            this.lblCarbohidratos.AutoSize = true;
            this.lblCarbohidratos.BackColor = System.Drawing.Color.Transparent;
            this.lblCarbohidratos.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCarbohidratos.ForeColor = System.Drawing.Color.White;
            this.lblCarbohidratos.Location = new System.Drawing.Point(344, 268);
            this.lblCarbohidratos.Name = "lblCarbohidratos";
            this.lblCarbohidratos.Size = new System.Drawing.Size(108, 40);
            this.lblCarbohidratos.TabIndex = 15;
            this.lblCarbohidratos.Text = "Carbohidratos\r\ndiarios:";
            // 
            // lblCalorias
            // 
            this.lblCalorias.AutoSize = true;
            this.lblCalorias.BackColor = System.Drawing.Color.Transparent;
            this.lblCalorias.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCalorias.ForeColor = System.Drawing.Color.White;
            this.lblCalorias.Location = new System.Drawing.Point(45, 291);
            this.lblCalorias.Name = "lblCalorias";
            this.lblCalorias.Size = new System.Drawing.Size(118, 20);
            this.lblCalorias.TabIndex = 17;
            this.lblCalorias.Text = "Calorías diarias:";
            // 
            // lblProteinas
            // 
            this.lblProteinas.AutoSize = true;
            this.lblProteinas.BackColor = System.Drawing.Color.Transparent;
            this.lblProteinas.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblProteinas.ForeColor = System.Drawing.Color.White;
            this.lblProteinas.Location = new System.Drawing.Point(344, 317);
            this.lblProteinas.Name = "lblProteinas";
            this.lblProteinas.Size = new System.Drawing.Size(129, 20);
            this.lblProteinas.TabIndex = 19;
            this.lblProteinas.Text = "Proteínas diarias:";
            // 
            // lblGrasas
            // 
            this.lblGrasas.AutoSize = true;
            this.lblGrasas.BackColor = System.Drawing.Color.Transparent;
            this.lblGrasas.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblGrasas.ForeColor = System.Drawing.Color.White;
            this.lblGrasas.Location = new System.Drawing.Point(45, 355);
            this.lblGrasas.Name = "lblGrasas";
            this.lblGrasas.Size = new System.Drawing.Size(112, 20);
            this.lblGrasas.TabIndex = 21;
            this.lblGrasas.Text = "Grasas totales:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDescripcion.ForeColor = System.Drawing.Color.White;
            this.lblDescripcion.Location = new System.Drawing.Point(49, 425);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(94, 20);
            this.lblDescripcion.TabIndex = 23;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblTiempoComida
            // 
            this.lblTiempoComida.AutoSize = true;
            this.lblTiempoComida.BackColor = System.Drawing.Color.Transparent;
            this.lblTiempoComida.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTiempoComida.ForeColor = System.Drawing.Color.White;
            this.lblTiempoComida.Location = new System.Drawing.Point(49, 527);
            this.lblTiempoComida.Name = "lblTiempoComida";
            this.lblTiempoComida.Size = new System.Drawing.Size(142, 20);
            this.lblTiempoComida.TabIndex = 25;
            this.lblTiempoComida.Text = "Tiempo de comida:";
            // 
            // lblDescripcionDetalle
            // 
            this.lblDescripcionDetalle.AutoSize = true;
            this.lblDescripcionDetalle.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcionDetalle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDescripcionDetalle.ForeColor = System.Drawing.Color.White;
            this.lblDescripcionDetalle.Location = new System.Drawing.Point(344, 527);
            this.lblDescripcionDetalle.Name = "lblDescripcionDetalle";
            this.lblDescripcionDetalle.Size = new System.Drawing.Size(138, 20);
            this.lblDescripcionDetalle.TabIndex = 27;
            this.lblDescripcionDetalle.Text = "Detalle de comida:";
            // 
            // txtIdDieta
            // 
            this.txtIdDieta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtIdDieta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdDieta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIdDieta.ForeColor = System.Drawing.Color.White;
            this.txtIdDieta.Location = new System.Drawing.Point(45, 141);
            this.txtIdDieta.Name = "txtIdDieta";
            this.txtIdDieta.ReadOnly = true;
            this.txtIdDieta.Size = new System.Drawing.Size(125, 27);
            this.txtIdDieta.TabIndex = 6;
            this.txtIdDieta.TextChanged += new System.EventHandler(this.txtIdDieta_TextChanged);
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
            // cmbCoach
            // 
            this.cmbCoach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cmbCoach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCoach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCoach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCoach.ForeColor = System.Drawing.Color.White;
            this.cmbCoach.FormattingEnabled = true;
            this.cmbCoach.Items.AddRange(new object[] {
            "SIN COACH"});
            this.cmbCoach.Location = new System.Drawing.Point(45, 195);
            this.cmbCoach.Name = "cmbCoach";
            this.cmbCoach.Size = new System.Drawing.Size(220, 28);
            this.cmbCoach.TabIndex = 10;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CalendarForeColor = System.Drawing.Color.White;
            this.dtpFechaInicio.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtpFechaInicio.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dtpFechaInicio.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(344, 209);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(260, 27);
            this.dtpFechaInicio.TabIndex = 12;
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
            this.dtpFechaFin.Location = new System.Drawing.Point(45, 252);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.ShowCheckBox = true;
            this.dtpFechaFin.Size = new System.Drawing.Size(220, 27);
            this.dtpFechaFin.TabIndex = 14;
            // 
            // numCarbohidratos
            // 
            this.numCarbohidratos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.numCarbohidratos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numCarbohidratos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numCarbohidratos.ForeColor = System.Drawing.Color.White;
            this.numCarbohidratos.Location = new System.Drawing.Point(479, 271);
            this.numCarbohidratos.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCarbohidratos.Name = "numCarbohidratos";
            this.numCarbohidratos.Size = new System.Drawing.Size(125, 27);
            this.numCarbohidratos.TabIndex = 16;
            this.numCarbohidratos.ThousandsSeparator = true;
            // 
            // numCalorias
            // 
            this.numCalorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.numCalorias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numCalorias.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numCalorias.ForeColor = System.Drawing.Color.White;
            this.numCalorias.Location = new System.Drawing.Point(49, 314);
            this.numCalorias.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCalorias.Name = "numCalorias";
            this.numCalorias.Size = new System.Drawing.Size(220, 27);
            this.numCalorias.TabIndex = 18;
            this.numCalorias.ThousandsSeparator = true;
            // 
            // numProteinas
            // 
            this.numProteinas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.numProteinas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numProteinas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numProteinas.ForeColor = System.Drawing.Color.White;
            this.numProteinas.Location = new System.Drawing.Point(479, 314);
            this.numProteinas.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numProteinas.Name = "numProteinas";
            this.numProteinas.Size = new System.Drawing.Size(125, 27);
            this.numProteinas.TabIndex = 20;
            this.numProteinas.ThousandsSeparator = true;
            // 
            // numGrasas
            // 
            this.numGrasas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.numGrasas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numGrasas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numGrasas.ForeColor = System.Drawing.Color.White;
            this.numGrasas.Location = new System.Drawing.Point(49, 378);
            this.numGrasas.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numGrasas.Name = "numGrasas";
            this.numGrasas.Size = new System.Drawing.Size(220, 27);
            this.numGrasas.TabIndex = 22;
            this.numGrasas.ThousandsSeparator = true;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescripcion.ForeColor = System.Drawing.Color.White;
            this.txtDescripcion.Location = new System.Drawing.Point(49, 448);
            this.txtDescripcion.MaxLength = 255;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(555, 55);
            this.txtDescripcion.TabIndex = 24;
            // 
            // cmbTiempoComida
            // 
            this.cmbTiempoComida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cmbTiempoComida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTiempoComida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTiempoComida.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTiempoComida.ForeColor = System.Drawing.Color.White;
            this.cmbTiempoComida.FormattingEnabled = true;
            this.cmbTiempoComida.Items.AddRange(new object[] {
            "DESAYUNO",
            "MEDIA MAÑANA",
            "ALMUERZO",
            "MERIENDA",
            "CENA"});
            this.cmbTiempoComida.Location = new System.Drawing.Point(53, 550);
            this.cmbTiempoComida.Name = "cmbTiempoComida";
            this.cmbTiempoComida.Size = new System.Drawing.Size(220, 28);
            this.cmbTiempoComida.TabIndex = 26;
            // 
            // txtDescripcionDetalle
            // 
            this.txtDescripcionDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtDescripcionDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcionDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescripcionDetalle.ForeColor = System.Drawing.Color.White;
            this.txtDescripcionDetalle.Location = new System.Drawing.Point(344, 550);
            this.txtDescripcionDetalle.MaxLength = 500;
            this.txtDescripcionDetalle.Multiline = true;
            this.txtDescripcionDetalle.Name = "txtDescripcionDetalle";
            this.txtDescripcionDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcionDetalle.Size = new System.Drawing.Size(260, 55);
            this.txtDescripcionDetalle.TabIndex = 28;
            // 
            // dgvDietas
            // 
            this.dgvDietas.AllowUserToAddRows = false;
            this.dgvDietas.AllowUserToDeleteRows = false;
            this.dgvDietas.AllowUserToResizeRows = false;
            this.dgvDietas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvDietas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.dgvDietas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDietas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDietas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDietas.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDietas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDietas.EnableHeadersVisualStyles = false;
            this.dgvDietas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.dgvDietas.Location = new System.Drawing.Point(700, 130);
            this.dgvDietas.MultiSelect = false;
            this.dgvDietas.Name = "dgvDietas";
            this.dgvDietas.ReadOnly = true;
            this.dgvDietas.RowHeadersVisible = false;
            this.dgvDietas.RowHeadersWidth = 51;
            this.dgvDietas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDietas.Size = new System.Drawing.Size(640, 250);
            this.dgvDietas.TabIndex = 29;
            // 
            // dgvDietaDetalle
            // 
            this.dgvDietaDetalle.AllowUserToAddRows = false;
            this.dgvDietaDetalle.AllowUserToDeleteRows = false;
            this.dgvDietaDetalle.AllowUserToResizeRows = false;
            this.dgvDietaDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvDietaDetalle.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.dgvDietaDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDietaDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDietaDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDietaDetalle.ColumnHeadersHeight = 35;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDietaDetalle.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDietaDetalle.EnableHeadersVisualStyles = false;
            this.dgvDietaDetalle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.dgvDietaDetalle.Location = new System.Drawing.Point(700, 435);
            this.dgvDietaDetalle.MultiSelect = false;
            this.dgvDietaDetalle.Name = "dgvDietaDetalle";
            this.dgvDietaDetalle.ReadOnly = true;
            this.dgvDietaDetalle.RowHeadersVisible = false;
            this.dgvDietaDetalle.RowHeadersWidth = 51;
            this.dgvDietaDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDietaDetalle.Size = new System.Drawing.Size(640, 170);
            this.dgvDietaDetalle.TabIndex = 30;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(10)))), ((int)(((byte)(18)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(45, 665);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(125, 35);
            this.btnNuevo.TabIndex = 31;
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
            this.btnRegistrar.Location = new System.Drawing.Point(185, 665);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(125, 35);
            this.btnRegistrar.TabIndex = 32;
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
            this.btnEditar.Location = new System.Drawing.Point(325, 665);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(125, 35);
            this.btnEditar.TabIndex = 33;
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
            this.btnEliminar.Location = new System.Drawing.Point(185, 710);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(125, 35);
            this.btnEliminar.TabIndex = 34;
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
            this.btnCancelar.Location = new System.Drawing.Point(325, 710);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 35);
            this.btnCancelar.TabIndex = 35;
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
            this.button1.Location = new System.Drawing.Point(1225, 666);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 34);
            this.button1.TabIndex = 36;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmDietas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::SPARTANFIT.Properties.Resources.FondoLogin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1380, 780);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblTituloRojo);
            this.Controls.Add(this.lblListado);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.lblIdDieta);
            this.Controls.Add(this.lblMiembro);
            this.Controls.Add(this.lblCoach);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.lblCarbohidratos);
            this.Controls.Add(this.lblCalorias);
            this.Controls.Add(this.lblProteinas);
            this.Controls.Add(this.lblGrasas);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblTiempoComida);
            this.Controls.Add(this.lblDescripcionDetalle);
            this.Controls.Add(this.txtIdDieta);
            this.Controls.Add(this.cmbMiembro);
            this.Controls.Add(this.cmbCoach);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.numCarbohidratos);
            this.Controls.Add(this.numCalorias);
            this.Controls.Add(this.numProteinas);
            this.Controls.Add(this.numGrasas);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.cmbTiempoComida);
            this.Controls.Add(this.txtDescripcionDetalle);
            this.Controls.Add(this.dgvDietas);
            this.Controls.Add(this.dgvDietaDetalle);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCancelar);
            this.MinimumSize = new System.Drawing.Size(1240, 720);
            this.Name = "FrmDietas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDietas";
            ((System.ComponentModel.ISupportInitialize)(this.numCarbohidratos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCalorias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProteinas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGrasas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDietas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDietaDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdDieta;
        private System.Windows.Forms.Label lblMiembro;
        private System.Windows.Forms.Label lblCoach;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblCarbohidratos;
        private System.Windows.Forms.Label lblCalorias;
        private System.Windows.Forms.Label lblProteinas;
        private System.Windows.Forms.Label lblGrasas;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblTiempoComida;
        private System.Windows.Forms.Label lblDescripcionDetalle;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTituloRojo;
        private System.Windows.Forms.Label lblListado;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.TextBox txtIdDieta;
        private System.Windows.Forms.ComboBox cmbMiembro;
        private System.Windows.Forms.ComboBox cmbCoach;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.NumericUpDown numCarbohidratos;
        private System.Windows.Forms.NumericUpDown numCalorias;
        private System.Windows.Forms.NumericUpDown numProteinas;
        private System.Windows.Forms.NumericUpDown numGrasas;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cmbTiempoComida;
        private System.Windows.Forms.TextBox txtDescripcionDetalle;
        private System.Windows.Forms.DataGridView dgvDietas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDietasCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDietasCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDietasCol3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDietasCol4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDietasCol5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDietasCol6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDietasCol7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDietasCol8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDietasCol9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDietasCol10;
        private System.Windows.Forms.DataGridView dgvDietaDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDietaDetalleCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDietaDetalleCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDietaDetalleCol3;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button button1;
    }
}
