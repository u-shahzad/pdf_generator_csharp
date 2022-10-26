using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferentPdfGen
{
    public class ValidatingReferentData
    {
        public string CustomerCode { get; set; }
        public string CustomerCode20 { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Msisdn { get; set; }
        public string Email { get; set; }
    }

    public class ValidatingReferentDataOrder : ValidatingReferentData
    {
        public bool IsCreated { get; set; }
    }

    public class ValidatingReferentDataCustomer : ValidatingReferentData
    {
        public bool Selected { get; set; }
        public bool? SentToOAG { get; set; }
        public bool? IsCreated { get; set; }
    }
}
