using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlLite.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SqlCliente))]
namespace SqlLite.Droid
{
    public class SqlCliente : Database
    {

        public SQLiteAsyncConnection GetConnection()
        {
            var DocumentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(DocumentPath, "test.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}