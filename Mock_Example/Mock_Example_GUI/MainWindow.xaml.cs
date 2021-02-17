using MoqExampleBackEnd;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Mock_Example_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICatalogItemManager _cim;
        private ISaleCreator _saleCreator;
        private string _selectedItem;
        public MainWindow()
        {
            InitializeComponent();
            PopulateCurrencyList();
            PopulateQuantityList();
        }

        private void PopulateQuantityList()
        {
            var quantities = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Quantity_Combo.ItemsSource = quantities;
        }

        private void PopulateCurrencyList()
        {
            var currencies = new List<string> { "GBP", "CAD", "USD", "EUR" };
            Currency_Combo.ItemsSource = currencies;
        }

        private void Catalog_Search_TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            _selectedItem = _cim.Find(Catalog_Search_TextBox.Text);
            Product_Text_Block.Text = _selectedItem;
        }

        private void Btn_Buy_Click(object sender, RoutedEventArgs e)
        {
            string currency = Currency_Combo.SelectedItem.ToString();
            int quantity = Int32.Parse(Quantity_Combo.SelectedItem.ToString());
            string sale = _saleCreator.CalculateTotal(_selectedItem, currency, quantity);
            Sale_TextBlock.Text = sale;
        }
    }
}
