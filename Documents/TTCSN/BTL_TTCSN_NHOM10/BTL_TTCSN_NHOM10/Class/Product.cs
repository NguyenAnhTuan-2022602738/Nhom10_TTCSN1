using BTL_TTCSN_NHOM10.Admin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace BTL_TTCSN_NHOM10.Class
{
    public class Product
    {
        public int Product_id { get; set; }
        public string Name {  get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceSale { get; set; }
        public int Quantity { get; set; }
        public int Category_id { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public Product() { }
        public Product(int productId, string name, string sku, string description, decimal price, decimal? priceSale, int quantity, int categoryId, DateTime createdDate, DateTime? updatedDate, string updatedBy)
        {
            Product_id = productId;
            Name = name;
            SKU = sku;
            Description = description;
            Price = price;
            PriceSale = priceSale;
            Quantity = quantity;
            Category_id = categoryId;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            UpdatedBy = updatedBy;
        }

    }
}