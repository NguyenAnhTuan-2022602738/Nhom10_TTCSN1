using BTL_TTCSN_NHOM10.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_TTCSN_NHOM10.Login_LogoutPage
{
    public partial class Register : System.Web.UI.Page
    {
        private DataUtilUser dataUtilUser = new DataUtilUser();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Nếu người dùng đã đăng nhập rồi, chuyển hướng đến trang quản trị
            if (Session["User"] != null)
            {
                Response.Redirect("~/Admin/Default.aspx");
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                // Sử dụng lớp System.Text.RegularExpressions để kiểm tra email
                var emailRegex = new System.Text.RegularExpressions.Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return emailRegex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string phone = txtPhoneNumber.Text.Trim();
            string address = txtAddress.Text.Trim();

            // Kiểm tra mật khẩu và xác nhận mật khẩu có khớp không
            if (password != confirmPassword)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Mật khẩu và xác nhận mật khẩu không khớp!');", true);
                return; // Dừng xử lý nếu không khớp
            }

            // Kiểm tra định dạng email hợp lệ
            if (!IsValidEmail(email))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Email không đúng định dạng!');", true);
                return;
            }

            // Kiểm tra xem email đã tồn tại trong cơ sở dữ liệu chưa
            bool emailExists = dataUtilUser.CheckEmailExists(email);

            if (emailExists)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Email đã tồn tại!');", true);
            }
            else
            {
                // Nếu chưa tồn tại email, tiến hành đăng ký
                Users newUser = new Users
                {
                    FullName = fullName,
                    Email = email,
                    PassWord = password, // Lưu mật khẩu thô (hoặc mã hóa mật khẩu trước khi lưu vào DB)
                    PhoneNumber = phone,
                    Address = address,
                    Role_id = 2, // Tất cả người dùng mới đều có role là 2 (user bình thường)
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    UpdatedBy = "user"

                };

                // Lưu thông tin người dùng vào cơ sở dữ liệu
                bool registrationSuccess = dataUtilUser.RegisterUser(newUser);

                if (registrationSuccess)
                {
                    // Sau khi đăng ký thành công, chuyển hướng người dùng về trang đăng nhập
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Đăng ký thành công!'); window.location.href='Login.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Đăng ký không thành công!');", true);
                }
            }
        }
    }
}