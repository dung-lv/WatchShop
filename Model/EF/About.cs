namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("About")]
    public partial class About
    {
        [Key]
        public long ID_About { get; set; }

        [Column(TypeName = "ntext")]
        public string Header { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        [StringLength(200)]
        public string Title_Body { get; set; }

        [Column(TypeName = "ntext")]
        public string Body { get; set; }

        [StringLength(200)]
        public string Title_Guarantee { get; set; }

        [Column(TypeName = "ntext")]
        public string Guarantee { get; set; }
    }
}
