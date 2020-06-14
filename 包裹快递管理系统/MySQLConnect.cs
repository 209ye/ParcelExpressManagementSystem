using MySql.Data.MySqlClient;
using System;

namespace 包裹快递管理系统
{
    class MySQLConnect
    {
        //链接语句
        private MySqlConnection conn;
        //链接是否成功标记，若成功则为true，否则为false
        private bool connect_index;

        public MySqlConnection MySqlConnection
        {
            set { this.conn = value; }
            get { return this.conn; }
        }

        public bool ConnectIndex
        {
            set { this.connect_index = false; }
            get { return this.connect_index; }
        }

        public MySQLConnect()
        {
            // String connetStr = "server=127.0.0.1;port=3306;user=root;password=123456789;database=logistics_management;";
            String connetStr = "server=127.0.0.1;port=3307;user=root;password=123456;database=test;";
            conn = new MySqlConnection(connetStr);//实例化
        }

    }
}