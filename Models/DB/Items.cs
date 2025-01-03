using System.ComponentModel.DataAnnotations;

namespace pertemuan_2.Models.DB
{
    public class Items
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NamaItem { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        public DateTime TglExpire { get; set; }

        [Required]
        [StringLength(100)]
        public string Supplier { get; set; }

        [StringLength(100)]
        public string? AlamatSupplier { get; set; }
    }
}
