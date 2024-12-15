<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterpage.Master" AutoEventWireup="true" CodeBehind="EditCategory.aspx.cs" Inherits="BTL_TTCSN_NHOM10.Admin.EditCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function PreviewImage() {
            var file = document.getElementById("txtImage").files[0];
            if (file) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    document.getElementById("imgPreview").src = e.target.result;
                    document.getElementById("imgContainer").style.display = "block";
                };
                reader.readAsDataURL(file);
            }
        }
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-lg-8 col-md-10">
                    <div class="card">
                        <div class="card-body">
                            <h4 class="card-title text-center mb-4">Chỉnh sửa danh mục</h4>
                          
                                <!-- ID danh mục -->
                                <div class="form-group">
                                    <label for="lblId">ID danh mục</label>
                                    <asp:Label ID="lblId" runat="server" CssClass="form-control-plaintext" />
                                </div>

                                <!-- Tên danh mục -->
                                <div class="form-group">
                                    <label for="txtName">Tên danh mục</label>
                                    <asp:TextBox CssClass="form-control" ID="txtName" runat="server" placeholder="Nhập tên danh mục"></asp:TextBox>
                                </div>

                                <!-- Hình ảnh hiện tại -->
                                <div class="form-group">
                                    <label>Hình ảnh hiện tại</label>
                                    <div>
                                        <asp:Image ID="imgCurrent" runat="server" CssClass="img-fluid rounded" Style="max-width: 200px;" />
                                    </div>
                                </div>

                                <!-- Chọn hình ảnh mới -->
                                <div class="form-group">
                                    <label for="txtImage">Thay đổi hình ảnh</label>
                                    <asp:FileUpload ID="txtImage" CssClass="form-control-file" runat="server" onchange="PreviewImage()" />
                                    <div id="imgContainer" class="mt-3" style="display: none;">
                                        <label for="imgPreview">Hình ảnh mới:</label>
                                        <img id="imgPreview" class="img-fluid rounded" style="max-width: 200px;" src="" alt="Preview" />
                                    </div>
                                    <small class="form-text text-muted">Để trống nếu không muốn thay đổi hình ảnh.</small>
                                </div>

                                <!-- Nút hành động -->
                                <div class="form-group text-center">
                                    <asp:Button ID="btnLuu" CssClass="btn btn-primary mx-2" Text="Lưu thay đổi" runat="server" OnClick="btnSua_Click" />
                                    <asp:Button ID="btnBoqua" CssClass="btn btn-secondary mx-2" Text="Bỏ qua" runat="server" OnClick="btnBoqua_Click" />
                                </div>
                          
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
