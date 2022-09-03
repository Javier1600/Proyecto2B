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
    public partial class GestionClienteForm : Form
    {
        private Usuario usuario;
        private List<Especialidad> especialidades;
        private Especialidad especialidad;
        private DateTime fecha;
        public GestionClienteForm(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            fecha = monthCalendar1.SelectionStart.Date;
            especialidad = (Especialidad)cbxEspeciliadades.SelectedItem;
            var citaForm = new CitasForm(usuario, especialidad, fecha);
            citaForm.ShowDialog();
        }

        private async void GestionClienteForm_Load(object sender, EventArgs e)
        {
            especialidades = await WebApiEspecialidad.GetEspecialidades();
            especialidadBindingSource.DataSource = especialidades;
            Actualizar();


        }

        private async void Actualizar()
        {
            var citas = await WebApiCita.GetCitasAgendadas(usuario.idUsuario);
            citaBindingSource.DataSource = citas;
        }

        private void cbxEspeciliadades_SelectedIndexChanged(object sender, EventArgs e)
        {
            monthCalendar1.Enabled = true;
        }

        private async void btnDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                var cita = (Cita)lbxCitasAgendadas.SelectedItem;
                var doctor = await WebApiUsuario.GetUsuario(cita.idDoctor.Value);
                var consultorio = await WebApiConsultorio.GetConsultorio(cita.idDoctor.Value);
                if (doctor != null)
                {
                    MessageBox.Show($"Se ha agendado con el doctor: {doctor.nombre}, a las {cita.hora} para la fecha: {cita.fecha} en el consultorio {consultorio.numeroConsultorio}");
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Actualizar();
        }
    }
}
