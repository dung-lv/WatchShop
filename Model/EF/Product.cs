namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public long ID_Product { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public decimal? Price { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [StringLength(200)]
        public string Avatar { get; set; }

        public int? Quantity { get; set; }

        public bool? Hot { get; set; }

        public decimal? Discount { get; set; }

        [StringLength(100)]
        public string Metatitle { get; set; }

        public DateTime? CreateDate { get; set; }

        public long ID_Trademark { get; set; }

        public long? ID_Promotion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Trademark Trademark { get; set; }

        public virtual Promotion Promotion { get; set; }
    }
}
