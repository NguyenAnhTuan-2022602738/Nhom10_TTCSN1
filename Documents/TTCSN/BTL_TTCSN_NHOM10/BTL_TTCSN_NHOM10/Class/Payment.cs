using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_TTCSN_NHOM10.Class
{
    public class Payment
    {
        public int Payment_id { get; set; }
        public DateTime Payment_date { get; set; }
        public string Payment_method { get; set; }
        public decimal Amount { get; set; }
        public int User_id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public Payment() { }
        public Payment(int paymentId, DateTime paymentDate, string paymentMethod, decimal amount, int userId, DateTime createdDate, DateTime? updatedDate, string updatedBy)
        {
            Payment_id = paymentId;
            Payment_date = paymentDate;
            Payment_method = paymentMethod;
            Amount = amount;
            User_id = userId;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            UpdatedBy = updatedBy;
        }
    }
}