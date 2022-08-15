using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServices.Models
{
    [Table("TblOrder", Schema = "dbo")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("order_id")]
        public int OrderID { get; set; }

        [MaxLength(50)]
        [Column("order_name")]
        public string OrderName { get; set; }

        [MaxLength(50)]
        [Column("customer")]
        public string Customer { get; set; }

        [MaxLength(50)]
        [Column("product")]
        public string Product { get; set; }

        public int Amount { get; set; }

        [MaxLength(50)]
        [Column("createdUser")]
        public string CreatedUser { get; set; }

        [Required]
        [Column("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}
