using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MYATM2017.Models
{
    public class CheckingAccount 
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="First Name" )]
        public string FirstName { get; set; }
        [Required]
        [Display (Name="Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(10)]
        [Column(TypeName ="varchar")]
        [RegularExpression(@"\d{6,10}", ErrorMessage ="Amount Should be 6-10 digit numeric value.")]
        [Display(Name = "Account #")]
        public string AccountNumber { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Balance { get;  set; }
        public string Name
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }

        public  virtual ApplicationUser User { get; set; }
        [Required]
        public string ApplicationUserId{ get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}