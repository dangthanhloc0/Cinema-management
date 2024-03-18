namespace DLL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinVe")]
    public partial class ThongTinVe
    {
        [Key]
        public int TTVID { get; set; }

        public int LCPid { get; set; }

        public int VeID { get; set; }

        [Required]
        [StringLength(50)]
        public string GheID { get; set; }

        public virtual Ghe Ghe { get; set; }

        public virtual LichChieuPhim LichChieuPhim { get; set; }

        public virtual Ve Ve { get; set; }
    }
}
