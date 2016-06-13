using System.ComponentModel.DataAnnotations;

namespace CarVue.TechnicalTest.Core.Domain.Items
{
    public class PhysicalAddress
    {
        [Key]
        public int Id { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string County { get; set; }

        public string PostCode { get; set; }



        public PhysicalAddressType AddressType { get; set; }

        public bool IsPrimaryAddress { get; set; }
    }
}