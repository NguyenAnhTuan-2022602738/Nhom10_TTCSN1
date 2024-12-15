<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BTL_TTCSN_NHOM10.Login_LogoutPage.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng ký tài khoản</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background-color: #f5f5f5;
        }
        .signup-container {
            width: 300px;
            padding: 40px;
            background: white;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 5px;
        }
        .signup-container h2 {
            margin-bottom: 20px;
            text-align: center;
        }
        .form-control {
            margin-bottom: 15px;
            width: 275px;
            padding: 10px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
        .signup-container a {
            display: block;
            text-align: right;
            font-size: 12px;
            color: #007bff;
            text-decoration: none;
            margin-bottom: 15px;
        }
        .signup-container a:hover {
            text-decoration: underline;
        }
        .signup-button {
            width: 100%;
            background-color: red;
            color: white;
            border: none;
            padding: 10px;
            font-size: 14px;
            cursor: pointer;
            border-radius: 4px;
        }
        .signup-container .register-link {
            display: flex;
            text-align: center;
            margin-top: 25px;
        }
        .signuplink{
            font-size: 15px;
            margin-right: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="signup-container">
                <h2>Đăng ký tài khoản</h2>
                <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" Placeholder="Họ tên" required="required"></asp:TextBox>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email" required="required"></asp:TextBox>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Mật khẩu" required="required"></asp:TextBox>
                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Xác nhận mật khẩu" required="required"></asp:TextBox>
                <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" Placeholder="Số điện thoại" required="required"></asp:TextBox>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Placeholder="Địa chỉ" required="required"></asp:TextBox>
                <asp:Button ID="btnRegister" runat="server" Text="Đăng ký" CssClass="signup-button" OnClick="btnRegister_Click" />
                <div class="register-link">
                    <div class="signuplink">
                        Đã có tài khoản? Đăng nhập 
                    </div>
                    <div>
                        <a href="Login.aspx">tại đây</a>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
