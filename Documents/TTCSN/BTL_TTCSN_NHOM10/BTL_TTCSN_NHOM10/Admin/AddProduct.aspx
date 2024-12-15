<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterpage.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="BTL_TTCSN_NHOM10.Admin.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .custom-form {
            display: flex;
            flex-direction: column;
            gap: 15px;
        }

        .form-label {
            font-weight: bold;
        }

        .btn {
            margin-top: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="page-breadcrumb">
            <div class="row">
                <div class="col-7 align-self-center">
                    <h4 class="page-title text-truncate text-dark font-weight-medium mb-1">Nhập thông tin sản phẩm</h4>
                    <div class="d-flex align-items-center">
                        <nav aria-label="breadcrumb">
                            <ol class="breadcrumb m-0 p-0">
                                <li class="breadcrumb-item"><a href="Default.aspx" class="text-muted">Home</a></li>
                                <li class="breadcrumb-item text-muted active" aria-current="page">Sản phẩm</li>
                            </ol>
                        </nav>
                    </div>
                </div>
            </div>
        </div>

        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="card">
                        <div class="card-body">
                            <h4 class="card-title">Nhập thông tin sản phẩm</h4>
                            <div class="custom-form">
                                <asp:Label ID="lblProductName" runat="server" Text="Tên sản phẩm" CssClass="form-label" />
                                <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" />

                                <asp:Label ID="lblSKU" runat="server" Text="Thương hiệu" CssClass="form-label" />
                                <asp:TextBox ID="txtSKU" runat="server" CssClass="form-control" />

                                <asp:Label ID="lblDescription" runat="server" Text="Mô tả sản phẩm" CssClass="form-label" />
                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="4" />

                                <asp:Label ID="lblPrice" runat="server" Text="Giá" CssClass="form-label" />
                                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" />

                                <asp:Label ID="lblPriceSale" runat="server" Text="Giá khuyến mãi" CssClass="form-label" />
                                <asp:TextBox ID="txtPriceSale" runat="server" CssClass="form-control" />

                                <asp:Label ID="lblQuantity" runat="server" Text="Số lượng" CssClass="form-label" />
                                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" />

                                <asp:Label ID="lblCategory" runat="server" Text="Danh mục" CssClass="form-label" />
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Chọn danh mục" Value="0" />
                                </asp:DropDownList>

                                <asp:Label ID="lblProductImage" runat="server" Text="Ảnh sản phẩm" CssClass="form-label" />
                                <asp:FileUpload ID="fuProductImage" runat="server" CssClass="form-control" />

                                <asp:Button ID="btnSaveProduct" runat="server" Text="Lưu sản phẩm" OnClick="btnSaveProduct_Click" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

