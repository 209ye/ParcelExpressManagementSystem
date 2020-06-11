using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;
using MySql.Data.MySqlClient;
using 包裹快递管理系统.Pages;

namespace 包裹快递管理系统
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddOrder : UserControl
    {
        MySQLConnect connect = new MySQLConnect();

        public AddOrder()
        {
            InitializeComponent();
            List<LComs> list = new List<LComs>();
            list.Add(new LComs("申通快递"));
            list.Add(new LComs("顺丰快递"));
            list.Add(new LComs("圆通快递"));
            list.Add(new LComs("中通快递"));
            list.Add(new LComs("韵达快递"));
            list.Add(new LComs("EMS快递"));
            list.Add(new LComs("百世快递"));
            list.Add(new LComs("邮政快递"));
            list.Add(new LComs("天天快递"));
            list.Add(new LComs("苏宁快递"));
            list.Add(new LComs("申通快递"));
            Lcom.ItemsSource = list;
        }

        private void Addconfirm(object sender, RoutedEventArgs e)
        {
            //新的包裹订单号
            String add_order_id = "";
            int[] ordernum = new int[19];
            Random random = new Random();
            for (int i = 0; i < ordernum.Length; i++)
            {
                ordernum[i] = random.Next(0, 9);
                add_order_id += ordernum[i].ToString();
            }
            //MessageBox.Show(add_order_id);

            //新的包裹运单号
            String add_mail_id = input_mail_id.Text;

            //下拉框选择快递公司
            String add_courier_company = Lcom.Text;

            //寄件人姓名
            String add_org_name = input_org_name.Text;

            //寄件人地址
            String add_org_address = input_org_address.Text;

            //发货时间根据时间戳获得
            String add_send_date = System.DateTime.Now.ToString();
            //MessageBox.Show(add_send_date);
            //收件人姓名
            String add_send_name = input_send_name.Text;
            //MessageBox.Show(add_send_name);

            //收件人地址
            String add_send_address = input_send_address.Text;

            //收件人联系方式
            String add_send_contact = input_send_contact.Text;

            //货物状态
            String add_stats = input_status.Text;

            //货物备注
            String add_remarks = input_remarks.Text;

            try
            {
                connect.MySqlConnection.Open();
                connect.ConnectIndex = true;
                if (add_mail_id.Length <= 0 || add_courier_company.Length <= 0 || add_org_name.Length <= 0
                    || add_org_address.Length <= 0 || add_send_name.Length <= 0 || add_send_address.Length <= 0
                    || add_send_contact.Length <= 0 || add_stats.Length <= 0)
                {
                    Login.m1.ShowMessageAsync("添加失败", "请填写所有必要信息");
                }
                else
                {
                    //添加语句
                    String str_sql = "insert into fact_mail_status(mail_id , courier_company , org_name , org_address , send_date ,send_name ,send_address , send_contact , stats , remarks) values ('" +
                        add_mail_id + "','" + add_courier_company + "','" + add_org_name + "','" + add_org_address + "','"
                        + add_send_date + "','" + add_send_name + "','" + add_send_address + "','" + add_send_contact + "','"
                        + add_stats + "','" + add_remarks + "')";

                    MySqlCommand mysql_cmd = new MySqlCommand(str_sql, connect.MySqlConnection);

                    String str_sql_2 = "insert into order_list (order_id , mail_id , logistics_company) values ('" +
                        add_order_id + "','" + add_mail_id + "','" + add_courier_company + "')";
                    MySqlCommand mysql_cmd_1 = new MySqlCommand(str_sql_2, connect.MySqlConnection);

                    Console.WriteLine("添加成功");

                    //这里返回的是受影响的行数，为int值。可以根据返回的值进行判断是否插入成功。
                    int result = mysql_cmd.ExecuteNonQuery();
                    int result_1 = mysql_cmd_1.ExecuteNonQuery();
                    if (result > 0 && result_1 > 0)
                    {
                        Login.m1.ShowMessageAsync("添加成功", "订单编号: " + add_order_id);
                        //成功之后把输入框中的值清空
                        input_mail_id.Clear();
                        Lcom.Text = "";
                        input_org_name.Clear();
                        input_org_address.Clear();
                        input_send_name.Clear();
                        input_send_address.Clear();
                        input_send_contact.Clear();
                        input_status.Clear();
                        input_remarks.Clear();

                    }
                    else
                    {
                        Login.m1.ShowMessageAsync("添加失败", "请重新尝试");
                    }
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

