using System.ComponentModel.DataAnnotations;

namespace CarVue.TechnicalTest.Core.Domain.Items
{
    public class VirtualAddress
    {
        [Key]
        public int Id { get; set; }

        public VirtualAddressType AddressType { get; set; }

        public string Value { get; set; }
    }
}