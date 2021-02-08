using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JQueryAJAX.Models
{
    public class TransationModel
    {
        [Key]
        public int TransitionId { get; set; }
        [MaxLength(12)]
        [Required(ErrorMessage ="This field is required.")]
        [Column(TypeName="nvarchar(12)")]
        [DisplayName("Account Number")]
        public string AccountNumber { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("Beneficiary Name")]
        public string BeneficiaryName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Bank Name")]
        public string BankName { get; set; }
        [MaxLength(11)]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Swift Code")]
        public string SwiftCode { get; set; }

        public int Amount { get; set; }
        [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
    }
}
