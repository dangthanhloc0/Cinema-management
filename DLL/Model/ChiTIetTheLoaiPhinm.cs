namespace DLL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTIetTheLoaiPhinm")]
    public partial class ChiTIetTheLoaiPhinm
    {
        public int CTTLPID { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PhimID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TheLoaiID { get; set; }

        public virtual TheLoaiPhim TheLoaiPhim { get; set; }

        public virtual ThongtinPhim ThongtinPhim { get; set; }
    }
}
