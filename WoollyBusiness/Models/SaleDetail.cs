using System;
using System.Collections.Generic;

namespace WoollyBusiness.Models
{
    public partial class SaleDetail
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public decimal Value { get; set; }
        public int? ItemId { get; set; }
        public string ItemDescription { get; set; }

        public Sale Item { get; set; }
    }
}
