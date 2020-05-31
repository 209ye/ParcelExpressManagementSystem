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
using MahApps.Metro.Controls;
using MySql.Data.MySqlClient;
using Renci.SshNet.Messages;

namespace 包裹快递管理系统
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CheckLogistics : UserControl
    {

        public CheckLogistics()
        {
            InitializeComponent();
            //selectOrder.ItemsSource = dt.DefaultView;
            selectOrder.ItemsSource = MainWindow.selOrder;
        }

        private void SO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(selectOrder.SelectedItem.ToString());
        }
    }
}

