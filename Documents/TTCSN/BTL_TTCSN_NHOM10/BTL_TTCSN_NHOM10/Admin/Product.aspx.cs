using BTL_TTCSN_NHOM10.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_TTCSN_NHOM10.Admin
{
    public partial class Product : System.Web.UI.Page
    {
        DataUtilProduct data = new DataUtilProduct();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        //private void BindGridView()
        //{
        //    List<Class.Product> products = data.dsProducts();
        //    int totalItems = products.Count;

        //    grdDs.DataSource = products;
        //    grdDs.DataBind();

        //}
        private void BindGridView()
        {
            DataTable products = data.dsProductsWithImages();
            grdDs.DataSource = products;
            grdDs.DataBind();
        }





        protected void grdDs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int ProductID = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditProduct")
            {
                Response.Redirect($"EditProduct.aspx?ProductID={ProductID}");
            }
            else if (e.CommandName == "DeleteProduct")
            {
                try
                {
                    data.DeleteProduct(ProductID);  // Xóa sản phẩm
                    BindGridView();  // Cập nhật lại GridView

                    // Hiển thị thông báo thành công khi xóa
                    string script = "alert('Sản phẩm đã được xóa thành công!');";
                    ClientScript.RegisterStartupScript(this.GetType(), "DeleteSuccess", script, true);
                }
                catch (Exception ex)
                {
                    // Hiển thị lỗi nếu có vấn đề khi xóa
                    string script = $"alert('Có lỗi xảy ra: {ex.Message}');";
                    ClientScript.RegisterStartupScript(this.GetType(), "DeleteError", script, true);
                }
            }
        }


        protected void grdDs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Nếu cần xử lý thêm cho từng dòng (tùy chọn)
            }
        }

        protected void btnChangePage_Click(object sender, EventArgs e)
        {
            BindGridView();
        }
    }
}