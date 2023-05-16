using System;
using System.Collections.Generic;
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
using YL1CC3_HFT_2022231.WpfClient.Pages;

namespace YL1CC3_HFT_2022231.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Cars_Click(object sender, RoutedEventArgs e)
        {
            CarPage cp = new CarPage();
            cp.ShowDialog();
        }

        private void Brands_Click(object sender, RoutedEventArgs e)
        {
            BrandPage bp = new BrandPage();
            bp.ShowDialog();
        }
        
        private void Rents_Click(object sender, RoutedEventArgs e)
        {
            RentPage rp = new RentPage();
            rp.ShowDialog();
        }
        private void _1_Click(object sender, RoutedEventArgs e)
        {
            PriceOfBrands win = new PriceOfBrands();
            win.ShowDialog();
        }
        private void _2_Click(object sender, RoutedEventArgs e)
        {
            RentBrandFrequency win = new RentBrandFrequency();
            win.ShowDialog();
        }
        private void _3_Click(object sender, RoutedEventArgs e)
        {
            AvgPriceOfBrands win = new AvgPriceOfBrands();
            win.ShowDialog();
        }
        private void _4_Click(object sender, RoutedEventArgs e)
        {
            RentFrequency win = new RentFrequency();
            win.ShowDialog();
        }
        private void _5_Click(object sender, RoutedEventArgs e)
        {
            Renting win = new Renting();
            win.ShowDialog();
        }
        private void _6_Click(object sender, RoutedEventArgs e)
        {
            ParametricBrand win = new ParametricBrand();
            win.ShowDialog();
        }
    }
}
