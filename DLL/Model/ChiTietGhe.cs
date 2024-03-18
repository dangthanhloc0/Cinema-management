namespace DLL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietGhe")]
    public partial class ChiTietGhe
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string GheID { get; set; }

        public int TTGID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LCPID { get; set; }

        public virtual Ghe Ghe { get; set; }

        public virtual LichChieuPhim LichChieuPhim { get; set; }

        public virtual LoaiTrangThaiGhe LoaiTrangThaiGhe { get; set; }
    }
}
