using System.Collections.ObjectModel;
using System.Windows;

namespace Product
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this; 
            Products = new ObservableCollection<Product>()
            {
                new Product { ImagePath = "Фото 1", Name = "Название  1", Description = "Описание 1", Manufacturer = "Производитель 1", Price = 100, StockQuantity = 10},
                new Product { ImagePath = "Фото 2", Name = "Название  2", Description = "Описание 2", Manufacturer = "Производитель 2", Price = 100, StockQuantity = 20},
                new Product { ImagePath = "Фото 3", Name = "Название  3", Description = "Описание 3", Manufacturer = "Производитель 3", Price = 100, StockQuantity = 41},
                new Product { ImagePath = "Фото 4", Name = "Название  4", Description = "Описание 4", Manufacturer = "Производитель 4", Price = 100, StockQuantity = 23},
                new Product { ImagePath = "Фото 5", Name = "Название  5", Description = "Описание 5", Manufacturer = "Производитель 5", Price = 100, StockQuantity = 624},
                new Product { ImagePath = "Фото 6", Name = "Название  6", Description = "Описание ?", Manufacturer = "Произвопасхалка", Price = 100, StockQuantity = 1}
            };
        }
    }
}