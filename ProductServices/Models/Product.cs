using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Models
{
    [Table("TblProduct", Schema = "dbo")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PKID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; }

        public double Price { get; set; }

        [MaxLength(255)]
        public string Descreption { get; set; }

        public int Quantity { get; set; }

        [MaxLength(50)]
        public string CreatedUser { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
