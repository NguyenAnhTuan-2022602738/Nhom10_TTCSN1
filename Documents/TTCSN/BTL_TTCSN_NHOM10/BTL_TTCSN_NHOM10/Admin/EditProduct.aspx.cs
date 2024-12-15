using BTL_TTCSN_NHOM10.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_TTCSN_NHOM10.Admin
{
    public partial class EditProduct : System.Web.UI.Page
    {
        DataUtilProduct dataUtil = new DataUtilProduct();
        DataUtilCategory dataUtilCategory = new DataUtilCategory();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                LoadCategories();
               
                
                // Check for the ProductID parameter
                if (Request.QueryString["ProductID"] == null)
                {

                    Response.Redirect("Product.aspx");
                }
                else
                {
                    int productId = Convert.ToInt32(Request.QueryString["ProductID"]);
                    LoadProductData(productId);
                    LoadProductImage(productId);

                    // Check for the RemoveImageId parameter
                    if (Request.QueryString["RemoveImageId"] != null)
                    {
                        int imageId = Convert.ToInt32(Request.QueryString["RemoveImageId"]);
                        RemoveImage(imageId, productId);
                    }
                }
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


        private void LoadProductData(int productId)
        {
            // Lấy sản phẩm từ cơ sở dữ liệu
            Class.Product product = dataUtil.GetProductById(productId);

            if (product != null)
            {
                // Điền thông tin vào các textbox, dropdownlist... để người dùng có thể chỉnh sửa
                txtName.Text = product.Name;
                txtSKU.Text = product.SKU;
                txtDescription.Text = product.Description;
                txtPrice.Text = product.Price.ToString();
                txtPriceSale.Text = product.PriceSale.ToString();
                txtQuantity.Text = product.Quantity.ToString();
                ddlCategory.SelectedValue = product.Category_id.ToString();
            }
        }


        //protected void RemoveImage(int imageId, int productId)
        //{
        //    dataUtil.DeleteProductImage(imageId);  // Xóa ảnh sản phẩm
        //    LoadProductImages(productId);  // Reload lại ảnh sản phẩm
        //}
        private void RemoveImage(int imageId, int productId)
        {
            try
            {
                // Call your data utility class to delete the image
                dataUtil.DeleteProductImage(imageId);

                // Reload the product images
                LoadProductImage(productId);
            }
            catch (Exception ex)
            {
                string script = $"alert('Error deleting image: {ex.Message}');";
                ClientScript.RegisterStartupScript(this.GetType(), "DeleteError", script, true);
            }
        }


        protected void rptProductImages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "RemoveImage")
            {
                int imageId = Convert.ToInt32(e.CommandArgument);
                int productId = Convert.ToInt32(Request.QueryString["ProductID"]);  // Lấy productId từ URL
                RemoveImage(imageId, productId);  // Truyền productId vào
            }
        }

        //private void LoadProductImages(int productId)
        //{
        //    List<ProductImage> images = dataUtil.GetProductImages(productId);
        //    rptProductImages.DataSource = images;
        //    rptProductImages.DataBind();
        //}
        private void LoadProductImage(int productId)
        {
            // Lấy thông tin ảnh từ cơ sở dữ liệu
            var productImages = new DataUtilProduct().GetProductImages(productId);

            if (productImages.Count > 0)
            {
                var currentImage = productImages[0]; // Chỉ lấy ảnh đầu tiên
                imgCurrentProductImage.ImageUrl = "~/Images/" + currentImage.Image;
                hfImageId.Value = currentImage.Image_id.ToString();
            }
            else
            {
                imgCurrentProductImage.ImageUrl = "~/Images/default.png"; // Placeholder nếu không có ảnh
            }
        }

        protected void btnSaveProduct_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ProductID"] != null)
            {
                int productId = Convert.ToInt32(Request.QueryString["ProductID"]);
                try
                {
                    Class.Product updatedProduct = new Class.Product
                    {
                        Product_id = productId,
                        Name = txtName.Text,
                        SKU = txtSKU.Text,
                        Description = txtDescription.Text,
                        Price = decimal.Parse(txtPrice.Text.Trim(), System.Globalization.CultureInfo.InvariantCulture),
                        PriceSale = decimal.Parse(txtPriceSale.Text.Trim(), System.Globalization.CultureInfo.InvariantCulture),
                        Quantity = Convert.ToInt32(txtQuantity.Text),
                        Category_id = Convert.ToInt32(ddlCategory.SelectedValue),
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = "Admin"
                    };

                
                    dataUtil.UpdateProduct(updatedProduct);  // Cập nhật sản phẩm
                                                             // Kiểm tra nếu có ảnh mới được tải lên
                    if (fuNewProductImage.HasFile)
                    {
                        // Xóa ảnh cũ
                        string oldImagePath = Server.MapPath(imgCurrentProductImage.ImageUrl);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }

                        // Lưu ảnh mới
                        string newFileName = Guid.NewGuid().ToString() + "_" + fuNewProductImage.FileName;
                        string newFilePath = Server.MapPath("~/Images/" + newFileName);
                        fuNewProductImage.SaveAs(newFilePath);

                        // Cập nhật ảnh sản phẩm trong cơ sở dữ liệu
                        ProductImage updatedImage = new ProductImage
                        {
                            Image_id = Convert.ToInt32(hfImageId.Value),
                            Image = newFileName,
                            UpdatedDate = DateTime.Now,
                            UpdatedBy = "Admin"
                        };

                        dataUtil.UpdateProductImage(updatedImage);

                        // Cập nhật giao diện
                        imgCurrentProductImage.ImageUrl = "~/Images/" + newFileName;
                    }

                    // Hiển thị thông báo thành công và chuyển hướng
                    ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Cập nhật sản phẩm thành công!'); window.location='Product.aspx';", true);
                }
                catch (FormatException ex)
                {
                    string script = $"alert('Dữ liệu nhập không hợp lệ: {ex.Message}');";
                    ClientScript.RegisterStartupScript(this.GetType(), "InputError", script, true);
                }
                catch (Exception ex)
                {
                    string script = $"alert('Có lỗi xảy ra: {ex.Message}');";
                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateError", script, true);
                }
            }
        }
    }
}