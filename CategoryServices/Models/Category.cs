using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryServices.Models
{
    //Create Table Category
    [Table("TblCategory", Schema = "dbo")]

    public class Category
    {
        //Set CategoryID is Key of table
        [Key]
        //Set value of field CategoryID is identity
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("category_id")]
        public int CategoryID { get; set; }

        [MaxLength(50)]
        [Column("category_name")]
        public string CategoryName { get; set; }


        [Column("descreption", TypeName = "NVARCHAR")]
        [MaxLength(255)]
        public string Description { get; set; }

        [MaxLength(50)]
        [Column("createdUser")]
        public string CreatedUser { get; set; }

        [Required]
        [Column("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}
