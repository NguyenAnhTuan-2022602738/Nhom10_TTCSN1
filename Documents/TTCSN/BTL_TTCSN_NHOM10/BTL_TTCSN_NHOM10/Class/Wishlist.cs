using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_TTCSN_NHOM10.Class
{
    public class Wishlist
    {
        public int Wishlist_id { get; set; }
        public int User_id { get; set; }
        public int Product_id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public Wishlist() { }
        public Wishlist(int wishlistId, int userId, int productId, DateTime createdDate, DateTime? updatedDate, string updatedBy)
        {
            Wishlist_id = wishlistId;
            User_id = userId;
            Product_id = productId;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            UpdatedBy = updatedBy;
        }
    }
}