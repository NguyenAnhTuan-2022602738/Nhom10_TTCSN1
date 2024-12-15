<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterpage.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="BTL_TTCSN_NHOM10.Admin.AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PreviewImage() {
            var file = document.getElementById("txtImage").files[0];
            var reader = new FileReader();
            reader.onloadend = function () {
                var img = document.createElement("img");
                img.src = reader.result;
                img.id = "imgPreview";
                img.style.display = "block";
                img.style.maxWidth = "200px";
                img.style.marginTop = "10px";

                var imgContainer = document.getElementById("imgContainer");
                imgContainer.innerHTML = "";
                imgContainer.appendChild(img);

                // Save the image data to a temporary variable for later use
                var imgData = reader.result;
                document.getElementById("hfImageData").value = imgData;
            }
            if (file) {
                reader.readAsDataURL(file);
            } else {
                var imgContainer = document.getElementById("imgContainer");
                imgContainer.innerHTML = "";
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="row">
            <div class="col-lg-8 col-md-8 col-sm-12">
                <div class="card">
                    <div class="card-body">
                        <h4 class="card-title">Thêm danh mục</h4>
                        <asp:Table ID="tblds" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>Tên danh mục: </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox CssClass="form-control" ID="txtName" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell>Hình ảnh: </asp:TableCell>
                                <asp:TableCell>
                                    <asp:FileUpload ID="txtImage" runat="server" OnChange="PreviewImage()" />
                                    <br />
                                    <div id="imgContainer" runat="server"></div>
                                    <asp:HiddenField ID="hfImageData" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <br />
                        <p>
                            <asp:Button ID="btnThem" CssClass="btn btn-outline-success" Text="Thêm danh mục" runat="server" OnClick="btnThem_Click" />
                            <asp:Button ID="btnBoqua" CssClass="btn btn-dark" Text="Bỏ qua" runat="server" OnClick="btnBoqua_Click"/>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-4"></div>
    </div>
</asp:Content>
