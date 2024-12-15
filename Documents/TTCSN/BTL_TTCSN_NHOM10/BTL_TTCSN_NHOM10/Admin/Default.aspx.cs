using BTL_TTCSN_NHOM10.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BTL_TTCSN_NHOM10.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/Login_LogoutPage/Login.aspx");
            }
            LoadUserCount();
            LoadProductCount();
            LoadProductStats();
        }
        private void LoadUserCount()
        {
            try
            {
                DataUtilUser dataUtil = new DataUtilUser();
                int userCount = dataUtil.GetUserCount();

                // Cập nhật số user lên giao diện
                lblUserCount.Text = userCount.ToString();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Có lỗi xảy ra: {ex.Message}');", true);
            }
        }

        private void LoadProductCount()
        {
            try
            {
                DataUtilProduct dataUtil = new DataUtilProduct();
                int ProductCount = dataUtil.GetProductCount();

                // Cập nhật số user lên giao diện
                lblProductCount.Text = ProductCount.ToString();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Có lỗi xảy ra: {ex.Message}');", true);
            }
        }
        // Lấy danh sách sản phẩm theo danh mục và chuẩn bị dữ liệu để sử dụng trong JavaScript
        private void LoadProductStats()
        {
            try
            {
                DataUtilProduct dataUtil = new DataUtilProduct();
                Dictionary<string, int> productStats = dataUtil.GetProductCountByCategory();

                // Tạo chuỗi JavaScript từ dữ liệu trong Dictionary
                string categories = string.Join(",", productStats.Keys);
                string counts = string.Join(",", productStats.Values);

                // Lưu dữ liệu vào các HiddenField để sử dụng trong JavaScript
                hiddenCategories.Value = categories;
                hiddenCounts.Value = counts;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Có lỗi khi tải biểu đồ: {ex.Message}');", true);
            }
        }


    }
}