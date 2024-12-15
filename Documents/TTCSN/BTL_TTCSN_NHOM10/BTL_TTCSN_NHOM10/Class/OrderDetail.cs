using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_TTCSN_NHOM10.Class
{
    public class OrderDetail
    {
        public int Order_Detail_id { get; set; }
        public int Quantity { get; set; }
        public decimal Total_price { get; set; }
        public int Product_id { get; set; }
        public int Order_id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public OrderDetail() { }
        public OrderDetail(int orderDetailId, int quantity, decimal totalPrice, int productId, int orderId, DateTime createdDate, DateTime? updatedDate, string updatedBy)
        {
            Order_Detail_id = orderDetailId;
            Quantity = quantity;
            Total_price = totalPrice;
            Product_id = productId;
            Order_id = orderId;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            UpdatedBy = updatedBy;
        }
    }
}