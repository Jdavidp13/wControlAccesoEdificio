namespace wControlAccesoEdificio.Forms
{
    partial class AccesoForm
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
            this.txtEmpleadoId = new System.Windows.Forms.TextBox();
            this.txtVisitanteId = new System.Windows.Forms.TextBox();
            this.txtZona = new System.Windows.Forms.TextBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.chkAutorizado = new System.Windows.Forms.CheckBox();
            this.dgvAccesos = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblRegistroDeAccesos = new System.Windows.Forms.Label();
            this.lblEmpleadoId = new System.Windows.Forms.Label();
            this.lblVisitanteId = new System.Windows.Forms.Label();
            this.lblZona = new System.Windows.Forms.Label();
            this.lblMotivo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccesos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEmpleadoId
            // 
            this.txtEmpleadoId.Location = new System.Drawing.Point(184, 62);
            this.txtEmpleadoId.Name = "txtEmpleadoId";
            this.txtEmpleadoId.Size = new System.Drawing.Size(130, 22);
            this.txtEmpleadoId.TabIndex = 0;
            // 
            // txtVisitanteId
            // 
            this.txtVisitanteId.Location = new System.Drawing.Point(184, 102);
            this.txtVisitanteId.Name = "txtVisitanteId";
            this.txtVisitanteId.Size = new System.Drawing.Size(130, 22);
            this.txtVisitanteId.TabIndex = 1;
            // 
            // txtZona
            // 
            this.txtZona.Location = new System.Drawing.Point(184, 143);
            this.txtZona.Name = "txtZona";
            this.txtZona.Size = new System.Drawing.Size(130, 22);
            this.txtZona.TabIndex = 2;
            this.txtZona.TextChanged += new System.EventHandler(this.txtZona_TextChanged);
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(184, 184);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(130, 22);
            this.txtMotivo.TabIndex = 3;
            this.txtMotivo.TextChanged += new System.EventHandler(this.txtMotivo_TextChanged);
            // 
            // chkAutorizado
            // 
            this.chkAutorizado.AutoSize = true;
            this.chkAutorizado.Location = new System.Drawing.Point(201, 221);
            this.chkAutorizado.Name = "chkAutorizado";
            this.chkAutorizado.Size = new System.Drawing.Size(93, 20);
            this.chkAutorizado.TabIndex = 4;
            this.chkAutorizado.Text = "Autorizado";
            this.chkAutorizado.UseVisualStyleBackColor = true;
            // 
            // dgvAccesos
            // 
            this.dgvAccesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccesos.Location = new System.Drawing.Point(12, 261);
            this.dgvAccesos.Name = "dgvAccesos";
            this.dgvAccesos.RowHeadersWidth = 51;
            this.dgvAccesos.RowTemplate.Height = 24;
            this.dgvAccesos.Size = new System.Drawing.Size(776, 165);
            this.dgvAccesos.TabIndex = 5;
            this.dgvAccesos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccesos_CellClick_1);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(354, 114);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(119, 35);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click_1);
            // 
            // lblRegistroDeAccesos
            // 
            this.lblRegistroDeAccesos.AutoSize = true;
            this.lblRegistroDeAccesos.Location = new System.Drawing.Point(295, 18);
            this.lblRegistroDeAccesos.Name = "lblRegistroDeAccesos";
            this.lblRegistroDeAccesos.Size = new System.Drawing.Size(135, 16);
            this.lblRegistroDeAccesos.TabIndex = 7;
            this.lblRegistroDeAccesos.Text = "Registro De Accesos";
            this.lblRegistroDeAccesos.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblEmpleadoId
            // 
            this.lblEmpleadoId.AutoSize = true;
            this.lblEmpleadoId.Location = new System.Drawing.Point(92, 65);
            this.lblEmpleadoId.Name = "lblEmpleadoId";
            this.lblEmpleadoId.Size = new System.Drawing.Size(86, 16);
            this.lblEmpleadoId.TabIndex = 8;
            this.lblEmpleadoId.Text = "Empleado ID";
            // 
            // lblVisitanteId
            // 
            this.lblVisitanteId.AutoSize = true;
            this.lblVisitanteId.Location = new System.Drawing.Point(92, 105);
            this.lblVisitanteId.Name = "lblVisitanteId";
            this.lblVisitanteId.Size = new System.Drawing.Size(74, 16);
            this.lblVisitanteId.TabIndex = 9;
            this.lblVisitanteId.Text = "Visitante ID";
            // 
            // lblZona
            // 
            this.lblZona.AutoSize = true;
            this.lblZona.Location = new System.Drawing.Point(92, 146);
            this.lblZona.Name = "lblZona";
            this.lblZona.Size = new System.Drawing.Size(38, 16);
            this.lblZona.TabIndex = 10;
            this.lblZona.Text = "Zona";
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(101, 190);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(47, 16);
            this.lblMotivo.TabIndex = 11;
            this.lblMotivo.Text = "Motivo";
            // 
            // AccesoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.lblZona);
            this.Controls.Add(this.lblVisitanteId);
            this.Controls.Add(this.lblEmpleadoId);
            this.Controls.Add(this.lblRegistroDeAccesos);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvAccesos);
            this.Controls.Add(this.chkAutorizado);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.txtZona);
            this.Controls.Add(this.txtVisitanteId);
            this.Controls.Add(this.txtEmpleadoId);
            this.Name = "AccesoForm";
            this.Text = "AccesoForm";
            this.Load += new System.EventHandler(this.AccesoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccesos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmpleadoId;
        private System.Windows.Forms.TextBox txtVisitanteId;
        private System.Windows.Forms.TextBox txtZona;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.CheckBox chkAutorizado;
        private System.Windows.Forms.DataGridView dgvAccesos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblRegistroDeAccesos;
        private System.Windows.Forms.Label lblEmpleadoId;
        private System.Windows.Forms.Label lblVisitanteId;
        private System.Windows.Forms.Label lblZona;
        private System.Windows.Forms.Label lblMotivo;
    }
}