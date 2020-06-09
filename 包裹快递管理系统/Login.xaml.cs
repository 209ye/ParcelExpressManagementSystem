using System;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MySql.Data.MySqlClient;

namespace 包裹快递管理系统
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class Login : MetroWindow
    {
        //用以接收文本框的用户名和密码
        public static String input_user;
        public static String input_pwd;
        //实例化连接游标
        MySQLConnect connect = new MySQLConnect();
        public static MainWindow m1;
        //引入计数器记录用户个数
        public int counter;

        public Login()
        {
            InitializeComponent();
            this.Border_Title.MouseLeftButtonDown += new MouseButtonEventHandler(Border_Title_MouseDown);
        }

        void Border_Title_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void toMainWin(object sender, RoutedEventArgs e)
        {
            //将输入的账户和密码存储到字符串里面进行匹配
            input_user = User.Text;
            input_pwd = Password.Password;
            try
            {
                connect.MySqlConnection.Open();
                connect.ConnectIndex = true;
                //使用查询语句从用户表中获取用户信息
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
                        m1 = new MainWindow();
                        m1.Show();
                        this.Close();
                    }
                }

                if (!login_index)
                {
                    this.ShowMessageAsync("登录失败！", "请核对你的用户名与密码");
                    //this.ShowMessageAsync("登录失败！", a);
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

        }

        private void ToRegister(object sender, RoutedEventArgs e)
        {
            //将输入的账户和密码存储到字符串里面进行匹配
            input_user = User.Text;
            String input_pwd = Password.Password;
            int num;
            try
            {
                connect.MySqlConnection.Open();
                connect.ConnectIndex = true;
                if (input_user.Length > 0 && input_pwd.Length > 0)
                {
                    //使用查询语句统计记录的总数并返回显示于界面
                    String str_sql_countorder = "select count(*) from `user_info`";
                    MySqlCommand mysql_cmd_a = new MySqlCommand(str_sql_countorder, connect.MySqlConnection);
                    String a = mysql_cmd_a.ExecuteScalar().ToString();
                    counter = int.Parse(a);
                    num = counter + 1;

                    //先使用查询语句查询数据库里面是否已经存在
                    String str_sql = "select user_id ,user_name, user_pwd from user_info";
                    MySqlCommand mysql_cmd = new MySqlCommand(str_sql, connect.MySqlConnection);
                    MySqlDataReader reader = mysql_cmd.ExecuteReader();
                    bool user_exit = false;

                    while (reader.Read())
                    {
                        //每次读一条记录进行匹配
                        if (reader["user_name"].ToString().Equals(input_user))
                        {
                            this.ShowMessageAsync("注册失败！", "账户名已存在");
                            user_exit = true;
                        }
                    }
                    reader.Close();
                    if (user_exit == false)
                    {
                        //两种实现的语句
                        String add_sql = "insert into user_info(user_id , user_name , user_pwd) values (" +
                            num + ",'" + input_user + "','" + input_pwd + "')";
                        String InsertSqlCommand = string.Format("insert into user_info(user_id , user_name , user_pwd) values({0},'{1}','{2}')", num, input_user, input_pwd);
                        MySqlCommand mysql_cmd_1 = new MySqlCommand(InsertSqlCommand, connect.MySqlConnection);
                        int result_1 = mysql_cmd_1.ExecuteNonQuery();
                        if (result_1 > 0)
                        {
                            this.ShowMessageAsync("注册成功！", "请使用注册的用户名与密码登录系统");
                        }
                        else
                        {
                            this.ShowMessageAsync("注册失败！", "检查数据库链接");
                        }
                        //清空内容要求用户再次输入信息，保证安全性
                        User.Text = "";
                        Password.Password = "";
                    }
                }
                else
                {
                    this.ShowMessageAsync("注册失败！", "请输入用户名和密码");
                }


            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                //MessageBox.Show(ex.Message);
                if (connect.ConnectIndex == false)
                {
                    this.ShowMessageAsync("Error Stats", "链接数据库失败");
                }
            }
            finally
            {
                //关闭游标保证连接安全性
                connect.MySqlConnection.Close();
            }
        }
    }
}
