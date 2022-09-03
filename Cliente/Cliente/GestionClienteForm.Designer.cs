
namespace Cliente
{
    partial class GestionClienteForm
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
            this.components = new System.ComponentModel.Container();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.cbxEspeciliadades = new System.Windows.Forms.ComboBox();
            this.especialidadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbxCitasAgendadas = new System.Windows.Forms.ListBox();
            this.citaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnDetalle = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.citaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Enabled = false;
            this.monthCalendar1.Location = new System.Drawing.Point(43, 190);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // cbxEspeciliadades
            // 
            this.cbxEspeciliadades.DataSource = this.especialidadBindingSource;
            this.cbxEspeciliadades.DisplayMember = "nombreEspecialidad";
            this.cbxEspeciliadades.FormattingEnabled = true;
            this.cbxEspeciliadades.Location = new System.Drawing.Point(43, 109);
            this.cbxEspeciliadades.Name = "cbxEspeciliadades";
            this.cbxEspeciliadades.Size = new System.Drawing.Size(290, 24);
            this.cbxEspeciliadades.TabIndex = 2;
            this.cbxEspeciliadades.ValueMember = "idEspecialidad";
            this.cbxEspeciliadades.SelectedIndexChanged += new System.EventHandler(this.cbxEspeciliadades_SelectedIndexChanged);
            // 
            // especialidadBindingSource
            // 
            this.especialidadBindingSource.DataSource = typeof(Cliente.Models.Especialidad);
            // 
            // lbxCitasAgendadas
            // 
            this.lbxCitasAgendadas.DataSource = this.citaBindingSource;
            this.lbxCitasAgendadas.FormattingEnabled = true;
            this.lbxCitasAgendadas.ItemHeight = 16;
            this.lbxCitasAgendadas.Location = new System.Drawing.Point(494, 121);
            this.lbxCitasAgendadas.Name = "lbxCitasAgendadas";
            this.lbxCitasAgendadas.Size = new System.Drawing.Size(227, 276);
            this.lbxCitasAgendadas.TabIndex = 3;
            // 
            // citaBindingSource
            // 
            this.citaBindingSource.DataSource = typeof(Cliente.Models.Cita);
            // 
            // btnDetalle
            // 
            this.btnDetalle.Location = new System.Drawing.Point(554, 403);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(111, 23);
            this.btnDetalle.TabIndex = 4;
            this.btnDetalle.Text = "Ver Detalle";
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Actualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GestionClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.lbxCitasAgendadas);
            this.Controls.Add(this.cbxEspeciliadades);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "GestionClienteForm";
            this.Text = "GestionClienteForm";
            this.Load += new System.EventHandler(this.GestionClienteForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.especialidadBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.citaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.BindingSource especialidadBindingSource;
        public System.Windows.Forms.ComboBox cbxEspeciliadades;
        private System.Windows.Forms.ListBox lbxCitasAgendadas;
        private System.Windows.Forms.BindingSource citaBindingSource;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.Button button1;
    }
}