using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.Collections;
using SqlLite.Models;

namespace SqlLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage    
    {
        private SQLiteAsyncConnection con;
        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }
        public static IEnumerable<Postulante> SELECT_WHERE(SQLiteConnection db, string email,string identificacion)
        {
            return db.Query<Postulante>("SELECT * FROM POSTULANTE WHERE EMAIL=? AND IDENTIFICACION=?", email, identificacion);
        }
        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "test.db3");
                var db = new SQLiteConnection(databasePath);
                db.CreateTable<Postulante>();
                IEnumerable<Postulante> result = SELECT_WHERE(db, txtEmail.Text, txtPassword.Text);
                if (result.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Error de Acceso!", "No existe el usuario ingresado !!", "cerrar");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }





    }
}