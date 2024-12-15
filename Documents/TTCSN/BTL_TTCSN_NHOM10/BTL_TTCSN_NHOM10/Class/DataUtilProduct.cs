using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web;

namespace BTL_TTCSN_NHOM10.Class
{
    public class DataUtilProduct
    {
        SqlConnection con;

        public DataUtilProduct()
        {
            string sqlCon = @"Data Source=MSI;Initial Catalog=BTL_TTCSN_NHOM10;Integrated Security=True";
            con = new SqlConnection(sqlCon);
        }

        // Fetch all products
        public List<Product> dsProducts()
        {
            List<Product> products = new List<Product>();
            string sql = "SELECT * FROM Product";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Product product = new Product
                {
                    Product_id = (int)rd["Product_id"],
                    Name = (string)rd["Name"],
                    SKU = (string)rd["SKU"],
                    Description = rd["Description"] != DBNull.Value ? (string)rd["Description"] : null,
                    Price = (decimal)rd["Price"],
                    PriceSale = rd["PriceSale"] != DBNull.Value ? (decimal?)rd["PriceSale"] : null,
                    Quantity = (int)rd["Quantity"],
                    Category_id = (int)rd["Category_id"],
                    CreatedDate = rd["CreatedDate"] != DBNull.Value ? (DateTime)rd["CreatedDate"] : (DateTime?)null,
                    UpdatedDate = rd["UpdatedDate"] != DBNull.Value ? (DateTime)rd["UpdatedDate"] : (DateTime?)null,
                    UpdatedBy = rd["UpdatedBy"] != DBNull.Value ? (string)rd["UpdatedBy"] : null
                };
                products.Add(product);
            }
            con.Close();
            return products;
        }

        // Check if a product name already exists
        public bool CheckProductNameExists(string name)
        {
            con.Open();
            string sql = "SELECT COUNT(*) FROM Product WHERE Name = @Name";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", name);
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count > 0;
        }

        // Get product by Id
        public Product GetProductById(int productId)
        {
            con.Open();
            string sql = "SELECT * FROM Product WHERE Product_id = @ProductId";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            Product product = null;
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                product = new Product
                {
                    Product_id = (int)rd["Product_id"],
                    Name = (string)rd["Name"],
                    SKU = (string)rd["SKU"],
                    Description = rd["Description"] != DBNull.Value ? (string)rd["Description"] : null,
                    Price = (decimal)rd["Price"],
                    PriceSale = rd["PriceSale"] != DBNull.Value ? (decimal?)rd["PriceSale"] : null,
                    Quantity = (int)rd["Quantity"],
                    Category_id = (int)rd["Category_id"],
                    CreatedDate = rd["CreatedDate"] != DBNull.Value ? (DateTime)rd["CreatedDate"] : (DateTime?)null,
                    UpdatedDate = rd["UpdatedDate"] != DBNull.Value ? (DateTime)rd["UpdatedDate"] : (DateTime?)null,
                    UpdatedBy = rd["UpdatedBy"] != DBNull.Value ? (string)rd["UpdatedBy"] : null
                };
            }
            con.Close();
            return product;
        }

        // Add a new product
        public void AddProduct(Product product)
        {
            if (CheckProductNameExists(product.Name))
            {
                throw new Exception("Product name already exists.");
            }

            con.Open();
            string sql = "INSERT INTO Product (Name, SKU,Description, Price, PriceSale, Quantity, Category_id, CreatedDate, UpdatedDate, UpdatedBy) " +
                         "VALUES (@Name, @SKU, @Description, @Price, @PriceSale, @Quantity, @Category_id, @CreatedDate, @UpdatedDate, @UpdatedBy)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@SKU", product.SKU);
            cmd.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@PriceSale", product.PriceSale ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@Category_id", product.Category_id);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedDate", product.UpdatedDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@UpdatedBy", product.UpdatedBy ?? "Admin");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void AddProduct(Product product, List<ProductImage> productImages)
        {
            if (CheckProductNameExists(product.Name))
            {
                throw new Exception("Tên sản phẩm đã tồn tại trong cơ sở dữ liệu!");
            }

            con.Open();
            string sql = "INSERT INTO Product (Name, SKU, Description, Price, PriceSale, Quantity, Category_id, CreatedDate, UpdatedDate, UpdatedBy) " +
                         "VALUES (@Name, @SKU, @Description, @Price, @PriceSale, @Quantity, @Category_id, @CreatedDate, @UpdatedDate, @UpdatedBy)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@SKU", product.SKU);
            cmd.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@PriceSale", product.PriceSale ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@Category_id", product.Category_id);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedDate", product.UpdatedDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@UpdatedBy", product.UpdatedBy ?? "Admin");

            cmd.ExecuteNonQuery();
            con.Close();

            // Sau khi thêm sản phẩm, thêm các hình ảnh liên quan
            int productId = GetProductIdByName(product.Name); // Cần một phương thức để lấy ID của sản phẩm vừa thêm

            foreach (var image in productImages)
            {
                image.Product_id = productId; // Gắn ID sản phẩm vào hình ảnh
                AddProductImage(image);
            }
        }

        public int GetProductIdByName(string productName)
        {
            con.Open();
            string sql = "SELECT Product_id FROM Product WHERE Name = @Name";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", productName);

            int productId = 0;
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                productId = (int)rd["Product_id"];
            }
            con.Close();
            return productId;
        }

        // Update an existing product
        public void UpdateProduct(Product product)
        {
            if (CheckProductNameExists(product.Name, product.Product_id))
            {
                throw new Exception("Tên sản phẩm đã tồn tại trong cơ sở dữ liệu!");
            }
            con.Open();
            string sql = "UPDATE Product SET Name = @Name, SKU = @SKU, Description = @Description, Price = @Price, PriceSale = @PriceSale, " +
                         "Quantity = @Quantity, Category_id = @Category_id, UpdatedDate = @UpdatedDate, UpdatedBy = @UpdatedBy WHERE Product_id = @ProductId";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ProductId", product.Product_id);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@SKU", product.SKU);
            cmd.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@PriceSale", product.PriceSale ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@Category_id", product.Category_id);
            cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedBy", product.UpdatedBy ?? "Admin");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public bool CheckProductNameExists(string productName, int productId)
        {
            con.Open();
            string sql = "SELECT COUNT(*) FROM Product WHERE Name = @Name AND Product_id != @ProductId";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", productName);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count > 0;
        }

        // Delete a product along with its images
        public void DeleteProduct(int productId)
        {
            // Xóa các hình ảnh liên quan đến sản phẩm
            con.Open();
            string deleteImagesSql = "DELETE FROM ProductImage WHERE Product_id = @ProductId";
            SqlCommand deleteImagesCmd = new SqlCommand(deleteImagesSql, con);
            deleteImagesCmd.Parameters.AddWithValue("@ProductId", productId);
            deleteImagesCmd.ExecuteNonQuery();
            con.Close();

            // Xóa sản phẩm
            con.Open();
            string deleteProductSql = "DELETE FROM Product WHERE Product_id = @ProductId";
            SqlCommand deleteProductCmd = new SqlCommand(deleteProductSql, con);
            deleteProductCmd.Parameters.AddWithValue("@ProductId", productId);
            deleteProductCmd.ExecuteNonQuery();
            con.Close();
        }


        public void AddProductImage(ProductImage productImage)
        {
            con.Open();
            string sql = "INSERT INTO ProductImage (Image, Product_id, CreatedDate, UpdatedDate, UpdatedBy) " +
                         "VALUES (@Image, @Product_id, @CreatedDate, @UpdatedDate, @UpdatedBy)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Image", productImage.Image);
            cmd.Parameters.AddWithValue("@Product_id", productImage.Product_id);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedDate", productImage.UpdatedDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@UpdatedBy", productImage.UpdatedBy ?? "Admin");
            cmd.ExecuteNonQuery();
            con.Close();
        }



        public int intAddProduct(Product product)
        {
            if (CheckProductNameExists(product.Name))
            {
                throw new Exception("Tên sản phẩm đã tồn tại trong cơ sở dữ liệu!");
            }

            con.Open();
            string sql = "INSERT INTO Product (Name, SKU, Description, Price, PriceSale, Quantity, Category_id, CreatedDate, UpdatedDate, UpdatedBy) " +
                         "OUTPUT INSERTED.Product_id " + // Lấy ID của bản ghi vừa thêm
                         "VALUES (@Name, @SKU, @Description, @Price, @PriceSale, @Quantity, @Category_id, @CreatedDate, @UpdatedDate, @UpdatedBy)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@SKU", product.SKU);
            cmd.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@PriceSale", product.PriceSale ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@Category_id", product.Category_id);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedDate", product.UpdatedDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@UpdatedBy", product.UpdatedBy ?? "Admin");

            int productId = (int)cmd.ExecuteScalar(); // Lấy ID của sản phẩm mới
            con.Close();
            return productId; // Trả về Product_id
        }       

        public DataTable dsProductsWithImages()
        {
            DataTable dataTable = new DataTable();

            string sql = @"
                        SELECT p.Product_id, p.Name, p.SKU, p.Description, p.Price, p.PriceSale, p.Quantity, p.Category_id, 
                               p.CreatedDate, p.UpdatedDate, 
                               (SELECT TOP 1 pi.Image FROM ProductImage pi WHERE pi.Product_id = p.Product_id ORDER BY pi.CreatedDate ASC) AS Image
                        FROM Product p";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
            }

            return dataTable;
        }


        public DataTable dsProductsByCategory(int categoryId)
        {
            DataTable dataTable = new DataTable();

            string sql = @"
                SELECT p.Product_id, p.Name, p.SKU, p.Description, p.Price, p.PriceSale, p.Quantity, p.Category_id, 
                       p.CreatedDate, p.UpdatedDate, 
                       (SELECT TOP 1 pi.Image FROM ProductImage pi WHERE pi.Product_id = p.Product_id ORDER BY pi.CreatedDate ASC) AS Image
                FROM Product p
                WHERE p.Category_id = @CategoryId";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
            }

            return dataTable;
        }
        

        public List<ProductImage> GetProductImages(int productId)
        {
            List<ProductImage> productImages = new List<ProductImage>();

            con.Open();
            string sql = "SELECT * FROM ProductImage WHERE Product_id = @ProductId";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                Class.ProductImage productImage = new Class.ProductImage
                {
                    Image_id = (int)rd["Image_id"],
                    Product_id = (int)rd["Product_id"],
                    Image = rd["Image"].ToString(),
                    CreatedDate = (DateTime)rd["CreatedDate"],
                    UpdatedDate = rd["UpdatedDate"] != DBNull.Value ? (DateTime?)rd["UpdatedDate"] : null,
                    UpdatedBy = rd["UpdatedBy"].ToString()
                };
                productImages.Add(productImage);
            }

            con.Close();
            return productImages;
        }

        //public void UpdateProductImage(ProductImage productImage)
        //{
        //    con.Open();
        //    string sql = "UPDATE ProductImage SET Image = @Image, UpdatedDate = @UpdatedDate, UpdatedBy = @UpdatedBy WHERE ImageId = @ImageId";
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("@Image", productImage.Image);
        //    cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
        //    cmd.Parameters.AddWithValue("@UpdatedBy", productImage.UpdatedBy ?? "Admin");
        //    cmd.Parameters.AddWithValue("@ImageId", productImage.Image_id);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}

        public void UpdateProductImage(ProductImage productImage)
        {
            try
            {
                con.Open();
                string sql = "UPDATE ProductImage SET Image = @Image, UpdatedDate = @UpdatedDate, UpdatedBy = @UpdatedBy WHERE Image_id = @ImageId";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Image", productImage.Image);
                cmd.Parameters.AddWithValue("@UpdatedDate", productImage.UpdatedDate ?? DateTime.Now);
                cmd.Parameters.AddWithValue("@UpdatedBy", productImage.UpdatedBy ?? "Admin");
                cmd.Parameters.AddWithValue("@ImageId", productImage.Image_id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating product image: " + ex.Message);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }


        public void DeleteProductImage(int imageId)
        {
            con.Open();
            string sql = "DELETE FROM ProductImage WHERE Image_id = @ImageId";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ImageId", imageId);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        //Lưu ảnh
        public string SaveImageToFileSystem(FileUpload fileUpload)
        {
            if (fileUpload.HasFile)
            {
                string folderPath = HttpContext.Current.Server.MapPath("~/Uploads/Images/");
                if (!System.IO.Directory.Exists(folderPath))
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                }

                // Đặt tên file duy nhất (nếu cần tránh trùng)
                string fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(fileUpload.FileName);
                string filePath = folderPath + fileName;

                fileUpload.SaveAs(filePath);

                // Trả về đường dẫn tương đối để lưu trong DB
                return "~/Images/" + fileName;
            }

            return null;
        }

        public List<Product> dsProducts(string sortBy = "Name", string sortOrder = "ASC")
        {
            List<Product> products = new List<Product>();

            // Kiểm tra hợp lệ của tham số sortBy và sortOrder
            if (!new List<string> { "Name", "Price", "CreatedDate", "UpdatedDate" }.Contains(sortBy))
            {
                throw new ArgumentException("Invalid sort criteria");
            }

            if (!new List<string> { "ASC", "DESC" }.Contains(sortOrder))
            {
                throw new ArgumentException("Invalid sort order");
            }

            // Tạo câu SQL với tiêu chí sắp xếp
            string sql = $"SELECT * FROM Product ORDER BY {sortBy} {sortOrder}";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                Product product = new Product
                {
                    Product_id = (int)rd["Product_id"],
                    Name = (string)rd["Name"],
                    SKU = (string)rd["SKU"],
                    Description = rd["Description"] != DBNull.Value ? (string)rd["Description"] : null,
                    Price = (decimal)rd["Price"],
                    PriceSale = rd["PriceSale"] != DBNull.Value ? (decimal?)rd["PriceSale"] : null,
                    Quantity = (int)rd["Quantity"],
                    Category_id = (int)rd["Category_id"],
                    CreatedDate = rd["CreatedDate"] != DBNull.Value ? (DateTime)rd["CreatedDate"] : (DateTime?)null,
                    UpdatedDate = rd["UpdatedDate"] != DBNull.Value ? (DateTime)rd["UpdatedDate"] : (DateTime?)null,
                    UpdatedBy = rd["UpdatedBy"] != DBNull.Value ? (string)rd["UpdatedBy"] : null
                };
                products.Add(product);
            }
            con.Close();
            return products;
        }

        public DataTable dsNewArrivals()
        {
            DataTable dataTable = new DataTable();

            string sql = @"
            SELECT TOP 5 p.Product_id, p.Name, p.SKU, p.Description, p.Price, p.PriceSale, p.Quantity, p.Category_id, 
                   p.CreatedDate, p.UpdatedDate, 
                   (SELECT TOP 1 pi.Image FROM ProductImage pi WHERE pi.Product_id = p.Product_id ORDER BY pi.CreatedDate ASC) AS Image
            FROM Product p
            ORDER BY p.CreatedDate DESC"; // Lấy 5 sản phẩm mới nhất

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
            }

            return dataTable;
        }

        //đếm người dùng
        public int GetProductCount()
        {
            int ProductCount = 0;

            try
            {
                con.Open();
                string sql = "SELECT COUNT(*) FROM Product"; // Đếm tất cả các user trong bảng Users
                SqlCommand cmd = new SqlCommand(sql, con);

                ProductCount = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error counting users: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return ProductCount;
        }

        public Dictionary<string, int> GetProductCountByCategory()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();

            try
            {
                con.Open();
                string sql = @"
            SELECT c.Name, COUNT(p.Product_id) AS ProductCount
            FROM Category c
            LEFT JOIN Product p ON c.Category_id = p.Category_id
            GROUP BY c.Name";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string categoryName = reader["Name"].ToString();
                    int productCount = Convert.ToInt32(reader["ProductCount"]);
                    data.Add(categoryName, productCount);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching product count by category: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return data;
        }



    }
}
