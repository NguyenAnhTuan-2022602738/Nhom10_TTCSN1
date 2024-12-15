Use master
go 
create database BTL_TTCSN_NHOM10
go

use BTL_TTCSN_NHOM10
go

--Tạo bảng danh mục
create table Category(
	Category_id int PRIMARY KEY identity,
	Name nvarchar(100) NOT NULL,
	Image nvarchar(MAX) NULL
)

-- Bảng chứa danh mục con
CREATE TABLE SubCategory (
    SubCategory_id INT PRIMARY KEY IDENTITY,
    Name nvarchar(100) NOT NULL,
    Category_id INT FOREIGN KEY REFERENCES Category(Category_id)
);

--Tạo bảng sản phẩm
create table Product(
	Product_id int PRIMARY KEY identity,
	Name nvarchar(100) NOT NULL,
	SKU nvarchar(100) NOT NULL,
	Description nvarchar(MAX) NULL,
	Price decimal(18,2) NOT NULL,
	PriceSale decimal(18,2) NULL,
	Quantity int NOT NULL,
	Category_id int FOREIGN KEY REFERENCES Category(Category_id),
)

select * from Product
delete from Product where Product_id = 1
--Tạo bảng chứa ảnh sản phẩm
create table ProductImage(
	Image_id int identity,
	Image nvarchar(MAX) NULL,
	Product_id int FOREIGN KEY REFERENCES Product(Product_id),
	PRIMARY KEY (Image_id,Product_id)
)

-- Bảng chứa màu sắc
CREATE TABLE Color (
    Color_id INT PRIMARY KEY IDENTITY,
    Color_name nvarchar(100) NOT NULL
);

-- Bảng chứa kích thước
CREATE TABLE Size (
    Size_id INT PRIMARY KEY IDENTITY,
    Size_name nvarchar(50) NOT NULL
);

-- Bảng liên kết sản phẩm với màu sắc và kích thước
CREATE TABLE ProductVariant (
    Variant_id INT PRIMARY KEY IDENTITY,
    Product_id INT FOREIGN KEY REFERENCES Product(Product_id),
    Color_id INT FOREIGN KEY REFERENCES Color(Color_id),
    Size_id INT FOREIGN KEY REFERENCES Size(Size_id),
    Quantity INT NOT NULL,
    Price DECIMAL(18,2) NULL
);
--Tạo bảng quyền
create table Roles(
	Role_id int PRIMARY KEY,
	Name nvarchar(100)
)

--Tạo bảng người dùng
create table Users(
	User_id int PRIMARY KEY identity,
	FullName nvarchar(100) NOT NULL,
	Email nvarchar(100) NOT NULL,
	PassWord nvarchar(100) NOT NULL,
	Address nvarchar(100)  NULL,
	PhoneNumber nvarchar(20) NULL,
	Role_id int FOREIGN KEY REFERENCES Roles(Role_id)
)


--Tạo bảng Giỏ hàng
create table Cart(
	Cart_id int identity,
	Quantity int NOT NULL,
	User_id int FOREIGN KEY REFERENCES Users(User_id),
	Product_id int FOREIGN KEY REFERENCES Product(Product_id),
	PRIMARY KEY (Cart_id, User_id)
)
--Tạo bảng thanh toán
create table Payment(
	Payment_id int PRIMARY KEY identity,
	Payment_date datetime NOT NULL,
	Payment_method nvarchar(100) NOT NULL,
	Amount decimal(18,2) NOT NULL,
	User_id int FOREIGN KEY REFERENCES Users(User_id)
)
--tạo bảng giao hàng
create table Shipment(
	Shipment_id int PRIMARY KEY identity,
	Shipment_date datetime NOT NULL, 
	Address nvarchar(100) NOT NULL,
	City nvarchar(100) NOT NULL,
	State nvarchar(20) NOT NULL,
	Country nvarchar(50) NOT NULL,
	Zip_Code nvarchar(10) NOT NULL,
	User_id int FOREIGN KEY REFERENCES Users(User_id)
)
--Tạo bảng đơn hàng
create table Orders(
	Order_id int PRIMARY KEY identity,
	Order_date datetime NOT NULL,
	Total_price decimal(18,2) NOT NULL,
	User_id int FOREIGN KEY REFERENCES Users(User_id),
	Payment_id int FOREIGN KEY REFERENCES Payment(Payment_id),
	Shipment_id int FOREIGN KEY REFERENCES Shipment(Shipment_id),
)

--Tạo bảng chi tiết đơn hàng
create table Order_Detail(
	Order_Detail_id int identity,
	Quantity int NOT NULL,
	Total_price decimal(18,2) NOT NULL,
	Product_id int FOREIGN KEY REFERENCES Product(Product_id),
	Order_id int FOREIGN KEY REFERENCES Orders(Order_id),
	PRIMARY KEY (Order_Detail_id, Order_id)
)

--Tạo bảng sản phẩm yêu thích
create table Wishlist(
	Wishlist_id int identity,
	User_id int FOREIGN KEY REFERENCES Product(Product_id),
	Product_id int FOREIGN KEY REFERENCES Product(Product_id),
	PRIMARY KEY(Wishlist_id, User_id)
)


Insert into Roles values(1, 'Admin')
Insert into Roles values(2, 'User')


select * from Category

-- Cập nhật bảng Category
ALTER TABLE Category
ADD CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    UpdatedBy NVARCHAR(100) NULL;

-- Cập nhật bảng SubCategory
ALTER TABLE SubCategory
ADD CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    UpdatedBy NVARCHAR(100) NULL;
ALTER TABLE SubCategory
ADD Image nvarchar(MAX) NULL

-- Cập nhật bảng Product
ALTER TABLE Product
ADD CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    UpdatedBy NVARCHAR(100) NULL;

-- Cập nhật bảng ProductImage
ALTER TABLE ProductImage
ADD CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    UpdatedBy NVARCHAR(100) NULL;

-- Cập nhật bảng Color
ALTER TABLE Color
ADD CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    UpdatedBy NVARCHAR(100) NULL;

-- Cập nhật bảng Size
ALTER TABLE Size
ADD CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    UpdatedBy NVARCHAR(100) NULL;

-- Cập nhật bảng ProductVariant
ALTER TABLE ProductVariant
ADD CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    UpdatedBy NVARCHAR(100) NULL;

-- Cập nhật bảng Roles
ALTER TABLE Roles
ADD CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    UpdatedBy NVARCHAR(100) NULL;

-- Cập nhật bảng Users
ALTER TABLE Users
ADD CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    UpdatedBy NVARCHAR(100) NULL;


-- Cập nhật bảng Payment
ALTER TABLE Payment
ADD PaymentBy NVARCHAR(100) NULL;

-- Cập nhật bảng Shipment
ALTER TABLE Shipment
ADD CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    UpdatedBy NVARCHAR(100) NULL;

-- Cập nhật bảng Orders
ALTER TABLE Orders
ADD CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    UpdatedBy NVARCHAR(100) NULL;

-- Cập nhật bảng Order_Detail
ALTER TABLE Order_Detail
ADD CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    UpdatedBy NVARCHAR(100) NULL;

-- Cập nhật bảng Wishlist
ALTER TABLE Wishlist
ADD CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    UpdatedBy NVARCHAR(100) NULL;

INSERT INTO Users (FullName, Email, PassWord, Address, PhoneNumber, Role_id, CreatedDate)
VALUES 
('admin', 'tuannguyen10112004@gmail.com', 'admin', 'Thái Bình', '0354293110', 1, GETDATE()),
('user', 'user@gmail.com', 'user', 'Thái Bình', '987654321', 2, GETDATE());
select * from users
select*from product
select*from ProductImage