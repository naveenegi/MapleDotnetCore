using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibraryCore.DataContextLayer.Models
{
    [Table("CoveragePlan", Schema = "dbo")]
    public class CoveragePlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "CoveragePlanId")]
        public string CoveragePlanId { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "CoveragePlan")]
        public string CoveragePlanName { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        [Display(Name = "EligibilityDateFrom")]
        public string EligibilityDateFrom{ get; set; }


        [Required]
        [Column(TypeName = "datetime")]
        [Display(Name = "EligibilityDateTo")]
        public string EligibilityDateTo { get; set; }


        [Required]
        [Column(TypeName = "varchar(10)")]
        [Display(Name = "EligibilityCountry")]
        public string EligibilityCountry { get; set; }
    }
}
