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
    public partial class SelectOrder : UserControl
    {
        MySQLConnect connect = new MySQLConnect();
        SelOrder temp;
        String update_mail_id, update_courier_company , update_org_name , 
            update_org_address , update_send_name , update_send_address , 
            update_send_contact , update_stats , update_remarks;

        public SelectOrder()
        {
            
            InitializeComponent();
            selectOrder.ItemsSource = MainWindow.selOrder;
            
        }

        

        private void SO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            temp = selectOrder.SelectedItem as SelOrder;

             update_mail_id = temp.订单编号;

             update_courier_company = temp.物流公司;

             update_org_name = temp.发件人;

             update_org_address = temp.发货地址;

             update_send_name = temp.收件人;

             update_send_address = temp.收件地址;

             update_send_contact = temp.收件人电话;

             update_stats = temp.状态;

             update_remarks = temp.备注;
           
        }


        string preValue = "";
        private void dataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            //将修改前的值保存起来
            preValue = (e.Column.GetCellContent(e.Row) as TextBlock).Text;
        }



        //失去焦点之后调用这个函数进行更新
        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string newValue = (e.EditingElement as TextBox).Text;
            //如果修改后的值和修改前的值不一样
            if (preValue != newValue)
                try
                {
                    connect.MySqlConnection.Open();
                    connect.ConnectIndex = true;
                    String str_sql = "update fact_mail_status set courier_company = 'update_courier_company' , org_name = 'update_org_name' , org_address = 'update_org_address' , send_name = 'update_send_name' , send_address = 'update_send_address' , send_contact = 'update_send_contact' , stats = 'update_stats' , remarks = 'update_remarks' where mail_id = 'update_mail_id'";
                    Console.WriteLine(str_sql);
                    MySqlCommand mysql_cmd = new MySqlCommand(str_sql, connect.MySqlConnection);
                    mysql_cmd.ExecuteNonQuery();
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


