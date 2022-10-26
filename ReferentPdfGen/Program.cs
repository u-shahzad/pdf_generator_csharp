using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ReferentPdfGen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vr = new ValidatingReferentDataCustomer
            {
                Name = "Name01",
                Surname = "Surname01",
                Msisdn = "3494567897",
                Email = "name01@test.com"
            };

            var lVr = new List<ValidatingReferentDataCustomer>();
            lVr.Add(vr);

            CustomerForSalesCare cfsc = new CustomerForSalesCare()
            {
                CompanyName = "Company Name1",
                CustomerCode = "Customer Code1",
                TicketId = 123,
                VatNumber = "V1234",
                IsCreated = true,
                ValidatingReferents = lVr
            };

            PdfGenerator pg = new PdfGenerator(40f, 40f, 40f, 40f);
            var path = @"D:\temp";
            var result = pg.CreatePdf(path, cfsc, DateTime.Now, "1234");
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
