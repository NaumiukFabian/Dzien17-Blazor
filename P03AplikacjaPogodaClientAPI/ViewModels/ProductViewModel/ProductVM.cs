using P05Sklep.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03AplikacjaPogodaClientAPI.ViewModels.ProductViewModel
{
    public class ProductVM
    {
        private Product _product;
        public ProductVM(Product product)
        {
            _product = product;
        }

        public ProductVM()
        {
            _product = new Product();
        }

        //public int Id => _product.Id;
        //public string Title => _product.Title;
        //public string Description => _product.Description;
        //public string Color => _product.Color;
        //public string Url => _product.ImgUrl;

        public int Id
        {
            get { return _product.Id; }
            set { _product.Id = value; }
        }
        public string Title
        {
            get { return _product.Title; }
            set { _product.Title = value; }
        }
        public string Description
        {
            get { return _product.Description; }
            set { _product.Description = value; }
        }
        public string Color
        {
            get { return _product.Color; }
            set { _product.Color = value; }
        }
        public string Url
        {
            get { return _product.ImageUrl; }
            set { _product.ImageUrl = value; }
        }

        // gdy wiązanie z kontrolką jest typu TwoWay to musimy dodać we właściwości SET
        // gdy jest OneWay to wystarczy tylko GET ale dla nas nie jest to przydatne ponieważ
        // potrzebujemy mieć możliwość odczytania zmienionej kontrolki

    }
}
