using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCamp44.Models
{
    [Table("tb_m_job")]
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Profession { get; set; }
        public virtual List<Profiling> Profilings { get; set; } = new List<Profiling>();
    }
}