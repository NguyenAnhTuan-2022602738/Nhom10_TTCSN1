using BTL_TTCSN_NHOM10.Class;
using System;
using System.IO;
using System.Web.UI;

namespace BTL_TTCSN_NHOM10.Admin
{
    public partial class EditCategory : System.Web.UI.Page
    {
        DataUtilCategory data = new DataUtilCategory();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategory();
            }
        }

        private void LoadCategory()
        {
            // Lấy ID danh mục từ query string
            int categoryId = 0;
            if (int.TryParse(Request.QueryString["CategoryId"], out categoryId))
            {
                Class.Category category = data.Layra1DM(categoryId);
                if (category != null)
                {
                    lblId.Text = category.Category_id.ToString();
                    txtName.Text = category.Name;
                    imgCurrent.ImageUrl = string.IsNullOrEmpty(category.Image)
                        ? "~/Images/default.png"
                        : $"~/Images/{category.Image}";
                }
                else
                {
                    Response.Redirect("~/Admin/Category.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Admin/Category.aspx");
            }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse(lblId.Text);
            string name = txtName.Text.Trim();
            string newImage = null;

            if (string.IsNullOrEmpty(name))
            {
                // Show an error message if the name is empty
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tên danh mục không được để trống!');", true);
                return;
            }

            // Xử lý upload hình ảnh
            if (txtImage.HasFile)
            {
                string fileExtension = Path.GetExtension(txtImage.FileName).ToLower();
                if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".jpeg")
                {
                    string fileName = $"category_{categoryId}{fileExtension}";
                    string filePath = Server.MapPath($"~/Images/{fileName}");
                    txtImage.SaveAs(filePath);
                    newImage = fileName;
                }
                else
                {
                    // Hiển thị thông báo lỗi định dạng
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Chỉ chấp nhận các định dạng ảnh .jpg, .png, .jpeg');", true);
                    return;
                }
            }

            // Lấy thông tin danh mục hiện tại
            Class.Category category = data.Layra1DM(categoryId);
            if (category != null)
            {
                category.Name = name;
                try
                {
                    if (!string.IsNullOrEmpty(newImage))
                    {
                        category.Image = newImage;
                    }

                    // Cập nhật thông tin danh mục
                    data.SuaDM(category);

                    // Hiển thị thông báo thành công và chuyển hướng sau 2 giây
                    string script = "alert('Cập nhật danh mục thành công!'); window.setTimeout(function(){ window.location.href = 'Category.aspx'; }, 100);";
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", script, true);
                }
                catch (Exception ex)
                {
                    string script = $"alert('Có lỗi xảy ra: {ex.Message}');";
                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateError", script, true);
                }
            }
            else
            {
                // Nếu không tìm thấy danh mục, hiển thị thông báo lỗi
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Danh mục không tồn tại!');", true);
            }
        }


        protected void btnBoqua_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Category.aspx");
        }
    }
}
