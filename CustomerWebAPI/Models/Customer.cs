using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWebAPI.Models
{
    [Table("TblCustomer", Schema = "dbo")]
    public class Customer
    {
        //Set CustomerID is Key of table
        [Key]
        //Set value of field CustomerID is identity
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("customer_id")]
        public int CustomerID { get; set; }

        [Column("customer_name")]
        public string CustomerName { get; set; }

        [Column("mobile_no")]
        public string MobileNumber { get; set; }

        [Column("email")]
        public string Email { get; set; }
    }
}
