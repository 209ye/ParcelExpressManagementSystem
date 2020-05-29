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
using MahApps.Metro.Controls.Dialogs;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace 包裹快递管理系统
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class Login : MetroWindow
    {
        public static String input_user;
        MySQLConnect connect = new MySQLConnect();

        public Login()
        {
            InitializeComponent();
            this.Border_Title.MouseDown += new MouseButtonEventHandler(Border_Title_MouseDown);
        }

        void Border_Title_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void toMainWin(object sender, RoutedEventArgs e)
        {
            //将输入的账户和密码存储到字符串里面进行匹配
            input_user = User.Text;
            String input_pwd = Password.Password;
            try
            {
                connect.MySqlConnection.Open();
                connect.ConnectIndex = true;
                //查询语句
                String str_sql = "select user_id ,user_name, user_pwd from user_info";
                MySqlCommand mysql_cmd = new MySqlCommand(str_sql, connect.MySqlConnection);
                MySqlDataReader reader = mysql_cmd.ExecuteReader();
                bool login_index = false;
                while (reader.Read())
                {
                    //每次读一条记录进行匹配
                    if (reader["user_name"].ToString().Equals(input_user)
                        && reader["user_pwd"].ToString().Equals(input_pwd))
                    {
                        //这个页面跳转可能会出错
                        login_index = true;
                        MainWindow m1 = new MainWindow();
                        m1.Show();
                        this.Close();
                    }
                }
                if (!login_index)
                {
                    this.ShowMessageAsync("登录失败！", "请核对你的用户名与密码");
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                if (!connect.ConnectIndex)
                {
                    this.ShowMessageAsync("Error Stats", "链接数据库失败");
                }
            }
            finally
            {
                //关闭游标
                connect.MySqlConnection.Close();
            }





            /* if (User.Text=="admin"&&Password.Password=="admin")
             {
                 MainWindow m1 = new MainWindow();
                 m1.Show();
                 this.Close();
             }
             else
             {
                 this.ShowMessageAsync("登录失败！", "请核对你的用户名与密码");
             }
             */

        }
    }
}
