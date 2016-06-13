using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarVue.TechnicalTest.Core.Domain.Items
{
    public class Company
    {
        [Key]
        public int Id { get; set;  }

        public string Name { get; set; }

        public List<VirtualAddress> VirtualAddresses { get; set; }

        public List<PhysicalAddress> PhysicalAddresses { get; set; }
    }
}