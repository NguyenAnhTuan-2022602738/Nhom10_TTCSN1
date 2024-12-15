using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BTL_TTCSN_NHOM10.Class
{
    public class DataUtilCategory
    {
        SqlConnection con;

        public DataUtilCategory()
        {
            string sqlCon = @"Data Source=MSI;Initial Catalog=BTL_TTCSN_NHOM10;Integrated Security=True;";
            con = new SqlConnection(sqlCon);
        }

        public List<Category> dsCategories()
        {
            List<Category> ds = new List<Category>();
            string sql = "select * from Category";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Category ct = new Category();
                ct.Category_id = (int)rd["Category_id"];
                ct.Name = (string)rd["Name"];
                ct.Image = rd["Image"] != DBNull.Value ? (string)rd["Image"] : null;
                ct.CreatedDate = rd["CreatedDate"] != DBNull.Value ? (DateTime)rd["CreatedDate"] : DateTime.MinValue;
                ct.UpdatedDate = rd["UpdatedDate"] != DBNull.Value ? (DateTime)rd["UpdatedDate"] : DateTime.MinValue;
                ds.Add(ct);
            }
            con.Close();
            return ds;
        }

        //public List<Category> dsCategories(int pageIndex, int pageSize)
        //{
        //    List<Category> ds = new List<Category>();
        //    string sql = "SELECT * FROM Category ORDER BY Category_id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("@Offset", pageIndex * pageSize);  // Tính toán số lượng bản ghi bỏ qua
        //    cmd.Parameters.AddWithValue("@PageSize", pageSize);  // Số lượng bản ghi trên mỗi trang
        //    SqlDataReader rd = cmd.ExecuteReader();
        //    while (rd.Read())
        //    {
        //        Category ct = new Category();
        //        ct.Category_id = (int)rd["Category_id"];
        //        ct.Name = (string)rd["Name"];
        //        ct.Image = rd["Image"] != DBNull.Value ? (string)rd["Image"] : null;
        //        ct.CreatedDate = rd["CreatedDate"] != DBNull.Value ? (DateTime)rd["CreatedDate"] : DateTime.MinValue;
        //        ct.UpdatedDate = rd["UpdatedDate"] != DBNull.Value ? (DateTime)rd["UpdatedDate"] : DateTime.MinValue;
        //        ds.Add(ct);
        //    }
        //    con.Close();
        //    return ds;
        //}

        public int GetTotalRecordCount()
        {
            int totalItems = 0;
            string sql = "SELECT COUNT(*) FROM Category";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            totalItems = (int)cmd.ExecuteScalar();
            con.Close();
            return totalItems;
        }


        public bool KiemTraTenDanhMuc(string name)
        {
            con.Open();
            string sql = "select count(*) from Category where Name = @Name";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("Name", name);
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count > 0;
        }

        public Category Layra1DM(int Category_id)
        {
            con.Open();
            string sql = "select * from Category where Category_id=@Category_id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("Category_id", Category_id);
            Category ct = null;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ct = new Category();
                ct.Category_id = (int)rd["Category_id"];
                ct.Name = (string)rd["Name"];
                ct.Image = rd["Image"] != DBNull.Value ? (string)rd["Image"] : null;
                ct.CreatedDate = rd["CreatedDate"] != DBNull.Value ? (DateTime)rd["CreatedDate"] : DateTime.MinValue;
                ct.UpdatedDate = rd["UpdatedDate"] != DBNull.Value ? (DateTime)rd["UpdatedDate"] : DateTime.MinValue;
            }
            con.Close();
            return ct;
        }

        public void SuaDM(Category ct)
        {
            if (CheckCategoryNameExist(ct.Name, ct.Category_id))
            {
                throw new Exception("Tên danh mục đã tồn tại trong cơ sở dữ liệu.");
            }
            con.Open();
            string sql = "UPDATE Category SET Name = @Name, Image = @Image, UpdatedDate = @UpdatedDate, UpdatedBy = @UpdatedBy WHERE Category_id = @Category_id";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("Category_id", ct.Category_id);
            cmd.Parameters.AddWithValue("Name", ct.Name);
            cmd.Parameters.AddWithValue("Image", ct.Image);
            cmd.Parameters.AddWithValue("UpdatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("UpdatedBy", "Admin");
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public bool CheckCategoryNameExist(string categoryName, int categoryId)
        {
            con.Open();
            string sql = "SELECT COUNT(*) FROM Category WHERE Name = @Name AND Category_id != @Category_id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", categoryName);
            cmd.Parameters.AddWithValue("@Category_id", categoryId);
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count > 0;
        }



        public void ThemCT(Category ct)
        {
            if (KiemTraTenDanhMuc(ct.Name))
            {
                throw new Exception("Tên danh mục đã tồn tại trong cơ sở dữ liệu.");
            }

            con.Open();
            string sql = "INSERT INTO Category (Name, Image, CreatedDate, UpdatedDate, UpdatedBy) VALUES (@Name, @Image, @CreatedDate, @UpdatedDate, @UpdatedBy)";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("Name", ct.Name);
            cmd.Parameters.AddWithValue("Image", ct.Image);
            cmd.Parameters.AddWithValue("CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("UpdatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("UpdatedBy", "Admin");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void XoaCT(int Category_id)
        {
            con.Open();
            string sql = "DELETE FROM Category WHERE Category_id=@Category_id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("Category_id", Category_id);
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
