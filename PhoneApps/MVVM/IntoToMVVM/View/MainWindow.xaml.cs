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
using IntoToMVVM.Model;
using IntoToMVVM.ViewModel;



namespace IntoToMVVM { 
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        ProduktViewModel ViewModel = new ProduktViewModel();
        private ObservableCollection<ProduktModel> Produkten_Objekt_Observable;
        public MainWindow()
        {
            InitializeComponent();
          
            Produkten_Objekt_Observable = new ObservableCollection<ProduktModel>() { };
            // Show ohne Button Klick oder ruf konstruktor der klasse als DataContext ab
            this.DataContext = new ProduktViewModel();

            // Show mit Button Klick.. ViewModel new obj in der klasse oben deklariert
            this.DataContext = ViewModel;
        }



        public void ObservableCollection__Metohde()
        {
            Produkten_Objekt_Observable.Add(new ProduktModel() { Artkel_name = TxbName.Text, Artkel_price = TxbPrice.Text });

            dataGrid2.ItemsSource = Produkten_Objekt_Observable;
           

            //TxbName.Text = string.Empty;
            //TxbPrice.Text = string.Empty;
        }




        private void Btn_Change(object sender, RoutedEventArgs e)
        {
            //  ------- INotify Test
            // ViewModel.ArtklNameTOtxbox = "new Name";

            ObservableCollection__Metohde();

           // ViewModel.Test(texbTest.Text);
            
        }

   
    }
}
