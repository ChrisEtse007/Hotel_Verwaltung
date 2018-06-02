using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SQLite;
using SQLite_Net;
using System.Diagnostics;
using Windows.UI.Popups;
using System.Data.SqlClient;
using System.Data;


// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace MyPhoneApp1
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        SqlConnection con = new SqlConnection();
        string path;
        SQLite.Net.SQLiteConnection conn;
        public MainPage()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite2");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable < Message>();
            
        }

        private void BtnKlick(object sender, RoutedEventArgs e)
        {
            

            //Txt1.Text = "Laura Schlüter ich liebe dich...";
            MainFrame.Content = new BlankPage2();
            //try
            //{
          
            //var add = conn.Insert(new Message() { Content = Txt1.Text });
            //Debug.WriteLine(path);
            //}
            //catch (Exception ex)
            //{
            //    MessageDialog msgbox = new MessageDialog(" Eror" + ex);
            //}

        }

        private void BtnKlick2(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new BlankPage1();

            //var query = conn.Table<Message>();
            //string result = String.Empty;
            //foreach (var item in query)
            //{
            //    //result = String.Format("{0}: {1}", item.Id, item.Content);
            //    result = String.Format(" {0}", item.Content);
            //    Debug.WriteLine(result);

           // }
        }
    }
}
