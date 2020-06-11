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

        String update_mail_id,
            update_courier_company,
            update_org_name,
            update_org_address,
            update_send_name,
            update_send_address,
            update_send_contact,
            update_stats,
            update_remarks;

        public SelectOrder()
        {
            InitializeComponent();
            selectOrder.ItemsSource = Login.m1.selOrder;
            // selectOrder.Columns[0].IsReadOnly = true;
            // selectOrder.Columns[1].IsReadOnly = true;
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

            // MessageBox.Show(e.Column.Header.ToString());
            temp = e.Row.Item as SelOrder;

            string newItem = e.Column.Header.ToString();

            temp.toValue(e.Column.Header.ToString(), newValue);

            update_mail_id = temp.物流单号;

            update_courier_company = temp.物流公司;

            update_org_name = temp.发件人;

            update_org_address = temp.发货地址;

            update_send_name = temp.收件人;

            update_send_address = temp.收件地址;

            update_send_contact = temp.收件人电话;

            update_stats = temp.状态;

            update_remarks = temp.备注;

            // MessageBox.Show(temp.物流单号);

            if (e.Column.Header.ToString() == "物流单号")
            {
                Login.m1.ShowMessageAsync("请勿更改物流单号", "如需更改，可删除后添加");
                // e.Column = preValue;
                return;
            }

            //如果修改后的值和修改前的值不一样
            if (preValue != newValue)
                try
                {
                    connect.MySqlConnection.Open();
                    connect.ConnectIndex = true;
                    String str_sql = "update fact_mail_status set courier_company = '" + update_courier_company +
                                     "', org_name = '" + update_org_name + "' , org_address = '" + update_org_address +
                                     "' , send_name = '" + update_send_name + "' , send_address = '" +
                                     update_send_address + "', send_contact = '" + update_send_contact +
                                     "', stats = '" + update_stats + "' , remarks = '" + update_remarks +
                                     "' where mail_id = '" + update_mail_id + "'";
                    // MessageBox.Show(update_org_name);
                    // MessageBox.Show(str_sql);
                    Console.WriteLine(str_sql);
                    MySqlCommand mysql_cmd = new MySqlCommand(str_sql, connect.MySqlConnection);
                    int result = mysql_cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        // MessageBox.Show("更新成功");
                    }
                    else
                    {
                        Login.m1.ShowMessageAsync("更新失败","请查看数据库连接");
                    }
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

        public void toDelRow(object sender, RoutedEventArgs e)
        {
            toDelRowAsync();
        }

        private async Task toDelRowAsync()
        {
            SelOrder s1 = selectOrder.SelectedItem as SelOrder;
            if (s1 != null)
            {
                // Login.m1.ShowMessageAsync(s1.物流单号, s1.订单编号);

                MessageDialogResult clickresult = await Login.m1.ShowMessageAsync("订单编号：" + s1.订单编号, "您真的要删除吗?", MessageDialogStyle.AffirmativeAndNegative);
                if (clickresult == MessageDialogResult.Negative)//取消
                {
                    return;
                }
                else//确认
                {
                    try
                    {
                        connect.MySqlConnection.Open();
                        connect.ConnectIndex = true;
                        String str_sql = "delete from fact_mail_status where mail_id = '" + s1.物流单号 + "'";
                        Console.WriteLine(str_sql);
                        MySqlCommand mysql_cmd = new MySqlCommand(str_sql, connect.MySqlConnection);

                        String str_sql_2 = "delete from order_list where mail_id = '" + s1.物流单号 + "'";
                        MySqlCommand mysql_cmd_1 = new MySqlCommand(str_sql_2, connect.MySqlConnection);

                        int result_1 = mysql_cmd.ExecuteNonQuery();
                        int result_2 = mysql_cmd_1.ExecuteNonQuery();

                        if (result_1 > 0 && result_2 > 0)
                        {
                            MessageDialogResult deletefinish = await Login.m1.ShowMessageAsync("删除成功！", "请继续其他操作");
                        }
                        else
                        {
                            MessageDialogResult deleteerror = await Login.m1.ShowMessageAsync("删除失败！", "检查数据库的连接");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        //关闭游标
                        connect.MySqlConnection.Close();
                        Login.m1.ChangeSQl();
                        MainWindow.m1.selectOrder.ItemsSource = Login.m1.selOrder;
                        MainWindow.c1.selectOrder.ItemsSource = Login.m1.selOrder;
                    }

                }
            }

        }

    }
}