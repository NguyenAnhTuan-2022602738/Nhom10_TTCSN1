using BTL_TTCSN_NHOM10.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_TTCSN_NHOM10.Client
{
    
    public partial class ClientMasterPage : System.Web.UI.MasterPage
    {
        private DataUtilCategory dataUtilCategory = new DataUtilCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
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
    }
}