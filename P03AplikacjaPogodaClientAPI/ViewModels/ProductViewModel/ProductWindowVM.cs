using P03AplikacjaPogodaClientAPI.Tools;
using P03AplikacjaPogodaClientAPI.ViewModels.Commands;
using P05Sklep.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03AplikacjaPogodaClientAPI.ViewModels.ProductViewModel
{
    public class ProductWindowVM : ViewModelBase
    {
        ProductsApiTool tool;
        private bool speaking = false;
        public bool Speaking { get => speaking;
            set 
            { 
                speaking = value;
                OnPropertyChange();
            } }
        public ObservableCollection<ProductVM> Products { get; set; }
        private ProductVM selectedProduct = new ProductVM();
        public DelegateCommand EditCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand CreateCommand { get; set; }
        public DelegateCommand SpeakCommand { get; set; }
        

        public ProductVM SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChange();
            }
        }

        public ProductWindowVM()
        {
            Products = new ObservableCollection<ProductVM>();
            tool = new ProductsApiTool();
            GetProducts();
            EditCommand = new DelegateCommand(EditProduct, null);
            DeleteCommand = new DelegateCommand(DeleteProduct, null);
            CreateCommand = new DelegateCommand(CreateProduct, null);
            SpeakCommand = new DelegateCommand(SpeakProductDescription, null);
        }

        private async void SpeakProductDescription()
        {
            Speaking = true;
            SpeechSerivceTool sst = new SpeechSerivceTool();
            string recognizeText = await sst.RecognizeAsync();

            selectedProduct.Description = recognizeText;
            OnPropertyChange("selectedProduct");
            Speaking = false;
        }

        public async void CreateProduct()
        {
            var productToCreate = new Product()
            {
                Color = selectedProduct.Color,
                Description = selectedProduct.Description,
                Title = selectedProduct.Title,
                ImageUrl = selectedProduct.Url
            };

            await tool.CreateProduct(productToCreate);
            GetProducts();
        }

        public async void DeleteProduct()
        {           
            await tool.DeleteProduct(selectedProduct.Id);
            GetProducts();
        }

        public async void EditProduct()
        {
            ProductsApiTool productsApiTool = new ProductsApiTool();

            var productToUpdate = new Product()
            {
                Id = selectedProduct.Id,
                Color = selectedProduct.Color,
                Description = selectedProduct.Description,
                Title = selectedProduct.Title,
                ImageUrl = selectedProduct.Url
            };

            await productsApiTool.UpdateProduct(productToUpdate);

            GetProducts();
        }

        public async void GetProducts()
        {
            var products = await tool.GetProducts();

            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(new ProductVM(product));
            }
        }
    }
}
