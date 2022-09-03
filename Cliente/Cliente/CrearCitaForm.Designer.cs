
namespace Cliente
{
    partial class CrearCitaForm
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
            this.cbxDoctor = new System.Windows.Forms.ComboBox();
            this.usuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.cbxEspeciliadades = new System.Windows.Forms.ComboBox();
            this.especialidadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbxHoras = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxDoctor
            // 
            this.cbxDoctor.DataSource = this.usuarioBindingSource;
            this.cbxDoctor.Enabled = false;
            this.cbxDoctor.FormattingEnabled = true;
            this.cbxDoctor.Location = new System.Drawing.Point(189, 71);
            this.cbxDoctor.Name = "cbxDoctor";
            this.cbxDoctor.Size = new System.Drawing.Size(290, 24);
            this.cbxDoctor.TabIndex = 0;
            this.cbxDoctor.SelectedIndexChanged += new System.EventHandler(this.cbxDoctor_SelectedIndexChanged);
            // 
            // usuarioBindingSource
            // 
            this.usuarioBindingSource.DataSource = typeof(Cliente.Models.Usuario);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(189, 121);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(189, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Crear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbxEspeciliadades
            // 
            this.cbxEspeciliadades.DataSource = this.especialidadBindingSource;
            this.cbxEspeciliadades.DisplayMember = "nombreEspecialidad";
            this.cbxEspeciliadades.FormattingEnabled = true;
            this.cbxEspeciliadades.Location = new System.Drawing.Point(189, 28);
            this.cbxEspeciliadades.Name = "cbxEspeciliadades";
            this.cbxEspeciliadades.Size = new System.Drawing.Size(290, 24);
            this.cbxEspeciliadades.TabIndex = 3;
            this.cbxEspeciliadades.ValueMember = "idEspecialidad";
            this.cbxEspeciliadades.SelectedIndexChanged += new System.EventHandler(this.cbxEspeciliadades_SelectedIndexChanged);
            // 
            // especialidadBindingSource
            // 
            this.especialidadBindingSource.DataSource = typeof(Cliente.Models.Especialidad);
            // 
            // cbxHoras
            // 
            this.cbxHoras.FormattingEnabled = true;
            this.cbxHoras.Items.AddRange(new object[] {
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17"});
            this.cbxHoras.Location = new System.Drawing.Point(189, 166);
            this.cbxHoras.Name = "cbxHoras";
            this.cbxHoras.Size = new System.Drawing.Size(121, 24);
            this.cbxHoras.TabIndex = 4;
            this.cbxHoras.SelectedIndexChanged += new System.EventHandler(this.cbxHoras_SelectedIndexChanged);
            // 
            // CrearCitaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbxHoras);
            this.Controls.Add(this.cbxEspeciliadades);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cbxDoctor);
            this.Name = "CrearCitaForm";
            this.Text = "CrearCitaForm";
            this.Load += new System.EventHandler(this.CrearCitaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxDoctor;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ComboBox cbxEspeciliadades;
        private System.Windows.Forms.BindingSource especialidadBindingSource;
        private System.Windows.Forms.BindingSource usuarioBindingSource;
        private System.Windows.Forms.ComboBox cbxHoras;
    }
}