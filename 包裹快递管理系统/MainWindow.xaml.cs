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
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Border_Title2.MouseDown += new MouseButtonEventHandler(Border_Title_MouseDown);

            //窗口全屏
            // Loaded += OnLoaded;

            //窗口全屏且透明
            // AllowsTransparency = true;
            // WindowStyle = WindowStyle.None;
            // WindowState = WindowState.Maximized;
            // Background = Brushes.Transparent;
            // Topmost = true;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            WindowState = WindowState.Maximized;
            ResizeMode = ResizeMode.NoResize;
            ShowMaxRestoreButton = false;
            ShowMinButton = false;
            Loaded -= OnLoaded;
        }

        void Border_Title_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Main1Page(object sender, RoutedEventArgs e)
        {
            Main1 m1 = new Main1();
            AddTab(m1, A_main1.Text);
            
        }

        private Dictionary<string, string> _mdiChildren = new Dictionary<string, string>();

        private void AddTab(UserControl mdiChild, string btnConter)
        {
            //判断当前用户控件是否已经打开
            if (_mdiChildren.ContainsKey(btnConter))
            {
                foreach (object item in tcMdi.Items)
                {
                    //如果用户控件已经被打开就删除原来的，从新追加新的
                    TabItem ti = (TabItem)item;
                    if (ti.Name == btnConter)
                    {
                        ti.Focus();
                        break;
                    }
                }
            }
            else
            {
                TabItem ti = new TabItem();
                ti.Name = btnConter;
                ti.Header = btnConter;
                ti.Content = mdiChild;
                ti.HorizontalAlignment = HorizontalAlignment.Left;
                ti.VerticalAlignment = VerticalAlignment.Top;
                tcMdi.Items.Add(ti);
                // 设置tcMdi被选中的项为TabItem类的对象ti
                tcMdi.SelectedItem = ti;
                //将被打开的用户控件的UniqueTabName添加到已打开的标签页的UniqueTabName列表中
                _mdiChildren.Add(btnConter, btnConter);
            }
        }

        private void btnCloseTab_Click(object sender, RoutedEventArgs e)
        {

            foreach (TabItem item in tcMdi.Items)
            {
                if (this.IsMouseOver == item.IsMouseOver)
                {
                    _mdiChildren.Remove(item.Header.ToString().Trim());
                    tcMdi.Items.Remove(item);
                    break;
                }
            }
        }

        private void toLoginWin(object sender, RoutedEventArgs e)
        {
            Login l1 = new Login();
            l1.Show();
            this.Close();
        }

        private void toSelectOrderWin(object sender, RoutedEventArgs e)
        {
            SecletOrder m1 = new SecletOrder();
            AddTab(m1, A_SecletOrder.Text);
        }

        private void toPersonalCenterWin(object sender, RoutedEventArgs e)
        {
            PersonalCenter m1 = new PersonalCenter();
            AddTab(m1, A_PersonalCenter.Text);
        }
    }
}
