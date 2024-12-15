using BTL_TTCSN_NHOM10.Class;
using System;
using System.IO;
using System.Web.UI;

namespace BTL_TTCSN_NHOM10.Admin
{
    public partial class AddCategory : System.Web.UI.Page
    {
        DataUtilCategory data = new DataUtilCategory();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Any initialization logic can go here
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string imageFileName = null;

            if (string.IsNullOrEmpty(name))
            {
                // Show an error message if the name is empty
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tên danh mục không được để trống!');", true);
                return;
            }

            if (data.KiemTraTenDanhMuc(name))
            {
                // Show an error message if the category name already exists
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tên danh mục đã tồn tại!');", true);
                return;
            }

            // Handle image upload
            if (txtImage.HasFile)
            {
                string fileExtension = Path.GetExtension(txtImage.FileName).ToLower();
                if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".jpeg")
                {
                    // Generate a unique file name
                    imageFileName = $"category_{DateTime.Now.Ticks}{fileExtension}";
                    string filePath = Server.MapPath($"~/Images/{imageFileName}");
                    txtImage.SaveAs(filePath);
                }
                else
                {
                    // Show an error message if the file type is not valid
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Chỉ chấp nhận các định dạng ảnh .jpg, .png, .jpeg');", true);
                    return;
                }
            }

            // Create a new category object
            Class.Category newCategory = new Class.Category
            {
                Name = name,
                Image = imageFileName,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UpdatedBy = "Admin" // Replace with the actual user if necessary
            };

            // Add the category to the database
            try
            {
                data.ThemCT(newCategory);
                Response.Redirect("~/Admin/Category.aspx");
            }
            catch (Exception ex)
            {
                // Show an error message if there is an exception
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Có lỗi xảy ra: {ex.Message}');", true);
            }
        }

        protected void btnBoqua_Click(object sender, EventArgs e)
        {
            // Redirect back to the category list page
            Response.Redirect("~/Admin/Category.aspx");
        }
    }
}
