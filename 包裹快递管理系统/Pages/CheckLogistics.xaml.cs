using System.Windows;
using System.Windows.Controls;


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
            selectOrder.ItemsSource = Login.m1.selOrder;
        }

        private void SO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelOrder s1 = selectOrder.SelectedItem as SelOrder;
            // MessageBox.Show(s1.物流单号);
            System.Diagnostics.Process.Start(@"https://www.kuaidi100.com/chaxun?com="+s1.物流公司+@"&nu="+s1.物流单号);
        }
    }
}

