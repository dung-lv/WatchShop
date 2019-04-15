namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        [Key]
        public long ID_Feedback { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }
    }
}
