using System;
using System.Collections.Generic;

namespace WoollyBusiness.Models
{
    public partial class PurchaseDetail
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public decimal Value { get; set; }
        public int? ItemId { get; set; }
        public string ItemDescription { get; set; }

        public Purchase Purchase { get; set; }
    }
}
