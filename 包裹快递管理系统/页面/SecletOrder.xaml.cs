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

namespace 包裹快递管理系统
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SecletOrder : UserControl
    {
        public SecletOrder()
        {
            List<SelOrder> selOrder = new List<SelOrder>();
            selOrder.Add(new SelOrder("1", "1", "1", "1", "1", "1", "1", "1", "1", "1"));
            InitializeComponent();
            selectOrder.ItemsSource= selOrder;
        }
    }
}
