namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        public long ID_OrderDetail { get; set; }

        public long ID_Order { get; set; }

        public int? Quantity { get; set; }

        public int? TotalPrice { get; set; }

        public long? ID_ProductDetail { get; set; }

        public virtual Order Order { get; set; }

        public virtual ProductDetail ProductDetail { get; set; }
    }
}
