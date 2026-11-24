using System;

namespace SPARTANFIT.VISTA
{
    partial class FrmSeguimiento
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
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTituloRojo = new System.Windows.Forms.Label();
            this.lblListado = new System.Windows.Forms.Label();
            this.lblIdSeguimiento = new System.Windows.Forms.Label();
            this.lblObjetivo = new System.Windows.Forms.Label();
            this.lblCoach = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblComentario = new System.Windows.Forms.Label();
            this.txtIdSeguimiento = new System.Windows.Forms.TextBox();
            this.cmbObjetivo = new System.Windows.Forms.ComboBox();
            this.cmbCoach = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.numValor = new System.Windows.Forms.NumericUpDown();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.dgvSeguimiento = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numValor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeguimiento)).BeginInit();
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
            this.lblTitulo.Location = new System.Drawing.Point(455, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(167, 45);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "GESTIÓN DE";
            // 
            // lblTituloRojo
            // 
            this.lblTituloRojo.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloRojo.Font = new System.Drawing.Font("Bebas Neue", 25F, System.Drawing.FontStyle.Bold);
            this.lblTituloRojo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(25)))), ((int)(((byte)(35)))));
            this.lblTituloRojo.Location = new System.Drawing.Point(615, 15);
            this.lblTituloRojo.Name = "lblTituloRojo";
            this.lblTituloRojo.Size = new System.Drawing.Size(360, 45);
            this.lblTituloRojo.TabIndex = 2;
            this.lblTituloRojo.Text = "SEGUIMIENTO";
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
            this.lblListado.Text = "SEGUIMIENTOS REGISTRADOS";
            // 
            // lblIdSeguimiento
            // 
            this.lblIdSeguimiento.AutoSize = true;
            this.lblIdSeguimiento.BackColor = System.Drawing.Color.Transparent;
            this.lblIdSeguimiento.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblIdSeguimiento.ForeColor = System.Drawing.Color.White;
            this.lblIdSeguimiento.Location = new System.Drawing.Point(45, 128);
            this.lblIdSeguimiento.Name = "lblIdSeguimiento";
            this.lblIdSeguimiento.Size = new System.Drawing.Size(121, 20);
            this.lblIdSeguimiento.TabIndex = 5;
            this.lblIdSeguimiento.Text = "ID Seguimiento:";
            // 
            // lblObjetivo
            // 
            this.lblObjetivo.AutoSize = true;
            this.lblObjetivo.BackColor = System.Drawing.Color.Transparent;
            this.lblObjetivo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblObjetivo.ForeColor = System.Drawing.Color.White;
            this.lblObjetivo.Location = new System.Drawing.Point(340, 128);
            this.lblObjetivo.Name = "lblObjetivo";
            this.lblObjetivo.Size = new System.Drawing.Size(72, 20);
            this.lblObjetivo.TabIndex = 7;
            this.lblObjetivo.Text = "Objetivo:";
            // 
            // lblCoach
            // 
            this.lblCoach.AutoSize = true;
            this.lblCoach.BackColor = System.Drawing.Color.Transparent;
            this.lblCoach.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCoach.ForeColor = System.Drawing.Color.White;
            this.lblCoach.Location = new System.Drawing.Point(45, 222);
            this.lblCoach.Name = "lblCoach";
            this.lblCoach.Size = new System.Drawing.Size(55, 20);
            this.lblCoach.TabIndex = 9;
            this.lblCoach.Text = "Coach:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(340, 222);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(101, 20);
            this.lblFecha.TabIndex = 11;
            this.lblFecha.Text = "Fecha y hora:";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.BackColor = System.Drawing.Color.Transparent;
            this.lblValor.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblValor.ForeColor = System.Drawing.Color.White;
            this.lblValor.Location = new System.Drawing.Point(45, 318);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(125, 20);
            this.lblValor.TabIndex = 13;
            this.lblValor.Text = "Valor registrado:";
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.BackColor = System.Drawing.Color.Transparent;
            this.lblComentario.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblComentario.ForeColor = System.Drawing.Color.White;
            this.lblComentario.Location = new System.Drawing.Point(340, 318);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(95, 20);
            this.lblComentario.TabIndex = 15;
            this.lblComentario.Text = "Comentario:";
            // 
            // txtIdSeguimiento
            // 
            this.txtIdSeguimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtIdSeguimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdSeguimiento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIdSeguimiento.ForeColor = System.Drawing.Color.White;
            this.txtIdSeguimiento.Location = new System.Drawing.Point(49, 151);
            this.txtIdSeguimiento.Name = "txtIdSeguimiento";
            this.txtIdSeguimiento.ReadOnly = true;
            this.txtIdSeguimiento.Size = new System.Drawing.Size(125, 27);
            this.txtIdSeguimiento.TabIndex = 6;
            // 
            // cmbObjetivo
            // 
            this.cmbObjetivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cmbObjetivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbObjetivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbObjetivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbObjetivo.ForeColor = System.Drawing.Color.White;
            this.cmbObjetivo.FormattingEnabled = true;
            this.cmbObjetivo.Location = new System.Drawing.Point(340, 151);
            this.cmbObjetivo.Name = "cmbObjetivo";
            this.cmbObjetivo.Size = new System.Drawing.Size(260, 28);
            this.cmbObjetivo.TabIndex = 8;
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
            this.cmbCoach.Location = new System.Drawing.Point(45, 245);
            this.cmbCoach.Name = "cmbCoach";
            this.cmbCoach.Size = new System.Drawing.Size(220, 28);
            this.cmbCoach.TabIndex = 10;
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
            this.dtpFecha.Location = new System.Drawing.Point(340, 245);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.ShowUpDown = true;
            this.dtpFecha.Size = new System.Drawing.Size(260, 27);
            this.dtpFecha.TabIndex = 12;
            // 
            // numValor
            // 
            this.numValor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.numValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numValor.DecimalPlaces = 2;
            this.numValor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numValor.ForeColor = System.Drawing.Color.White;
            this.numValor.Location = new System.Drawing.Point(45, 341);
            this.numValor.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numValor.Name = "numValor";
            this.numValor.Size = new System.Drawing.Size(220, 27);
            this.numValor.TabIndex = 14;
            this.numValor.ThousandsSeparator = true;
            // 
            // txtComentario
            // 
            this.txtComentario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComentario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtComentario.ForeColor = System.Drawing.Color.White;
            this.txtComentario.Location = new System.Drawing.Point(340, 341);
            this.txtComentario.MaxLength = 255;
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComentario.Size = new System.Drawing.Size(260, 85);
            this.txtComentario.TabIndex = 16;
            // 
            // dgvSeguimiento
            // 
            this.dgvSeguimiento.AllowUserToAddRows = false;
            this.dgvSeguimiento.AllowUserToDeleteRows = false;
            this.dgvSeguimiento.AllowUserToResizeRows = false;
            this.dgvSeguimiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvSeguimiento.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.dgvSeguimiento.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSeguimiento.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSeguimiento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSeguimiento.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSeguimiento.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSeguimiento.EnableHeadersVisualStyles = false;
            this.dgvSeguimiento.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.dgvSeguimiento.Location = new System.Drawing.Point(700, 130);
            this.dgvSeguimiento.MultiSelect = false;
            this.dgvSeguimiento.Name = "dgvSeguimiento";
            this.dgvSeguimiento.ReadOnly = true;
            this.dgvSeguimiento.RowHeadersVisible = false;
            this.dgvSeguimiento.RowHeadersWidth = 51;
            this.dgvSeguimiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeguimiento.Size = new System.Drawing.Size(640, 430);
            this.dgvSeguimiento.TabIndex = 17;
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
            this.btnNuevo.TabIndex = 18;
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
            this.btnRegistrar.TabIndex = 19;
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
            this.btnEditar.TabIndex = 20;
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
            this.btnEliminar.TabIndex = 21;
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
            this.btnCancelar.TabIndex = 22;
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
            this.button1.Location = new System.Drawing.Point(1225, 609);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 34);
            this.button1.TabIndex = 33;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmSeguimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::SPARTANFIT.Properties.Resources.FondoLogin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1380, 760);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblTituloRojo);
            this.Controls.Add(this.lblListado);
            this.Controls.Add(this.lblIdSeguimiento);
            this.Controls.Add(this.lblObjetivo);
            this.Controls.Add(this.lblCoach);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblComentario);
            this.Controls.Add(this.txtIdSeguimiento);
            this.Controls.Add(this.cmbObjetivo);
            this.Controls.Add(this.cmbCoach);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.numValor);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.dgvSeguimiento);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCancelar);
            this.MinimumSize = new System.Drawing.Size(1240, 700);
            this.Name = "FrmSeguimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSeguimiento";
            ((System.ComponentModel.ISupportInitialize)(this.numValor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeguimiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            FrmMenuPrincipal menu = new FrmMenuPrincipal();
            menu.Show();
            this.Hide();
        }

        #endregion

        private System.Windows.Forms.Label lblIdSeguimiento;
        private System.Windows.Forms.Label lblObjetivo;
        private System.Windows.Forms.Label lblCoach;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTituloRojo;
        private System.Windows.Forms.Label lblListado;
        private System.Windows.Forms.TextBox txtIdSeguimiento;
        private System.Windows.Forms.ComboBox cmbObjetivo;
        private System.Windows.Forms.ComboBox cmbCoach;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.NumericUpDown numValor;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.DataGridView dgvSeguimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSeguimientoCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSeguimientoCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSeguimientoCol3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSeguimientoCol4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSeguimientoCol5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSeguimientoCol6;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button button1;
    }
}
