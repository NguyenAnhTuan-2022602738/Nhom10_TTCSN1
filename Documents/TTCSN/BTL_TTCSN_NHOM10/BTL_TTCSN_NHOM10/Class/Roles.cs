using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_TTCSN_NHOM10.Class
{
    public class Roles
    {
        public int Role_id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public Roles() { }
        public Roles(int roleId, string name, DateTime createdDate, DateTime? updatedDate, string updatedBy)
        {
            Role_id = roleId;
            Name = name;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            UpdatedBy = updatedBy;
        }
    }
}