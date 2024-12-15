<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BTL_TTCSN_NHOM10.Login_LogoutPage.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background-color: #f5f5f5;
        }
        .login-container {
            width: 300px;
            padding: 20px;
            background: white;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 5px;
        }
        .login-container h2 {
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
        .login-container a {
            display: block;
            text-align: right;
            font-size: 12px;
            color: #007bff;
            text-decoration: none;
            margin-bottom: 15px;
        }
        .login-container a:hover {
            text-decoration: underline;
        }
        .login-button {
            width: 100%;
            background-color: red;
            color: white;
            border: none;
            padding: 10px;
            font-size: 14px;
            cursor: pointer;
            border-radius: 4px;
        }
        .login-container .register-link {
            text-align: center;
            margin-top: 10px;
        }
        .signuplink{
            font-size: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Đăng nhập</h2>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email" required="required">></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Mật khẩu" required="required">></asp:TextBox>
            <a href="#">Quên mật khẩu?</a>
            <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" CssClass="login-button" OnClick="btnLogin_Click" />
            <div class="register-link">
                <div class="signuplink">
                    Nếu bạn chưa có tài khoản, vui lòng đăng ký<a href="Register.aspx">tại đây</a>
                </div> 
            </div>
        </div>
    </form>
</body>
</html>
