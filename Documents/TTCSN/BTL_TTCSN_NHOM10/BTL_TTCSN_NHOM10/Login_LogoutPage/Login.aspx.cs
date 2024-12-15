using BTL_TTCSN_NHOM10.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_TTCSN_NHOM10.Login_LogoutPage
{
    public partial class Login : System.Web.UI.Page
    {
        DataUtilUser dataUtilUser = new DataUtilUser();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Nếu đã đăng nhập, chuyển hướng sang trang chính
            if (Session["User"] != null)
            {
                Response.Redirect("~/Admin/Default.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                // Kiểm tra thông tin người dùng
                Users user = dataUtilUser.ValidateUser(email, password);

                if (user != null)
                {
                    // Lưu thông tin người dùng vào session
                    Session["User"] = user;

                    // Tùy thuộc vai trò, chuyển hướng tới các trang khác nhau
                    if (user.Role_id == 1) // Admin
                    {
                        Response.Redirect("~/Admin/Default.aspx");
                    }
                    else if (user.Role_id == 2) // Người dùng thường
                    {
                        Response.Redirect("~/Client/Default.aspx");
                    }
                }
                else
                {
                    // Thông báo đăng nhập thất bại
                    ScriptManager.RegisterStartupScript(this, GetType(), "LoginError", "alert('Email hoặc mật khẩu không đúng!');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", $"alert('Có lỗi xảy ra: {ex.Message}');", true);
            }
        }
    }
}