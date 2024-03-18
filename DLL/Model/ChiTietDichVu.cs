namespace DLL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDichVu")]
    public partial class ChiTietDichVu
    {
        [Key]
        public int CTDVID { get; set; }

        public int VeID { get; set; }

        public int DichVuID { get; set; }

        [Column("Số lượng")]
        public int Số_lượng { get; set; }

        [Column("Thành tiền")]
        public double Thành_tiền { get; set; }

        public virtual DichVu DichVu { get; set; }

        public virtual Ve Ve { get; set; }
    }
}
