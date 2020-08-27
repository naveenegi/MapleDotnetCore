using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ClassLibraryCore.DataContextLayer.Models
{
    [Table("Contracts", Schema = "dbo")]
    public  class Contracts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "CustomerId")]
        public string CustomerId { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "CustomerName")]
        public string CustomerName { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "CustomerAddress")]
        public string CustomerAddress { get; set; }

        [Required]
        [Column(TypeName = "char(1)")]
        [Display(Name = "CustomerGender")]
        public string CustomerGender { get; set; }


        [Required]
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "CustomerCountry")]
        public string CustomerCountry { get; set; }


        [Required]
        [Column(TypeName = "datetime")]
        [Display(Name = "CustomerDOB")]
        public string CustomerDOB { get; set; }


        [Required]
        [Column(TypeName = "datetime")]
        [Display(Name = "SaleDate")]
        public string SaleDate { get; set; }


        [Required]
        [Column(TypeName = "varchar(10)")]
        [Display(Name = "CoveragePlan")]
        public string CoveragePlan { get; set; }


        [Required]
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "NetPrice")]
        public string NetPrice { get; set; }

    }
}
