using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferentPdfGen
{
    public class CustomerForSalesCare
    {
        public string CustomerCode { get; set; }
        public string VatNumber { get; set; }
        public string CompanyName { get; set; }
        public List<ValidatingReferentDataCustomer> ValidatingReferents { get; set; }
        public long TicketId { get; set; }
        public bool IsCreated { get; set; }
    }
}
