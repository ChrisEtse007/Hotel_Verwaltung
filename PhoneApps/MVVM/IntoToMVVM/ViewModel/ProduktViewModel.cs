using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntoToMVVM.Model;

namespace IntoToMVVM.ViewModel
{
    class ProduktViewModel : INotifyPropertyChanged
    {
        ProduktModel _Prdukt_AUS_modelClass;

        string _atklName;
        string _atkelPrice;
        public string ArtklNameTOtxbox
        {
            get { return _atklName; }
            set {
                if (_atklName != value)
                {
                    _atklName = value;
                    OnpropertyChanged("ArtklNameTOtxbox");
                }
            }
        }

        public string AtkelPriceTOtxbox
        {
            get { return _atkelPrice; }
            set
            {
                if (_atkelPrice != value)
                {
                    _atkelPrice = value;
                    OnpropertyChanged("AtkelPriceTOtxbox");
                }
            }
        }

        public ProduktViewModel(ProduktModel Prdukt_AUS_modelClass)
        {
            _Prdukt_AUS_modelClass = Prdukt_AUS_modelClass;

            _atklName = Prdukt_AUS_modelClass.Artkel_name;
            _atkelPrice = Prdukt_AUS_modelClass.Artkel_price;
        }

        public ProduktViewModel() : this(ProduktModel.Einfügen())
        {
           
        }

        //public string Test(string test)
        //{
        //    test = "haloooo";
        //    OnpropertyChanged("Test");
        //    return test;
        //}



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
