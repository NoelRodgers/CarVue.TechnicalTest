using System.ComponentModel.DataAnnotations;

namespace CarVue.TechnicalTest.Core.Domain.Items
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}