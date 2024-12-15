using BTL_TTCSN_NHOM10.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_TTCSN_NHOM10.Client
{
    public partial class Default : System.Web.UI.Page
    {
        DataUtilProduct dataUtilProduct = new DataUtilProduct();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadNewArrivals(); // Load các sản phẩm mới nhất khi trang được tải lần đầu
            }
        }

        private void LoadNewArrivals()
        {
            try
            {
                // Lấy danh sách sản phẩm mới nhất từ database
                DataTable newArrivals = dataUtilProduct.dsNewArrivals();

                string productHtml = string.Empty;

                foreach (DataRow row in newArrivals.Rows)
                {
                    // Lấy tên ảnh từ cơ sở dữ liệu
                    string imagePath = "~/Images/" + row["Image"].ToString();
                    string resolvedImagePath = Page.ResolveUrl(imagePath); // Giải quyết đường dẫn tương đối

                    // Tạo mã HTML cho từng sản phẩm mới
                    productHtml += $@"
                    <div>
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
                            <div class='sticker sticker-new'></div>
                        </div>
                    </div>";
                }

                // Gán mã HTML vào phần tử trên trang
                productListDiv.InnerHtml = productHtml;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (nếu có)
                Response.Write("<script>alert('Lỗi tải sản phẩm mới: " + ex.Message + "');</script>");
            }
        }
    }
}