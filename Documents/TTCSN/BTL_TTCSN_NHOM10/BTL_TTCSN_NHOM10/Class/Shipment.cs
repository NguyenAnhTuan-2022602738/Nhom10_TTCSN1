using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_TTCSN_NHOM10.Class
{
    public class Shipment
    {
        public int Shipment_id { get; set; }
        public DateTime Shipment_date { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip_Code { get; set; }
        public int User_id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public Shipment() { }
        public Shipment(int shipmentId, DateTime shipmentDate, string address, string city, string state, string country, string zipCode, int userId, DateTime createdDate, DateTime? updatedDate, string updatedBy)
        {
            Shipment_id = shipmentId;
            Shipment_date = shipmentDate;
            Address = address;
            City = city;
            State = state;
            Country = country;
            Zip_Code = zipCode;
            User_id = userId;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            UpdatedBy = updatedBy;
        }
    }
}