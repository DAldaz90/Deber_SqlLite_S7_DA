using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using SqlLite.Models;

namespace SqlLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
        
    {
        private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var datosRegistro = new Postulante { nombre = txtNombre.Text, email = txtUser.Text, identificacion = txtPassword.Text };
                con.InsertAsync(datosRegistro);
                DisplayAlert("Mensaje", "Ingreso Correcto", "cerrar");
                txtNombre.Text = "";
                txtUser.Text = "";
                txtPassword.Text = "";
            }
            catch (Exception ex)
            {

                DisplayAlert("Mensaje", ex.Message, "cerrar");
            }
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}