using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SQLite;
using SqlLite.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqlLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Postulante> tablaPostulante;
        public ConsultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this ,false);
            Datos();
        }
        public async void Datos()
        {
            var result = await con.Table<Postulante>().ToListAsync();
            tablaPostulante = new ObservableCollection<Postulante>(result);
            ListaPostu.ItemsSource = tablaPostulante;
        }

        private void ListaPostu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Postulante)e.SelectedItem;
            var item = Obj.id.ToString();
            var IdSelec = Convert.ToInt32(item);
            var email = Obj.email;
            try
            {
                Navigation.PushAsync(new Elemento(IdSelec,email));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}