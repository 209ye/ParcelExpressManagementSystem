using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using MahApps.Metro.Controls.Dialogs;
using MySql.Data.MySqlClient;

namespace 包裹快递管理系统
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public List<SelOrder> selOrder;

        public MainWindow()
        {
            InitializeComponent();
            this.Border_Title2.MouseLeftButtonDown += new MouseButtonEventHandler(Border_Title_MouseDown);
            UP_User.Text = "欢迎您, " + Login.input_user;
            //窗口全屏
            // Loaded += OnLoaded;

            //窗口全屏且透明
            // AllowsTransparency = true;
            // WindowStyle = WindowStyle.None;
            // WindowState = WindowState.Maximized;
            // Background = Brushes.Transparent;
            // Topmost = true;

            //数据库连接
            ChangeSQl();

        }

        // private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        // {
        //     WindowState = WindowState.Maximized;
        //     ResizeMode = ResizeMode.NoResize;
        //     ShowMaxRestoreButton = false;
        //     ShowMinButton = false;
        //     Loaded -= OnLoaded;
        // }

        void Border_Title_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public void ChangeSQl()
        {
            selOrder = new List<SelOrder>();
            //DataTable dt = new DataTable();
            MySQLConnect connect = new MySQLConnect();
            try
            {
                //DataTable的实现方式，会把顶部的表头覆盖掉
                //MySqlDataAdapter da = new MySqlDataAdapter(str_sql, connect.MySqlConnection);

                //da.Fill(dt);

                connect.MySqlConnection.Open();
                connect.ConnectIndex = true;
                //查询语句
                /*                String str_sql = "select mail_id , courier_company , org_name , org_address , " +
                                                 "send_name ,  send_address , send_contact , stats , remarks" +
                                                 "from fact_mail_status";*/
                String str_sql = "select order_id, order_list.mail_id ,courier_company , org_name , org_address, send_name ,  send_address , send_contact,stats ,remarks from fact_mail_status inner join order_list on fact_mail_status.mail_id = order_list.mail_id";
                MySqlCommand mysql_cmd = new MySqlCommand(str_sql, connect.MySqlConnection);
                MySqlDataReader reader = mysql_cmd.ExecuteReader();
                while (reader.Read())
                {
                    String order_id = reader["order_id"].ToString();
                    String mail_id = reader["mail_id"].ToString();
                    String courier_company = reader["courier_company"].ToString();
                    String org_name = reader["org_name"].ToString();
                    String org_address = reader["org_address"].ToString();
                    String send_name = reader["send_name"].ToString();
                    String send_address = reader["send_address"].ToString();
                    String send_contact = reader["send_contact"].ToString();
                    String stats = reader["stats"].ToString();
                    String remarks = reader["remarks"].ToString();
                    /*  selOrder.Add(new SelOrder("1", mail_id, courier_company, org_name, org_address,
                          send_name, send_address, send_contact, stats, remarks));*/
                    selOrder.Add(new SelOrder(order_id, mail_id, courier_company, org_name, org_address,
                        send_name, send_address, send_contact, stats, remarks));
                }
                reader.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //关闭游标
                connect.MySqlConnection.Close();
            }

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

        public static SelectOrder m1;
        private void toSelectOrderWin(object sender, RoutedEventArgs e)
        {
            m1 = new SelectOrder();
            AddTab(m1, A_SecletOrder.Text);
        }

        private void toPersonalCenterWin(object sender, RoutedEventArgs e)
        {
            PersonalCenter m1s = new PersonalCenter();
            AddTab(m1s, A_PersonalCenter.Text);
        }

        private void toAddOrder(object sender, RoutedEventArgs e)
        {
            AddOrder c1s = new AddOrder();
            AddTab(c1s, A_AddOrder.Text);
        }

        public static CheckLogistics c1;
        private void toCheckLogistics(object sender, RoutedEventArgs e)
        {
            c1 = new CheckLogistics();
            AddTab(c1, A_CheckLogistics.Text);
        }

    }
}
