using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntoToMVVM.Model
{
    public class ProduktModel : INotifyPropertyChanged
    {

        private string artkel_name;

        public string Artkel_name
        {
            get { return artkel_name; }
            set {
                if (artkel_name != value)
                {
                    artkel_name = value;
                    OnpropertyChanged("Artkel_name");
                }
                 }
        }

        private string artkel_price;

        public string Artkel_price
        {
            get { return artkel_price; }
            set
            {
                if (artkel_price != value)
                {
                    artkel_price = value;
                    OnpropertyChanged("Artkel_price");
                }

                }
        }

        public static ProduktModel Einfügen()
        {
            ProduktModel produkt_1 = new ProduktModel()
            {
                artkel_name = "OSaft",
                artkel_price = "2,10"
              };
               return produkt_1;
        }


      



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnpropertyChanged(string Property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }

        }
   

    }
}
