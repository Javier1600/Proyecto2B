using Cliente.Models;
using Cliente.Web.API;
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
    public partial class CrearCitaForm : Form
    {
        public CrearCitaForm()
        {
            InitializeComponent();
        }

        private async void cbxEspeciliadades_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxDoctor.Enabled = true;
            var usuarios = await WebApiUsuario.GetUsuarios();
            var docs = await WebApiDoctor.GetDoctores();
            docs = docs.Where(x => x.idEspecialidad == ((Especialidad)cbxEspeciliadades.SelectedItem).idEspecialidad).ToList();
            var docsEsp = new List<Usuario>();
            foreach (var item in usuarios)
            {
                foreach (var d in docs)
                {
                    if(item.idUsuario == d.idUsuario)
                    {
                        docsEsp.Add(item);
                    }
                }
            }
            usuarioBindingSource.DataSource = docsEsp.Where(x => x.idRol == 3).ToList();

        }

        private void cbxDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxHoras.Enabled = true;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var cita = new Cita();

            cita.idDoctor = ((Usuario)cbxDoctor.SelectedItem).idUsuario;
            cita.fecha = dateTimePicker1.Value.Date;

            cita.hora = new TimeSpan(Convert.ToInt32(cbxHoras.SelectedItem), 0, 0);
            cita.diponibilidad = true;
            
            try
            {
                bool res = await WebApiCita.CrearCita(cita);
                if (res)
                {
                    MessageBox.Show("Se ha creado la cita");
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void cbxHoras_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private async void CrearCitaForm_Load(object sender, EventArgs e)
        {
            try
            {
                var especialidades = await WebApiEspecialidad.GetEspecialidades();
                especialidadBindingSource.DataSource = especialidades;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
