
namespace Cliente
{
    partial class CitasForm
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
            this.lbxCitas = new System.Windows.Forms.ListBox();
            this.citaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnTomarTurno = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.citaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxCitas
            // 
            this.lbxCitas.DataSource = this.citaBindingSource;
            this.lbxCitas.FormattingEnabled = true;
            this.lbxCitas.ItemHeight = 16;
            this.lbxCitas.Location = new System.Drawing.Point(99, 36);
            this.lbxCitas.Name = "lbxCitas";
            this.lbxCitas.Size = new System.Drawing.Size(245, 388);
            this.lbxCitas.TabIndex = 0;
            // 
            // citaBindingSource
            // 
            this.citaBindingSource.DataSource = typeof(Cliente.Models.Cita);
            // 
            // btnTomarTurno
            // 
            this.btnTomarTurno.Location = new System.Drawing.Point(377, 164);
            this.btnTomarTurno.Name = "btnTomarTurno";
            this.btnTomarTurno.Size = new System.Drawing.Size(140, 23);
            this.btnTomarTurno.TabIndex = 1;
            this.btnTomarTurno.Text = "Tomar turno";
            this.btnTomarTurno.UseVisualStyleBackColor = true;
            this.btnTomarTurno.Click += new System.EventHandler(this.btnTomarTurno_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(377, 235);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CitasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnTomarTurno);
            this.Controls.Add(this.lbxCitas);
            this.Name = "CitasForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.CitasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.citaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxCitas;
        private System.Windows.Forms.Button btnTomarTurno;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.BindingSource citaBindingSource;
    }
}