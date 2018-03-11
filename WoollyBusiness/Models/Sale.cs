using System;
using System.Collections.Generic;

namespace WoollyBusiness.Models
{
    public partial class Sale
    {
        public Sale()
        {
            SaleDetail = new HashSet<SaleDetail>();
        }

        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public int? CustomerId { get; set; }
        public int SaleSourceId { get; set; }

        public SaleSource SaleSource { get; set; }
        public ICollection<SaleDetail> SaleDetail { get; set; }
    }
}
