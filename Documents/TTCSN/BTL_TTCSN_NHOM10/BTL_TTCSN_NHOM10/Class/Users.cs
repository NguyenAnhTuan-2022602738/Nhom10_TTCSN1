using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_TTCSN_NHOM10.Class
{
    public class Users
    {
        public int User_id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Role_id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public Users() { }
        public Users(int userId, string fullName, string email, string password, string address, string phoneNumber, int roleId, DateTime createdDate, DateTime? updatedDate, string updatedBy)
        {
            User_id = userId;
            FullName = fullName;
            Email = email;
            PassWord = password;
            Address = address;
            PhoneNumber = phoneNumber;
            Role_id = roleId;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            UpdatedBy = updatedBy;
        }
    }
}