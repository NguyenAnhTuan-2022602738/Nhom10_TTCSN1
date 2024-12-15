using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace BTL_TTCSN_NHOM10.Class
{
    public class DataUtilUser
    {
        SqlConnection con;
        public DataUtilUser()
        {
            string sqlCon = @"Data Source=MSI;Initial Catalog=BTL_TTCSN_NHOM10;Integrated Security=True";
            con = new SqlConnection(sqlCon);
        }

        // Hàm kiểm tra tài khoản đăng nhập
        public Users ValidateUser(string email, string password)
        {
            Users user = null;

            try
            {
                con.Open();
                string sql = "SELECT * FROM Users WHERE Email = @Email AND PassWord = @PassWord";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PassWord", password);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new Users
                    {
                        User_id = Convert.ToInt32(reader["User_id"]),
                        FullName = reader["FullName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PassWord = reader["PassWord"].ToString(),
                        Address = reader["Address"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Role_id = Convert.ToInt32(reader["Role_id"]),
                        CreatedDate = reader["CreatedDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["CreatedDate"]) : null,
                        UpdatedDate = reader["UpdatedDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["UpdatedDate"]) : null,
                        UpdatedBy = reader["UpdatedBy"]?.ToString()
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error validating user: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return user;
        }

        // Kiểm tra xem email đã tồn tại chưa
        public bool CheckEmailExists(string email)
        {
            bool exists = false;

            try
            {
                con.Open();
                string sql = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", email);

                int count = (int)cmd.ExecuteScalar();
                exists = count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking email existence: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return exists;
        }

        // Đăng ký người dùng mới
        public bool RegisterUser(Users user)
        {
            try
            {
                con.Open();
                string sql = "INSERT INTO Users (FullName, Email, PassWord, PhoneNumber, Address, Role_id, CreatedDate) " +
                             "VALUES (@FullName, @Email, @PassWord, @PhoneNumber, @Address, @Role_id, @CreatedDate)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@PassWord", user.PassWord); // Lưu mật khẩu chưa mã hóa (có thể mã hóa nếu cần)
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@Role_id", user.Role_id);
                cmd.Parameters.AddWithValue("@CreatedDate", user.CreatedDate);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error registering user: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        //đếm người dùng
        public int GetUserCount()
        {
            int userCount = 0;

            try
            {
                con.Open();
                string sql = "SELECT COUNT(*) FROM Users"; // Đếm tất cả các user trong bảng Users
                SqlCommand cmd = new SqlCommand(sql, con);

                userCount = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error counting users: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return userCount;
        }
    }
}