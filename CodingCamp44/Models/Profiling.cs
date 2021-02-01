using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCamp44.Models
{
    [Table("tb_m_profiling")]

    public class Profiling
    {
        [Key]        
        public string NIK { get; set; }
        [Required]
        public int Education_Id { get; set; }
        [ForeignKey("Education_Id")]
        public virtual Education Education { get; set; }
        public int Job_Id { get; set; }
        [ForeignKey("Job_Id")]
        public virtual Job Job { get; set; }
        public virtual Person Person { get; set; }
    }
}
