using System.ComponentModel.DataAnnotations;

namespace pertemuan_2.Models.DB
{
    public class Items
    {
        public int Id { get; set; }

        // Validasi untuk NamaItem
        [Required(ErrorMessage = "Nama Item wajib diisi.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nama Item harus memiliki panjang antara 3 hingga 100 karakter.")]
        public string NamaItem { get; set; }

        // Validasi untuk Qty (Qty harus lebih besar dari 0 dan tidak lebih dari 10.000)
        [Required(ErrorMessage = "Qty wajib diisi.")]
        [Range(1, 10000, ErrorMessage = "Qty harus antara 1 dan 10,000.")]
        public int Qty { get; set; }

        // Validasi untuk TglExpire (Tanggal harus lebih besar dari hari ini)
        [Required(ErrorMessage = "Tanggal kadaluarsa wajib diisi.")]
        [DataType(DataType.Date, ErrorMessage = "Format tanggal tidak valid.")]
        [CustomValidation(typeof(Items), nameof(ValidateTglExpire))]
        public DateTime TglExpire { get; set; }

        // Validasi untuk Supplier (Supplier wajib diisi dan maksimal 100 karakter)
        [Required(ErrorMessage = "Nama Supplier wajib diisi.")]
        [StringLength(100, ErrorMessage = "Nama Supplier maksimal 100 karakter.")]
        public string Supplier { get; set; }

        // Validasi untuk AlamatSupplier (Alamat optional, maksimal 100 karakter)
        [StringLength(100, ErrorMessage = "Alamat Supplier maksimal 100 karakter.")]
        public string? AlamatSupplier { get; set; }

        // Validasi kustom untuk TglExpire agar tidak kurang dari hari ini
        public static ValidationResult? ValidateTglExpire(DateTime tglExpire, ValidationContext context)
        {
            if (tglExpire <= DateTime.Today)
            {
                return new ValidationResult("Tanggal kadaluarsa harus lebih besar dari tanggal hari ini.");
            }
            return ValidationResult.Success;
        }
    }
}

