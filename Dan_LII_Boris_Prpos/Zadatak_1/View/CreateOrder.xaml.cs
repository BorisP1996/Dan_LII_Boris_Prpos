using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Zadatak_1.ViewModel;

namespace Zadatak_1.View
{
    /// <summary>
    /// Interaction logic for CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : Window
    {
        public CreateOrder(string username)
        {
            InitializeComponent();
            this.DataContext = new CreateOrderViewModel(this,username);
        }
        private void NumbersOnlyTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void TbSmall_TextChanged(object sender, TextChangedEventArgs e)
        {
        //  if (!string.IsNullOrEmpty(tbSmall.Text) && !string.IsNullOrEmpty(tbMedium.Text) && !string.IsNullOrEmpty(tbBig.Text) && !string.IsNullOrEmpty(tbFamily.Text) && !string.IsNullOrEmpty(tbSpecial.Text) && !string.IsNullOrEmpty(tbNew.Text))
        //       tbTotal.Text = (Convert.ToInt32(tbSmall.Text) * (1000+(0.2*1000)) + Convert.ToInt32(tbMedium.Text) * (2000+(0.2)*2000) + Convert.ToInt32(tbBig.Text) * (1200+(0.2*1200)) + Convert.ToInt32(tbSpecial.Text) * (2500+(0.2*2500)) + Convert.ToInt32(tbFamily.Text) * (800+(800*0.2)) + Convert.ToInt32(tbNew.Text) * (1100+(1100*0.2))).ToString();
        }

        private void TbMedium_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(tbSmall.Text) && !string.IsNullOrEmpty(tbMedium.Text) && !string.IsNullOrEmpty(tbBig.Text) && !string.IsNullOrEmpty(tbFamily.Text) && !string.IsNullOrEmpty(tbSpecial.Text) && !string.IsNullOrEmpty(tbNew.Text))
            //    tbTotal.Text = (Convert.ToInt32(tbSmall.Text) * (1000 + (0.2 * 1000)) + Convert.ToInt32(tbMedium.Text) * (2000 + (0.2) * 2000) + Convert.ToInt32(tbBig.Text) * (1200 + (0.2 * 1200)) + Convert.ToInt32(tbSpecial.Text) * (2500 + (0.2 * 2500)) + Convert.ToInt32(tbFamily.Text) * (800 + (800 * 0.2)) + Convert.ToInt32(tbNew.Text) * (1100 + (1100 * 0.2))).ToString();
        }

        private void TbBig_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(tbSmall.Text) && !string.IsNullOrEmpty(tbMedium.Text) && !string.IsNullOrEmpty(tbBig.Text) && !string.IsNullOrEmpty(tbFamily.Text) && !string.IsNullOrEmpty(tbSpecial.Text) && !string.IsNullOrEmpty(tbNew.Text))
            //    tbTotal.Text = (Convert.ToInt32(tbSmall.Text) * (1000 + (0.2 * 1000)) + Convert.ToInt32(tbMedium.Text) * (2000 + (0.2) * 2000) + Convert.ToInt32(tbBig.Text) * (1200 + (0.2 * 1200)) + Convert.ToInt32(tbSpecial.Text) * (2500 + (0.2 * 2500)) + Convert.ToInt32(tbFamily.Text) * (800 + (800 * 0.2)) + Convert.ToInt32(tbNew.Text) * (1100 + (1100 * 0.2))).ToString();
        }

        private void TbFamily_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(tbSmall.Text) && !string.IsNullOrEmpty(tbMedium.Text) && !string.IsNullOrEmpty(tbBig.Text) && !string.IsNullOrEmpty(tbFamily.Text) && !string.IsNullOrEmpty(tbSpecial.Text) && !string.IsNullOrEmpty(tbNew.Text))
            //    tbTotal.Text = (Convert.ToInt32(tbSmall.Text) * (1000 + (0.2 * 1000)) + Convert.ToInt32(tbMedium.Text) * (2000 + (0.2) * 2000) + Convert.ToInt32(tbBig.Text) * (1200 + (0.2 * 1200)) + Convert.ToInt32(tbSpecial.Text) * (2500 + (0.2 * 2500)) + Convert.ToInt32(tbFamily.Text) * (800 + (800 * 0.2)) + Convert.ToInt32(tbNew.Text) * (1100 + (1100 * 0.2))).ToString();
        }

        private void TbSpecial_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(tbSmall.Text) && !string.IsNullOrEmpty(tbMedium.Text) && !string.IsNullOrEmpty(tbBig.Text) && !string.IsNullOrEmpty(tbFamily.Text) && !string.IsNullOrEmpty(tbSpecial.Text) && !string.IsNullOrEmpty(tbNew.Text))
            //    tbTotal.Text = (Convert.ToInt32(tbSmall.Text) * (1000 + (0.2 * 1000)) + Convert.ToInt32(tbMedium.Text) * (2000 + (0.2) * 2000) + Convert.ToInt32(tbBig.Text) * (1200 + (0.2 * 1200)) + Convert.ToInt32(tbSpecial.Text) * (2500 + (0.2 * 2500)) + Convert.ToInt32(tbFamily.Text) * (800 + (800 * 0.2)) + Convert.ToInt32(tbNew.Text) * (1100 + (1100 * 0.2))).ToString();
        }
        private void TbNew_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(tbSmall.Text) && !string.IsNullOrEmpty(tbMedium.Text) && !string.IsNullOrEmpty(tbBig.Text) && !string.IsNullOrEmpty(tbFamily.Text) && !string.IsNullOrEmpty(tbSpecial.Text) && !string.IsNullOrEmpty(tbNew.Text))
            //    tbTotal.Text = (Convert.ToInt32(tbSmall.Text) * (1000 + (0.2 * 1000)) + Convert.ToInt32(tbMedium.Text) * (2000 + (0.2) * 2000) + Convert.ToInt32(tbBig.Text) * (1200 + (0.2 * 1200)) + Convert.ToInt32(tbSpecial.Text) * (2500 + (0.2 * 2500)) + Convert.ToInt32(tbFamily.Text) * (800 + (800 * 0.2)) + Convert.ToInt32(tbNew.Text) * (1100 + (1100 * 0.2))).ToString();
        }
    }
}
