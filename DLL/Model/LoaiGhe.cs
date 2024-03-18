namespace DLL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiGhe")]
    public partial class LoaiGhe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiGhe()
        {
            Ghes = new HashSet<Ghe>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LoaiGheID { get; set; }

        [StringLength(50)]
        public string TenLoai { get; set; }

        public int Gia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ghe> Ghes { get; set; }
    }
}
