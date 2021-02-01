using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCamp44.Models
{
    [Table("tb_m_education")]
    public class Education
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int University_Id { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public float GPA { get; set; }
        [ForeignKey("University_Id")]
        public virtual University University { get; set; }
        public virtual List<Profiling> Profiling { get; set; } = new List<Profiling>(); 
    }

    public enum Degree
    {
        D3,
        D4,
        S1, 
        S2,
        S3
    }
}
