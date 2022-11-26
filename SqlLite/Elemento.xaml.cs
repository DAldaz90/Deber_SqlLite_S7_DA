using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SqlLite.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Xamarin.Essentials;

namespace SqlLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int idSel;
        private SQLiteAsyncConnection con;
        IEnumerable<Postulante> borrar; 
        IEnumerable<Postulante> actualizar;

        public Elemento(int id,string email)
        {
            InitializeComponent();
            idSel = id;
            con = DependencyService.Get<Database>().GetConnection();
            txtEmail.Text = email;
        }

       

        public static IEnumerable<Postulante> borrar1(SQLiteConnection db,int id)
        {
            return db.Query<Postulante>("DELETE FROM POSTULANTE WHERE ID =?", id);
        }
        public static IEnumerable<Postulante> actualizar1(SQLiteConnection db, int id,string nombre ,string email,string identificacion)
        {
            return db.Query<Postulante>("UPDATE POSTULANTE SET NOMBRE =?,EMAIL=?,IDENTIFICACION=? WHERE ID=?", id,nombre,email,identificacion);
        }
        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "test.db3");
            var db = new SQLiteConnection(databasePath);
            actualizar = actualizar1(db, idSel, txtNombre.Text, txtEmail.Text, txtPassword.Text);
            DisplayAlert("Mensaje", "Actualizacion Exitosa !", "Cerrar");
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "test.db3");
            var db = new SQLiteConnection(databasePath);
            borrar = borrar1(db, idSel);
            DisplayAlert("Mensaje", "Registro Eliminado !", "Cerrar");

            Navigation.PushAsync(new ConsultaRegistro());

        }
    }
}