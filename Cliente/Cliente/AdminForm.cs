using Cliente.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class AdminForm : Form
    {
        private Usuario usuario;
        public AdminForm(Usuario _usuario)
        {
            InitializeComponent();
            _usuario = usuario;
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            var crearCitaForm = new CrearCitaForm();
            crearCitaForm.ShowDialog();
        }
    }
}
