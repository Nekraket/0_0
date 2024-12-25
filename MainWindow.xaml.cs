using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Product
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            _products = new ObservableCollection<Product>()
            {
                new Product { ImagePath = "Фото 1", Name = "Название 1", Description = "Описание 1", Manufacturer = "Производитель 1", Price = 100, StockQuantity = 10},
                new Product { ImagePath = "Фото 2", Name = "Название 2", Description = "Описание 2", Manufacturer = "Производитель 2", Price = 200, StockQuantity = 20},
                new Product { ImagePath = "Фото 3", Name = "Название 3", Description = "Описание 3", Manufacturer = "Производитель 3", Price = 150, StockQuantity = 41},
                new Product { ImagePath = "Фото 4", Name = "Название 4", Description = "Описание 4", Manufacturer = "Производитель 4", Price = 4600, StockQuantity = 23},
                new Product { ImagePath = "Фото 5", Name = "Название 5", Description = "Описание 5", Manufacturer = "Производитель 4", Price = 18, StockQuantity = 624},
                new Product { ImagePath = "Фото 6", Name = "Название 6", Description = "Описание ?", Manufacturer = "Произвопасхалка", Price = 1, StockQuantity = 1}
            };

            Products = new ObservableCollection<Product>(_products);
            LoadManufacturers();
            SortComboBox.SelectedIndex = 0;
        }

        private void LoadManufacturers()
        {
            var manufacturers = _products.Select(p => p.Manufacturer).Distinct().ToList();
            manufacturers.Insert(0, "Все производители");
            FilterComboBox.ItemsSource = manufacturers;
            FilterComboBox.SelectedIndex = 0;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchBox.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                Products.Clear();
                foreach (var product in _products)
                {
                    Products.Add(product);
                }
            }
            else
            {
                var filteredProducts = _products.Where(p =>
                    p.Name.ToLower().Contains(searchText) ||
                    p.Description.ToLower().Contains(searchText)).ToList();

                Products.Clear();
                foreach (var product in filteredProducts)
                {
                    Products.Add(product);
                }
            }
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            var filt_P = _products.AsQueryable();

            if (!string.IsNullOrEmpty(SearchBox.Text))
            {
                var searchText = SearchBox.Text.ToLower();
                filt_P = filt_P.Where(p => p.Name.ToLower().Contains(searchText) || p.Description.ToLower().Contains(searchText));
            }

            if (FilterComboBox.SelectedItem != null && FilterComboBox.SelectedItem.ToString() != "Все производители")
            {
                var selectedManufacturer = FilterComboBox.SelectedItem.ToString();
                filt_P = filt_P.Where(p => p.Manufacturer == selectedManufacturer);
            }

            if (SortComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                var selectedSortOption = selectedItem.Content.ToString();

                if (selectedSortOption == "По возрастанию цены")
                {
                    filt_P = filt_P.OrderBy(n => n.Price);
                }
                else if (selectedSortOption == "По убыванию цены")
                {
                    filt_P = filt_P.OrderByDescending(n => n.Price);
                }
            }

            Products.Clear();
            foreach (var product in filt_P)
            {
                Products.Add(product);
            }

            Products = new ObservableCollection<Product>(filt_P.ToList());

            DataContext = null;
            DataContext = this;
        }
    }
}