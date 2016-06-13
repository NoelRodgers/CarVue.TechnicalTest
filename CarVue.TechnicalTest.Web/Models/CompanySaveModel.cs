using System.ComponentModel.DataAnnotations;

namespace CarVue.TechnicalTest.Web.Models
{
    public class CompanySaveModel
    {
        public int? Id { get; set; }

        [Required]
        public string CompanyName { get; set; }
    }
}