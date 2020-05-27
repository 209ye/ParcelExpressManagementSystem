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

namespace 包裹快递管理系统
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SecletOrder : UserControl
    {
        MySQLConnect connect = new MySQLConnect();

        public SecletOrder()
        {
            List<SelOrder> selOrder = new List<SelOrder>();
            //DataTable dt = new DataTable();

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
            InitializeComponent();
            //selectOrder.ItemsSource = dt.DefaultView;
            selectOrder.ItemsSource = selOrder;
        }
    }
}

