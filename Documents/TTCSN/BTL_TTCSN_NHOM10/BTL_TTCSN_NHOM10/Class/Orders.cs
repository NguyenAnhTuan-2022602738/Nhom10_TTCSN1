using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_TTCSN_NHOM10.Class
{
    public class Orders
    {
        public int Order_id { get; set; }
        public DateTime Order_date { get; set; }
        public decimal Total_price { get; set; }
        public int User_id { get; set; }
        public int Payment_id { get; set; }
        public int Shipment_id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public Orders() { }
        public Orders(int orderId, DateTime orderDate, decimal totalPrice, int userId, int paymentId, int shipmentId, DateTime createdDate, DateTime? updatedDate, string updatedBy)
        {
            Order_id = orderId;
            Order_date = orderDate;
            Total_price = totalPrice;
            User_id = userId;
            Payment_id = paymentId;
            Shipment_id = shipmentId;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            UpdatedBy = updatedBy;
        }
    }
}