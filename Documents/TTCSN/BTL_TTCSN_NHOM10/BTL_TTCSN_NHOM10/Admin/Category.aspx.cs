using BTL_TTCSN_NHOM10.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_TTCSN_NHOM10.Admin
{
    public partial class Category : System.Web.UI.Page
    {
        DataUtilCategory data = new DataUtilCategory();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            List<Class.Category> categories = data.dsCategories();
            int totalItems = categories.Count;

            grdDs.DataSource =categories;
            grdDs.DataBind();

        }

      

       
        protected void grdDs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int categoryId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditCategory")
            {
                Response.Redirect($"EditCategory.aspx?CategoryId={categoryId}");
            }
            else if (e.CommandName == "DeleteCategory")
            {
                try
                {
                    data.XoaCT(categoryId);
                    BindGridView();
                    // Hiển thị thông báo thành công khi xóa
                    string script = "alert('Xóa danh mục thành công!');";
                    ClientScript.RegisterStartupScript(this.GetType(), "DeleteSuccess", script, true);
                }
                catch (Exception ex){
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", $"alert('Lỗi khi xóa danh mục: {ex.Message}');", true);
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
