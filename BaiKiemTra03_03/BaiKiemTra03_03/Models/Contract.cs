using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BaiKiemTra03_03.Models
{
    public class Contract
    {
        [Key]
        public int ContractId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContractName { get; set; }

        [Required]
        public DateTime SigningDate { get; set; }

        [Required]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        [ValidateNever]
        public Customer Custmer { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ContractValue { get; set; }

      
        
    }
}
