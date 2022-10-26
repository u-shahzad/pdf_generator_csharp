using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace ReferentPdfGen
{
    public class PdfGenerator
    {
        float LEFT_MARGIN;
        float RIGHT_MARGIN;
        float TOP_MARGIN;
        float BOTTOM_MARGIN;

        public PdfGenerator(float lEFT_MARGIN, float rIGHT_MARGIN, float tOP_MARGIN, float bOTTOM_MARGIN)
        {
            LEFT_MARGIN = lEFT_MARGIN;
            RIGHT_MARGIN = rIGHT_MARGIN;
            TOP_MARGIN = tOP_MARGIN;
            BOTTOM_MARGIN = bOTTOM_MARGIN;
        }

        public string CreatePdf(string path, CustomerForSalesCare cfsc, DateTime timestamp, string titCareId) 
        {
            var filename = $"salescare_otpvalidation_{titCareId}_{timestamp.ToString("dd_MM_yyyy_hhmmss")}.pdf";
            path = Path.Combine(path, filename);
            //var bgBlack = new BaseColor(0, 0, 0);
            //var baseFont = BaseFont.CreateFont(BlendEnvironment.MapPathAsRelative("/uploads/files/VodafoneRg.ttf"), BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            //var fTesto = new Font(baseFont, 12, Font.NORMAL, bgBlack);
            //var fBold = new Font(baseFont, 12, Font.BOLD, bgBlack);
            //var fHeader = new Font(baseFont, 8, Font.NORMAL, bgBlack);
            var fontBold = new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD);
            var fontNormal = new Font(Font.FontFamily.HELVETICA, 12f, Font.NORMAL);

            using (var fs = new FileStream(path, FileMode.Create))
            using (var document = new Document(PageSize.A4, LEFT_MARGIN, RIGHT_MARGIN, TOP_MARGIN, BOTTOM_MARGIN))
            using (var writer = PdfWriter.GetInstance(document, fs))
            {
                try
                {
                    writer.CompressionLevel = PdfStream.DEFAULT_COMPRESSION;
                    writer.StrictImageSequence = true;
                    writer.SetLinearPageMode();

                    // Filigrana e Logo
                    //var logo = Image.GetInstance(BlendEnvironment.MapPathAsRelative("/uploads/files/LogoVodafone.png"));
                    //var filigrana = Image.GetInstance(BlendEnvironment.MapPathAsRelative("/uploads/files/filigrana.png"));
                    //logo.ScalePercent(33f);
                    //filigrana.SetAbsolutePosition(0, 0);
                    //logo.SetAbsolutePosition((PageSize.A4.Width - 100f), 20f);
                    //var e = new ConclusivePdfPageEventHandler()
                    //{
                    //    logo = logo,
                    //    filigrana = filigrana,
                    //    testo = documentId,
                    //    font = fHeader
                    //};
                    //writer.PageEvent = e;

                    document.Open();

                    if (!string.IsNullOrWhiteSpace(titCareId))
                    {
                        var par1 = new Paragraph();
                        par1.Add(new Chunk("ID Pratica TiTCare: ", fontBold));
                        par1.Add(new Chunk(titCareId, fontNormal));
                        document.Add(new Paragraph(par1));
                        document.Add(new Paragraph(" "));
                    }
                    document.Add(new Paragraph(" "));

                    document.Add(new Paragraph("Dati Referente Validatore", fontBold));
                    document.Add(new Paragraph(" "));
                    document.Add(new Paragraph(" "));

                    var par2 = new Paragraph();
                    par2.Add(new Chunk("PIVA: ", fontBold));
                    par2.Add(new Chunk(cfsc.VatNumber, fontNormal));
                    document.Add(new Paragraph(par2));
                    document.Add(new Paragraph(" "));

                    var par3 = new Paragraph();
                    par3.Add(new Chunk("Nome e Cognome del Referente Validatore: ", fontBold));
                    par3.Add(new Chunk(cfsc.ValidatingReferents[0].Name + " " + cfsc.ValidatingReferents[0].Surname, fontNormal));
                    document.Add(new Paragraph(par3));
                    document.Add(new Paragraph(" "));

                    var par4 = new Paragraph();
                    par4.Add(new Chunk("Numero di telefono: ", fontBold));
                    par4.Add(new Chunk("+39 " + cfsc.ValidatingReferents[0].Msisdn, fontNormal));
                    document.Add(new Paragraph(par4));
                    document.Add(new Paragraph(" "));

                    var par5 = new Paragraph();
                    par5.Add(new Chunk("Indirizzo e-mail: ", fontBold));
                    par5.Add(new Chunk(cfsc.ValidatingReferents[0].Email, fontNormal));
                    document.Add(new Paragraph(par5));
                    document.Add(new Paragraph(" "));

                    document.Add(new Paragraph(" "));
                    var par6 = new Paragraph();
                    par6.Add(new Chunk("Data validazione OTP: ", fontBold));
                    par6.Add(new Chunk(timestamp.ToString("dd/MM/yyyy"), fontNormal));
                    document.Add(new Paragraph(par6));
                    document.Add(new Paragraph(" "));
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    document.Close();
                    writer.Close();
                    fs.Close();
                }
            }
            return filename;
        }
    }
}
