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
    public partial class CitasForm
        : Form
    {
        private List<Cita> citas;
        private DateTime fecha;
        private Especialidad especialidad;
        private Usuario usuario;
        private DateTime now;
        private bool esDoctor;

        public CitasForm(Usuario _usuario, Especialidad _especialidad, DateTime _fecha)
        {
            InitializeComponent();
            fecha = _fecha;
            especialidad = _especialidad;
            usuario = _usuario;
        }

        public CitasForm(Usuario usuario, DateTime now)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.now = now;
            this.esDoctor = true;
        }

        private async void CitasForm_Load(object sender, EventArgs e)
        {
            if (esDoctor)
            {
                this.btnTomarTurno.Text = "Ver Detalle";
                
                try
                {
                    
                    var Tcitas = await WebApiCita.GetCitas();

                    citas = Tcitas.Where(x => !x.diponibilidad.Value && x.idDoctor == usuario.idUsuario && x.fecha == now.Date).ToList();
                    if (citas.Count > 0)
                        citaBindingSource.DataSource = citas;
                    else
                        MessageBox.Show("No existen citas para hoy");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    citas = await WebApiCita.GetCitas(fecha, especialidad.idEspecialidad);
                    if (citas.Count > 0)
                        citaBindingSource.DataSource = citas.Where(x => x.diponibilidad.Value);
                    else
                        MessageBox.Show("No existen citas para esta fecha");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            
            
        }

        private async void btnTomarTurno_Click(object sender, EventArgs e)
        {
            if (esDoctor)
            {
                try
                {
                    var consultorio = await WebApiConsultorio.GetConsultorio(usuario.idUsuario);
                    var cita = (Cita)lbxCitas.SelectedItem;
                    var paciente = WebApiUsuario.GetUsuario(cita.idPaciente.Value);
                    MessageBox.Show($"Se ha agendado con el paciente: {usuario.nombre}, a las {cita.hora} para la fecha: {cita.fecha} en el consultorio {consultorio.numeroConsultorio}");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                var resp = MessageBox.Show("Esta seguro de tomar esta cita?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (resp is DialogResult.Yes)
                {
                    try
                    {
                        
                        var cita = (Cita)lbxCitas.SelectedItem;
                        cita.idPaciente = usuario.idUsuario;
                        cita.diponibilidad = false;
                        var respuesta = await WebApiCita.AgendarCita(cita);
                        var doctor = await WebApiUsuario.GetUsuario(cita.idDoctor.Value);
                        var consultorio = await WebApiConsultorio.GetConsultorio(cita.idDoctor.Value);
                        if (respuesta)
                        {
                            MessageBox.Show($"Se ha agendado con el doctor: {doctor.nombre}, a las {cita.hora} para la fecha: {cita.fecha} en el consultorio {consultorio.numeroConsultorio}");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                }
                this.Close();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
