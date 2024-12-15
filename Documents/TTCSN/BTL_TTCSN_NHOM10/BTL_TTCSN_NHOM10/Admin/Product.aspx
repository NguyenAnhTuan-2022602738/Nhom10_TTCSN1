<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterpage.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="BTL_TTCSN_NHOM10.Admin.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .image-container {
            display: flex;
            justify-content: center;
            align-items: center;
            max-width: 150px; /* Adjust max-width to suit layout */
            overflow: hidden; /* Hide overflow */
            border-radius: 5px; /* Optional: rounded corners */
            border: 1px solid #ddd; /* Optional: border for a cleaner look */
        }

        .responsive-image {
            width: 100%; /* Responsive width */
            height: auto; /* Maintain aspect ratio */
        }

        .custom-gridview {
            width: 100%;
            border-collapse: collapse; /* Remove spacing between cells */
        }

            .custom-gridview th, .custom-gridview td {
                text-align: left;
                padding: 10px; /* Add padding inside cells */
            }

            .custom-gridview th {
                background-color: #f8f9fa; /* Header background color */
                color: #333; /* Header text color */
                font-weight: bold;
                border-bottom: 2px solid #ddd; /* Bottom border for header */
            }

            .custom-gridview tr:nth-child(even) {
                background-color: #f2f2f2; /* Even row background color */
            }

            .custom-gridview tr:nth-child(odd) {
                background-color: #ffffff; /* Odd row background color */
            }

            .custom-gridview tr:hover {
                background-color: #d9edf7; /* Background color on hover */
            }

            .custom-gridview td {
                border: none; /* Remove cell borders */
            }

        .image-container {
            text-align: center;
        }

        .responsive-image {
            max-width: 80px; /* Limit image width */
            height: auto;
            border-radius: 5px; /* Round image corners */
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- ============================================================== -->
    <!-- Page wrapper  -->
    <!-- ============================================================== -->
    <div class="page-wrapper">
        <!-- ============================================================== -->
        <!-- Bread crumb and right sidebar toggle -->
        <!-- ============================================================== -->
        <div class="page-breadcrumb">
            <div class="row">
                <div class="col-7 align-self-center">
                    <h4 class="page-title text-truncate text-dark font-weight-medium mb-1">Danh sách danh mục</h4>
                    <div class="d-flex align-items-center">
                        <nav aria-label="breadcrumb">
                            <ol class="breadcrumb m-0 p-0">
                                <li class="breadcrumb-item"><a href="index.html" class="text-muted">Home</a></li>
                                <li class="breadcrumb-item text-muted active" aria-current="page">Library</li>
                            </ol>
                        </nav>
                    </div>
                </div>
                <div class="col-5 align-self-center">
                    <div class="customize-input float-right">
                        <select class="custom-select custom-select-set form-control bg-white border-0 custom-shadow custom-radius">
                            <option selected>Aug 19</option>
                            <option value="1">July 19</option>
                            <option value="2">Jun 19</option>
                        </select>
                    </div>
                </div>
            </div>
        </div>
        <!-- ============================================================== -->
        <!-- End Bread crumb and right sidebar toggle -->
        <!-- ============================================================== -->
        <!-- ============================================================== -->
        <!-- Container fluid  -->
        <!-- ============================================================== -->
        <div class="container-fluid">
            <!-- ============================================================== -->
            <!-- Start Page Content -->
            <!-- ============================================================== -->

            <div class="row">
                <div class="col-12">
                    <div class="card">
                        <div class="card-body">
                            <h4 class="card-title">Bảo trì sản phẩm</h4>
                            <div class="table-responsive">
                                <asp:GridView ID="grdDs" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-striped table-bordered display no-wrap"
                                    AllowPaging="false" OnRowDataBound="grdDs_RowDataBound"
                                    OnRowCommand="grdDs_RowCommand" Style="width: 100%">
                                    <Columns>
                                        <asp:BoundField DataField="Product_id" HeaderText="Mã sản phẩm" runat="server">
                                            <HeaderStyle Width="10%" />
                                            <ItemStyle Width="10%" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="Ảnh">
                                            <HeaderStyle Width="15%" />
                                            <ItemStyle Width="15%" />
                                            <ItemTemplate>
                                                <img src='<%# string.IsNullOrEmpty(Eval("Image")?.ToString()) ? ResolveUrl("~/Images/default.png") : ResolveUrl("~/Images/" + Eval("Image").ToString()) %>'
                                                    alt="Ảnh" class="responsive-image" style="width: 100px; height: auto;" />
                                            </ItemTemplate>
                                        </asp:TemplateField>



                                        <asp:BoundField DataField="Name" HeaderText="Tên sản phẩm" runat="server">
                                            <HeaderStyle Width="30%" />
                                            <ItemStyle Width="30%" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="Ngày tạo">
                                            <HeaderStyle Width="20%" />
                                            <ItemStyle Width="20%" />
                                            <ItemTemplate>
                                                <span><%# Eval("CreatedDate", "{0:dd/MM/yyyy HH:mm:ss}") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Ngày sửa">
                                            <HeaderStyle Width="20%" />
                                            <ItemStyle Width="20%" />
                                            <ItemTemplate>
                                                <span><%# Eval("UpdatedDate", "{0:dd/MM/yyyy HH:mm:ss}") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Thao tác">
                                            <HeaderStyle Width="15%" />
                                            <ItemStyle Width="15%" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="EditProduct"
                                                    CommandArgument='<%# Eval("Product_id") %>' CssClass="btn btn-primary btn-sm mr-2">
                             <i class="fas fa-edit"></i> Sửa
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteProduct"
                                                    CommandArgument='<%# Eval("Product_id") %>' CssClass="btn btn-danger btn-sm"
                                                    OnClientClick="return confirm('Bạn có chắc chắn muốn xóa danh mục này?');">
                             <i class="fas fa-trash-alt"></i> Xóa
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>

                            <div>
                                <asp:PlaceHolder ID="phPagination" runat="server"></asp:PlaceHolder>
                            </div>

                            <div class="mt-3">
                                <asp:Button ID="btn1" Text="Thêm sản phẩm" runat="server" PostBackUrl="~/Admin/AddProduct.aspx" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>





               <!-- Insert the new controls here, just before the closing </form> tag -->
            <asp:HiddenField ID="hiddenPageIndex" runat="server" />
            <asp:Button ID="btnChangePage" runat="server" Style="display: none;" OnClick="btnChangePage_Click" />
            <!-- ============================================================== -->
            <!-- End Page Content -->
            <!-- ============================================================== -->
            <!-- ============================================================== -->
            <!-- Right sidebar -->
            <!-- ============================================================== -->
            <!-- .right-sidebar -->
            <!-- ============================================================== -->
            <!-- End Right sidebar -->
            <!-- ============================================================== -->
        </div>
        <!-- ============================================================== -->
        <!-- End Container fluid  -->
        <!-- ============================================================== -->
        <!-- ============================================================== -->
        <!-- footer -->
        <!-- ============================================================== -->
        <footer class="footer text-center text-muted">
        </footer>
        <!-- ============================================================== -->
        <!-- End footer -->
        <!-- ============================================================== -->
    </div>
    <!-- ============================================================== -->
    <!-- End Page wrapper  -->
    <!-- ============================================================== -->
</asp:Content>
