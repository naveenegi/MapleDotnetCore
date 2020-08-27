using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibraryCore.DataContextLayer.Models
{
   public class RateChart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "RateChartId")]
        public int RateChartId { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "CoveragePlan")]
        public string CoveragePlanName { get; set; }
        [Required]
        [Column(TypeName = "char(1)")]
        [Display(Name = "CustomerGender")]
        public string CustomerGender { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "CustomerAge")]
        public string CustomerAge { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "NetPrice")]
        public string NetPrice { get; set; }
    }
}
