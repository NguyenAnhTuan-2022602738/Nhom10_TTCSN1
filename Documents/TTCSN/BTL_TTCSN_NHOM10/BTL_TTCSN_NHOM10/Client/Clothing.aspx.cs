using BTL_TTCSN_NHOM10.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BTL_TTCSN_NHOM10.Client
{
    public partial class Clothing : System.Web.UI.Page
    {
        DataUtilCategory dataUtilCategory = new DataUtilCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                LoadProductList();
            }
            
        }
        private void LoadCategories()
        {
            try
            {
                // Lấy danh sách danh mục từ database
                List<Category> categories = dataUtilCategory.dsCategories();

                // Gắn dữ liệu vào Repeater
                rptCategories.DataSource = categories;
                rptCategories.DataBind();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (nếu có)
                Response.Write("<script>alert('Lỗi tải danh mục: " + ex.Message + "');</script>");
            }
        }

        //Thêm sự kiện cho danh mục
        protected void rptCategories_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "FilterByCategory")
            {
                int categoryId = int.Parse(e.CommandArgument.ToString());

                // Gọi lại danh sách sản phẩm cho category đã chọn
                LoadProductList(categoryId);

                // Set trạng thái Active cho danh mục đã chọn
                foreach (RepeaterItem item in rptCategories.Items)
                {
                    var linkButton = (LinkButton)item.FindControl("lnkCategory");
                    if (linkButton != null)
                    {
                        if (linkButton.CommandArgument.ToString() == categoryId.ToString())
                        {
                            linkButton.CssClass = "active"; // Active category
                        }
                        else
                        {
                            linkButton.CssClass = ""; // Reset other categories
                        }
                    }
                }
            }
        }




        private void SetActiveCategory(int categoryId)
        {
            foreach (RepeaterItem item in rptCategories.Items)
            {
                var categoryLink = (LinkButton)item.FindControl("lnkCategory");
                var parentLi = (HtmlControl)item.FindControl("liCategory");

                if (categoryLink != null && parentLi != null)
                {
                    if (Convert.ToInt32(categoryLink.CommandArgument) == categoryId)
                    {
                        // Đánh dấu phần tử <li> là active
                        parentLi.Attributes["class"] = "active";
                    }
                    else
                    {
                        // Bỏ class active
                        parentLi.Attributes["class"] = "";
                    }
                }
            }
        }

        private void LoadProductList(int? categoryId = null)
        {
            // Lấy dữ liệu sản phẩm từ cơ sở dữ liệu
            DataUtilProduct dataUtil = new DataUtilProduct();

            DataTable products;
            if (categoryId.HasValue)
            {
                // Nếu có categoryId, gọi dsProductsByCategory
                products = dataUtil.dsProductsByCategory(categoryId.Value);
            }
            else
            {
                // Nếu không có categoryId, lấy tất cả sản phẩm
                products = dataUtil.dsProductsWithImages();
            }

            string productHtml = string.Empty;

            foreach (DataRow row in products.Rows)
            {
                // Lấy tên ảnh từ cơ sở dữ liệu
                string imagePath = "~/Images/" + row["Image"].ToString();
                string resolvedImagePath = Page.ResolveUrl(imagePath); // Giải quyết đường dẫn tương đối

                // Tạo mã HTML cho từng sản phẩm
                productHtml += $@"
                <div class='col-md-4 col-sm-6 col-xs-12'>
                    <div class='product-item'>
                        <div class='pi-img-wrapper'>
                            <img src='{resolvedImagePath}' class='img-responsive' alt='{row["Name"]}'>
                            <div>
                                <a href='{resolvedImagePath}' class='btn btn-default fancybox-button'>Zoom</a>
                                <a href='#product-pop-up' class='btn btn-default fancybox-fast-view'>View</a>
                            </div>
                        </div>
                        <h3><a href='shop-item.html'>{row["Name"]}</a></h3>
                        <div class='pi-price'>{decimal.Parse(row["Price"].ToString()).ToString("#,0") + " <span class='currency'>đ</span>"}</div>
                        <a href='javascript:;' class='btn btn-default add2cart'>Add to cart</a>
                        <div class='sticker sticker-sale'></div>
                    </div>
                </div>";
            }

            // Gán mã HTML vào phần tử trên trang
            productListDiv.InnerHtml = productHtml;
        }

    }
}