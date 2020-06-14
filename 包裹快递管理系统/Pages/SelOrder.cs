namespace 包裹快递管理系统
{
    public class SelOrder
    {
        public string 订单编号
        {
            get => OrderNumber;
            set => OrderNumber = value;
        }

        public string 物流单号
        {
            get => shipmentNumber;
            set => shipmentNumber = value;
        }

        public string 物流公司
        {
            get => LogisticsCompany;
            set => LogisticsCompany = value;
        }

        public string 发件人
        {
            get => Sender;
            set => Sender = value;
        }

        public string 发货地址
        {
            get => deliveryAddress;
            set => deliveryAddress = value;
        }

        public string 收件人
        {
            get => Recipient;
            set => Recipient = value;
        }

        public string 收件地址
        {
            get => RecipientAddress;
            set => RecipientAddress = value;
        }

        public string 收件人电话
        {
            get => RecipientTel;
            set => RecipientTel = value;
        }

        public string 状态
        {
            get => status;
            set => status = value;
        }

        public string 备注
        {
            get => Remarks;
            set => Remarks = value;
        }

        public SelOrder(string OrderNumber, string shipmentNumber, string LogisticsCompany, string Sender, string deliveryAddress, string Recipient, string RecipientAddress, string RecipientTel, string status, string Remarks)
        {
            this.OrderNumber = OrderNumber;
            this.shipmentNumber = shipmentNumber;
            this.LogisticsCompany = LogisticsCompany;
            this.Sender = Sender;
            this.deliveryAddress = deliveryAddress;
            this.Recipient = Recipient;
            this.RecipientAddress = RecipientAddress;
            this.RecipientTel = RecipientTel;
            this.status = status;
            this.Remarks = Remarks;
        }

        string OrderNumber;
        string shipmentNumber;
        string LogisticsCompany;
        string Sender;
        string deliveryAddress;
        string Recipient;
        string RecipientAddress;
        string RecipientTel;
        string status;
        string Remarks;

        public void toValue(string a, string b)
        {
            // MessageBox.Show(a, b);
            if (a == "物流单号")
            {
                shipmentNumber = b;
            }
            else if (a == "物流公司")
            {
                LogisticsCompany = b;
            }
            else if (a == "订单编号")
            {
                OrderNumber = b;
            }
            else if (a == "发件人")
            {
                Sender = b;
            }
            else if (a == "发货地址")
            {
                deliveryAddress = b;
            }
            else if (a == "收件人")
            {
                Recipient = b;
            }
            else if (a == "收件地址")
            {
                RecipientAddress = b;
            }
            else if (a == "收件人电话")
            {
                RecipientTel = b;
            }
            else if (a == "状态")
            {
                status = b;
            }
            else
            {
                Remarks = b;
            }

        }
    }
}
