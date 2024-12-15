<%@ Page Title="" Language="C#" MasterPageFile="~/Client/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="Clothing.aspx.cs" Inherits="BTL_TTCSN_NHOM10.Client.Clothing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

        a.active{
            color: red; /* Màu chữ khi active */
        }

        .currency {
            text-decoration: underline; /* Gạch chân */
            vertical-align: super; /* Đưa ký tự lên cao */
            font-size: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="main">
      <div class="container">
        <ul class="breadcrumb">
            <li><a href="Default.aspx">Home</a></li>
            <li><a href="Clothing.aspx">Clothing</a></li>
        </ul>
        <!-- BEGIN SIDEBAR & CONTENT -->
        <div class="row margin-bottom-40">
          <!-- BEGIN SIDEBAR -->
          <div class="sidebar col-md-3 col-sm-5">
            <ul class="list-group margin-bottom-25 sidebar-menu">
                <li class="list-group-item clearfix">
                    <a href="Clothing.aspx">
                        <i class="fa fa-angle-right"></i>ALL ITEM
                    </a>
                </li>
                <asp:Repeater ID="rptCategories" runat="server" OnItemCommand="rptCategories_ItemCommand">
                    <ItemTemplate>
                        <li id="liCategory" class="list-group-item clearfix">
                            <i class="fa fa-angle-right"></i>
                            <asp:LinkButton ID="lnkCategory" runat="server" CommandName="FilterByCategory" CommandArgument='<%# Eval("Category_id") %>'>
                                <%# Eval("Name") %>
                            </asp:LinkButton>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
          </div>
          <!-- END SIDEBAR -->
          <!-- BEGIN CONTENT -->
          <div class="col-md-9 col-sm-7">
            <div class="row list-view-sorting clearfix">
              <div class="col-md-2 col-sm-2 list-view">
                <a href="javascript:;"><i class="fa fa-th-large"></i></a>
                <a href="javascript:;"><i class="fa fa-th-list"></i></a>
              </div>
                <div class="col-md-10 col-sm-10">
                    <div class="pull-right">
                        <label class="control-label">Sort&nbsp;By:</label>
                        <select class="form-control input-sm" id="sortSelect" onchange="sortProducts()">
                            <option value="Default" selected="selected">Default</option>
                            <option value="Name_ASC">Name (A - Z)</option>
                            <option value="Name_DESC">Name (Z - A)</option>
                            <option value="Price_ASC">Price (Low > High)</option>
                            <option value="Price_DESC">Price (High > Low)</option>
                        </select>
                    </div>
                </div>
            </div>
            <!-- BEGIN PRODUCT LIST -->
            <div class="row product-list">
              <!-- PRODUCT ITEM START -->
              <div class="row" id="productListDiv" runat="server">

              </div>
              <!-- PRODUCT ITEM END -->
              
            </div>
            <!-- END PRODUCT LIST -->
            <!-- BEGIN PAGINATOR -->
            <div class="row">
              <div class="col-md-4 col-sm-4 items-info">Items 1 to 9 of 10 total</div>
              <div class="col-md-8 col-sm-8">
                <ul class="pagination pull-right">
                  <li><a href="javascript:;">&laquo;</a></li>
                  <li><a href="javascript:;">1</a></li>
                  <li><span>2</span></li>
                  <li><a href="javascript:;">3</a></li>
                  <li><a href="javascript:;">4</a></li>
                  <li><a href="javascript:;">5</a></li>
                  <li><a href="javascript:;">&raquo;</a></li>
                </ul>
              </div>
            </div>
            <!-- END PAGINATOR -->
          </div>
          <!-- END CONTENT -->
        </div>
        <!-- END SIDEBAR & CONTENT -->
      </div>
    </div>

    <!-- BEGIN PAGE LEVEL JAVASCRIPTS (REQUIRED ONLY FOR CURRENT PAGE) -->
    <script src="../ClientTemplate/assets/plugins/fancybox/source/jquery.fancybox.pack.js" type="text/javascript"></script><!-- pop up -->
    <script src="../ClientTemplate/assets/plugins/owl.carousel/owl.carousel.min.js" type="text/javascript"></script><!-- slider for products -->
    <script src='../ClientTemplate/assets/plugins/zoom/jquery.zoom.min.js' type="text/javascript"></script><!-- product zoom -->
    <script src="../ClientTemplate/assets/plugins/bootstrap-touchspin/bootstrap.touchspin.js" type="text/javascript"></script><!-- Quantity -->
    <script src="../ClientTemplate/assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <script src="../ClientTemplate/assets/plugins/rateit/src/jquery.rateit.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js" type="text/javascript"></script><!-- for slider-range -->

    <script src="../ClientTemplate/assets/corporate/scripts/layout.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function() {
            Layout.init();    
            Layout.initOWL();
            Layout.initTwitter();
            Layout.initImageZoom();
            Layout.initTouchspin();
            Layout.initUniform();
            Layout.initSliderRange();
        });
    </script>
    <!-- END PAGE LEVEL JAVASCRIPTS -->
    <script>
        function sortProducts() {
            var sortValue = document.getElementById("sortSelect").value;
            var url = location.href.split('?')[0]; // Lấy URL hiện tại mà không có tham số query

            // Thêm tham số sắp xếp vào URL
            switch (sortValue) {
                case "Name_ASC":
                    url += "?sort=pd.name&order=ASC";
                    break;
                case "Name_DESC":
                    url += "?sort=pd.name&order=DESC";
                    break;
                case "Price_ASC":
                    url += "?sort=p.price&order=ASC";
                    break;
                case "Price_DESC":
                    url += "?sort=p.price&order=DESC";
                    break;
                default:
                    url += "?sort=p.sort_order&order=ASC";
            }

            // Điều hướng tới URL mới với tham số sắp xếp
            window.location.href = url;
        }
</script>
</asp:Content>
