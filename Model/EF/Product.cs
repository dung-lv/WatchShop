namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }

        [Key]
        public long ID_Product { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public decimal? Price { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [StringLength(200)]
        public string Avatar { get; set; }

        [Column(TypeName = "xml")]
        public string Images { get; set; }

        public bool? Hot { get; set; }

        [StringLength(100)]
        public string Metatitle { get; set; }

        public long ID_Trademark { get; set; }

        public DateTime? CreateDate { get; set; }

        public long? ID_Promotion { get; set; }

        public decimal? Discount { get; set; }

        public virtual Trademark Trademark { get; set; }

        public virtual Promotion Promotion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
