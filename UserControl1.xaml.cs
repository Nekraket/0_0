using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Product
{
    public partial class ProductListView : UserControl
    {
        public static readonly DependencyProperty ProductsProperty =
          DependencyProperty.Register("Products", typeof(ObservableCollection<Product>), typeof(ProductListView),
              new PropertyMetadata(new ObservableCollection<Product>()));

        public ObservableCollection<Product> Products
        {
            get { return (ObservableCollection<Product>)GetValue(ProductsProperty); }
            set { SetValue(ProductsProperty, value); }
        }

        public ProductListView()
        {
            InitializeComponent();
        }
    }
}