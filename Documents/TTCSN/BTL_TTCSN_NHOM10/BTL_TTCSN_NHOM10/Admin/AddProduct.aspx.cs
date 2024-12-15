using BTL_TTCSN_NHOM10.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_TTCSN_NHOM10.Admin
{
    public partial class AddProduct : System.Web.UI.Page
    {
        DataUtilProduct dataUtil = new DataUtilProduct();
        DataUtilCategory dataUtilCategory = new DataUtilCategory();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            try
            {
                var categories = dataUtilCategory.dsCategories();
                ddlCategory.Items.Clear();
                ddlCategory.Items.Add(new ListItem("Chọn danh mục", "0")); // Default option

                foreach (var category in categories)
                {
                    ddlCategory.Items.Add(new ListItem(category.Name, category.Category_id.ToString()));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", $"alert('Lỗi khi tải danh mục: {ex.Message}');", true);
            }
        }

        protected void btnSaveProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string imagePath = SaveImage();
                Class.Product newProduct = new Class.Product
                {
                    Name = txtProductName.Text.Trim(),
                    SKU = txtSKU.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Price = decimal.Parse(txtPrice.Text.Trim()),
                    PriceSale = string.IsNullOrEmpty(txtPriceSale.Text) ? (decimal?)null : decimal.Parse(txtPriceSale.Text.Trim()),
                    Quantity = int.Parse(txtQuantity.Text.Trim()),
                    Category_id = int.Parse(ddlCategory.SelectedValue),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = "Admin"
                };

                // Lưu sản phẩm và lấy ID
                int productId = dataUtil.intAddProduct(newProduct);

                if (!string.IsNullOrEmpty(imagePath))
                {
                    ProductImage productImage = new ProductImage
                    {
                        Image = imagePath,
                        Product_id = productId,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = "Admin"
                    };

                    // Lưu hình ảnh
                    dataUtil.AddProductImage(productImage);
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Sản phẩm và hình ảnh đã được lưu thành công!'); window.location='Product.aspx';", true);
                ClearForm();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", $"alert('Lỗi: {ex.Message}');", true);
            }
        }



        //private string SaveImage()
        //{
        //    if (fuProductImage.HasFile)
        //    {
        //        string fileName = Path.GetFileName(fuProductImage.FileName);
        //        string folderPath = Server.MapPath("~/Images/");
        //        if (!System.IO.Directory.Exists(folderPath))
        //        {
        //            System.IO.Directory.CreateDirectory(folderPath);
        //        }
        //        string filePath = folderPath + fileName;
        //        fuProductImage.SaveAs(filePath);
        //        return filePath;
        //    }
        //    return null;
        //}
        private string SaveImage()
        {
            if (fuProductImage.HasFile)
            {
                string fileName = Path.GetFileName(fuProductImage.FileName);
                string folderPath = Server.MapPath("~/Images/");
                if (!System.IO.Directory.Exists(folderPath))
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                }
                string filePath = folderPath + fileName;
                fuProductImage.SaveAs(filePath);
                return fileName; // Chỉ trả về tên file
            }
            return null;
        }


        private void ClearForm()
        {
            txtProductName.Text = "";
            txtSKU.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtPriceSale.Text = "";
            txtQuantity.Text = "";
            ddlCategory.SelectedIndex = 0;
            fuProductImage.Dispose();
        }
    }
}