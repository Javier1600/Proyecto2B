using Cliente.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Cliente.Web.API;

namespace Cliente
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = await WebApiLogin.PostValidarClave(new LoginRequest { Usuario = textBox1.Text, Password = textBox2.Text });
                if (usuario != null)
                    MessageBox.Show("Bienvenido " + usuario.nombre);
                switch (usuario.idRol)
                {
                    case 1:
                        var adminForm = new AdminForm(usuario);
                        adminForm.ShowDialog();
                        break;
                    case 2:
                        var formGestion = new GestionClienteForm(usuario);
                        formGestion.Show();

                        this.Hide();
                        break;
                    case 3:
                        var formDoctor = new CitasForm(usuario, DateTime.Now);
                        formDoctor.Show();
                        this.Hide();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
    }


}
