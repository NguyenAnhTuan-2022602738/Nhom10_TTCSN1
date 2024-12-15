<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterpage.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="BTL_TTCSN_NHOM10.Admin.EditProduct" %>
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

        .product-images {
            display: flex;
            gap: 15px;
            flex-wrap: wrap;
        }

        .product-image-item {
            width: 150px;
            height: 150px;
            position: relative;
        }

        .product-image-item img {
            width: 100%;
            height: 100%;
            object-fit: cover;
        }

        .remove-image {
            position: absolute;
            top: 5px;
            right: 5px;
            background-color: rgba(0,0,0,0.5);
            color: white;
            border: none;
            cursor: pointer;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="page-breadcrumb">
            <div class="row">
                <div class="col-7 align-self-center">
                    <h4 class="page-title text-truncate text-dark font-weight-medium mb-1">Sửa thông tin sản phẩm</h4>
                </div>
            </div>
        </div>

        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="card">
                        <div class="card-body">
                            <h4 class="card-title">Sửa thông tin sản phẩm</h4>
                            <div class="custom-form">
                                <!-- Product Name -->
                                <asp:Label ID="lblProductName" runat="server" Text="Tên sản phẩm" CssClass="form-label" />
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />

                                <!-- SKU -->
                                <asp:Label ID="lblSKU" runat="server" Text="SKU" CssClass="form-label" />
                                <asp:TextBox ID="txtSKU" runat="server" CssClass="form-control" />

                                <!-- Description -->
                                <asp:Label ID="lblDescription" runat="server" Text="Mô tả sản phẩm" CssClass="form-label" />
                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="4" />

                                <!-- Price -->
                                <asp:Label ID="lblPrice" runat="server" Text="Giá" CssClass="form-label" />
                                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" />

                                <!-- Price Sale -->
                                <asp:Label ID="lblPriceSale" runat="server" Text="Giá khuyến mãi" CssClass="form-label" />
                                <asp:TextBox ID="txtPriceSale" runat="server" CssClass="form-control" />

                                <!-- Quantity -->
                                <asp:Label ID="lblQuantity" runat="server" Text="Số lượng" CssClass="form-label" />
                                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" />

                                <!-- Category -->
                                <asp:Label ID="lblCategory" runat="server" Text="Danh mục" CssClass="form-label" />
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Chọn danh mục" Value="0" />
                                </asp:DropDownList>

                                <!-- Product Image List -->
                                <asp:Label ID="lblProductImages" runat="server" Text="Ảnh sản phẩm" CssClass="form-label" />
                                
                                <div class="product-images">
                                    <asp:Repeater ID="rptProductImages" runat="server">
                                        <ItemTemplate>
                                            <div class="product-image-item">
                                                <!-- Image Display -->
                                                <img src='<%# Eval("ImagePath") %>' alt="Product Image" />
                                                <!-- Remove Image Button -->
                                                <button type="button" class="remove-image" onclick="removeImage('<%# Eval("ImageId") %>')">X</button>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>

                                <%--<!-- File Upload for New Product Image -->
                                <asp:FileUpload ID="fuProductImage" runat="server" CssClass="form-control" />--%>

                                <asp:Label ID="lblProductImage" runat="server" Text="Ảnh sản phẩm hiện tại" CssClass="form-label" />
                                <div class="product-image-item">
                                    <!-- Hiển thị ảnh hiện tại -->
                                    <asp:Image ID="imgCurrentProductImage" runat="server" CssClass="img-thumbnail" Height="150px" Width="150px" />
                                </div>

                                <asp:Label ID="lblNewProductImage" runat="server" Text="Thay ảnh sản phẩm" CssClass="form-label" />
                                <asp:FileUpload ID="fuNewProductImage" runat="server" CssClass="form-control" />

                                <asp:HiddenField ID="hfImageId" runat="server" />

                                <!-- Save Button -->
                                <asp:Button ID="btnSaveProduct" runat="server" Text="Cập nhật sản phẩm" OnClick="btnSaveProduct_Click" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
<script type="text/javascript">
    function removeImage(imageId) {
        if (confirm("Are you sure you want to delete this image?")) {
            var productId = '<%= Request.QueryString["ProductID"] %>';
            // Call to a server-side method to delete the image
            window.location.href = 'EditProduct.aspx?ProductID=' + productId + '&RemoveImageId=' + imageId;
        }
    }
</script>
</asp:Content>