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
using LiveCharts;
using MahApps.Metro.Controls;
using MySql.Data.MySqlClient;

namespace 包裹快递管理系统
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class Main1 : UserControl
    {
        MySQLConnect connect = new MySQLConnect();
        public Main1()
        {
            InitializeComponent();
            try
            {
                connect.MySqlConnection.Open();
                connect.ConnectIndex = true;

                //使用查询语句统计记录的总数并返回显示于界面
                String str_sql_countorder = "select count(*) from `fact_mail_status`";
                MySqlCommand mysql_cmd_a = new MySqlCommand(str_sql_countorder, connect.MySqlConnection);
                String a = mysql_cmd_a.ExecuteScalar().ToString();
                total_order.Text = a;

                //使用查询语句统计订单状态为“派送中”的记录数
                String str_sql_countsending = "SELECT COUNT(*) FROM fact_mail_status where stats = \"派送中\"";
                MySqlCommand mysql_cmd_b = new MySqlCommand(str_sql_countsending, connect.MySqlConnection);
                String b = mysql_cmd_b.ExecuteScalar().ToString();
                total_sending.Text = b;

                //使用查询语句统计订单状态为“已签收”的记录数
                String str_sql_receiving = "SELECT COUNT(*) FROM fact_mail_status where stats = \"已签收\"";
                MySqlCommand mysql_cmd_c = new MySqlCommand(str_sql_receiving, connect.MySqlConnection);
                String c = mysql_cmd_c.ExecuteScalar().ToString();
                total_receiving.Text = c;

                //使用查询语句统计订单状态为“退货件”的记录数
                String str_sql_back = "SELECT COUNT(*) FROM fact_mail_status where stats = \"退货件\"";
                MySqlCommand mysql_cmd_d = new MySqlCommand(str_sql_back, connect.MySqlConnection);
                String d = mysql_cmd_d.ExecuteScalar().ToString();
                total_back.Text = d;

                //使用查询语句获取2019年每个月的销售额

                sales_performance.Values = new ChartValues<decimal> { 5, 6, 2, 7, 8, 9, 10, 11, 10 };



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
    }
}
