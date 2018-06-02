using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Media.Animation;
using System.Text.RegularExpressions;

namespace KasseSys
{


    public class Produkten
    {
        public string Artikel { get; set; }
        public decimal Price { get; set; }
    }


    public partial class MainWindow : Window
    {
        bool verbindung = false;

        SqlConnection con = new SqlConnection();
        private ObservableCollection<Produkten> Produkten_Objekt_Observable;
        private decimal decSpeicher;


        public MainWindow()
        {
            InitializeComponent();

            con.ConnectionString = "Data Source=desktop-jtcs65f ;Initial" +
            " Catalog=K_SystemDB;Integrated Security=True;" +
            "Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;" +
            "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


            Produkten_Objekt_Observable = new ObservableCollection<Produkten>() { }; // muss im  InitializeComponent initialisiert sein, damit der Datagrid 
            // sich nicht jedesmal aktualisiert== INotifyPropertyChange
            //{
            //    new Person(){Artikel="Prabhat",Price=(decimal)4.4},

            //    new Person(){Artikel="Smith",Price=(decimal)3.2}
            //};
            //dataGrid.ItemsSource = person;


        }



     
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

         
                try
                {
                    

                    SqlConnection sc = new SqlConnection();
                    SqlCommand com = new SqlCommand();
                    sc.ConnectionString = ("Data Source=desktop-jtcs65f ;Initial" +
                                           " Catalog=K_SystemDB;Integrated Security=True;" +
                                           "Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;" +
                                           "ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    sc.Open();
                    com.Connection = sc;
                    com.CommandText = ("INSERT INTO TableKS1 (Artikel, Price) VALUES ('" + txtName.Text + "' , '" + txtAddress.Text + "');");
                    // com.CommandText = "delete from TableKS1 where Artikel = '" + this.txtName.Text + "'";
                   // com.CommandText = "update TableKS1 where Artikel = '" + this.txtName.Text + "'";

                   // com.CommandText = "UPDATE TableKS1 SET Price = '" + this.txtAddress.Text + "' WHERE Artikel= '" + this.txtName.Text + "'";
                   com.ExecuteNonQuery();
                 
                    MessageBox.Show("eingeführt");
                    sc.Close();
                }
                catch (Exception  )
                {
                    MessageBox.Show(" Bitte geben Sie einen gültigen Wert ein" );
                    con.Close();
                }


        }


        //public void ObservableCollection__Metohde()
        //{
           
        //        //person = new ObservableCollection<Person>() { }; ---------- So wird der DataGrid jedesmal actualisiert
        //        Produkten_Objekt_Observable.Add(new Produkten() { Artikel = txtName.Text, Price = System.Convert.ToDecimal(txtAddress.Text) });
        //        dataGrid.ItemsSource = Produkten_Objekt_Observable;
        //        txtName.Text = string.Empty;
        //        txtAddress.Text = string.Empty;            
        //}

        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //-------------------
        }

        private void GridRowSelected(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row_Selected = dg.SelectedItem as DataRowView;
            if (row_Selected != null)
            {
                txtName.Text = row_Selected["Artikel"].ToString();
                txtAddress.Text = row_Selected["Price"].ToString();


                decimal dec = System.Convert.ToDecimal(txtAddress.Text);

                decSpeicher += dec;
                Txb_Total.Text = decSpeicher.ToString();



                //person = new ObservableCollection<Person>() { }; ---------- So wird der DataGrid jedesmal actualisiert
                Produkten_Objekt_Observable.Add(new Produkten() { Artikel = txtName.Text, Price = System.Convert.ToDecimal(txtAddress.Text) });



                dataGrid2.ItemsSource = Produkten_Objekt_Observable;
                txtName.Text = string.Empty;
                txtAddress.Text = string.Empty;


            }
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                con.Open();
                verbindung = true;

                SqlCommand cmd = new SqlCommand();
                // alles anzeigen
                string query = " select * from TableKS1 ";
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt;

                // für search
                dt = new DataTable("TableKS1");
                da.Fill(dt);
                tempDtSpeicher = dt;



                DataSet ds = new DataSet();
                int a = da.Fill(ds, " TableKS1 ");

                if (verbindung == true)
                {
                    MessageBox.Show("Verbindung OK");
                }
                if (a > 0)
                {
                    dataGrid.ItemsSource = ds.Tables[" TableKS1 "].DefaultView;

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error" + ex);
                con.Close();
            }

        }

        private void Btn_Rückgeld_Click(object sender, RoutedEventArgs e)
        {
            decimal Zahl1= System.Convert.ToDecimal(Txb_Total.Text);
            decimal Zahl2 = System.Convert.ToDecimal(TexBargeld.Text);

            decimal Sum = Zahl1 - Zahl2;

            TexRückgeld.Text = Sum.ToString() ;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            Tastatur window = new Tastatur();
           // window.WindowStyle = WindowStyle.None;
           // window.AllowsTransparency = true;
            window.Background = Brushes.Green;
            DoubleAnimation animFadeIn = new DoubleAnimation();
            animFadeIn.From= 0;
            animFadeIn.To = 1;
            animFadeIn.Duration = new Duration(TimeSpan.FromSeconds(2));
            window.BeginAnimation(Window.OpacityProperty, animFadeIn);
            window.ShowDialog();
            //tast.WindowState = WindowState.Maximized;


            //try
            //{


            //    SqlConnection sc = new SqlConnection();
            //    SqlCommand com = new SqlCommand();
            //    sc.ConnectionString = ("Data Source=desktop-jtcs65f ;Initial" +
            //                           " Catalog=K_SystemDB;Integrated Security=True;" +
            //                           "Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;" +
            //                           "ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //    sc.Open();
            //    com.Connection = sc;
            //    //  com.CommandText = ("INSERT INTO TableKS1 (Artikel, Price) VALUES ('" + txtName.Text + "' , '" + txtAddress.Text + "');");
            //     com.CommandText = "delete from TableKS1 where Artikel = '" + this.txtName.Text + "'";
            //    // com.CommandText = "update TableKS1 where Artikel = '" + this.txtName.Text + "'";

            //   // com.CommandText = "UPDATE TableKS1 SET Price = '" + this.txtAddress.Text + "' WHERE Artikel= '" + this.txtName.Text + "'";
            //    com.ExecuteNonQuery();

            //    MessageBox.Show("gelöscht");
            //    sc.Close();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show(" Bitte geben Sie einen gültigen Wert ein");
            //    con.Close();
            //}
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                SqlConnection sc = new SqlConnection();
                SqlCommand com = new SqlCommand();
                sc.ConnectionString = ("Data Source=desktop-jtcs65f ;Initial" +
                                       " Catalog=K_SystemDB;Integrated Security=True;" +
                                       "Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;" +
                                       "ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                sc.Open();
                com.Connection = sc;
                //  com.CommandText = ("INSERT INTO TableKS1 (Artikel, Price) VALUES ('" + txtName.Text + "' , '" + txtAddress.Text + "');");
               // com.CommandText = "delete from TableKS1 where Artikel = '" + this.txtName.Text + "'";
                 com.CommandText = "update TableKS1 where Artikel = '" + this.txtName.Text + "'";

                // com.CommandText = "UPDATE TableKS1 SET Price = '" + this.txtAddress.Text + "' WHERE Artikel= '" + this.txtName.Text + "'";
                com.ExecuteNonQuery();

                MessageBox.Show("aktualisiert");
                sc.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(" Bitte geben Sie einen gültigen Wert ein");
                con.Close();
            }
        }
        DataTable tempDtSpeicher;
        string artikel = "Artikel";
        private void TX_Change(object sender, TextChangedEventArgs e)
        {
            //if (tempDtSpeicher != null)
            //{



            //    DataTable tempDt = tempDtSpeicher.Copy();
            //    // tempDt.Clear();
            //    if (Text_Change.Text != "") // Note: txt_Search is the TextBox..
            //    {
            //        foreach (DataRow dr in tempDtSpeicher.Rows)
            //        {
            //            if (dr[artikel] == Text_Change.Text)
            //            {
            //                tempDt.ImportRow(dr);
            //            }
            //        }
            //        dataGrid.ItemsSource = tempDt.DefaultView.ToString();
            //    }
            //    else
            //    {
            //        dataGrid.ItemsSource = tempDtSpeicher.DefaultView.ToString();
            //    }
            //}

        }
    }

}
