using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCamp44.Models
{
    [Table("tb_m_account")]
    public class Account
    {
        [Key, Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(10, ErrorMessage = "Maksimal 10 karakter"), MinLength(5, ErrorMessage = "Minimal 5 karakter"), RegularExpression(@"^\d+$", ErrorMessage = "Harus berupa angka")]
        public string NIK { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"),DataType(DataType.Password)]
        public string Password { get; set; }
        public StatusAccount Status { get; set; }
        public virtual Person Person { get; set; }
    }

    public enum StatusAccount
    {
        Active,
        Banned,
        One_False,
        Two_False
    }
}

